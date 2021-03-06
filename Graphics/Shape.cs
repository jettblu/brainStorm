﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BrainStorm.EEG;
using Timer = System.Windows.Forms.Timer;


namespace BrainStorm.Graphics
{
    public class Shape : Form
    {
        public List<Shape> AllShapes = new List<Shape>();

        // grid properties
        public int HorPadding { get; set; }

        public int VertPadding { get; set; }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool Fill { get; set; }
        // flashing properties
        private bool IsDisplayed { get; set; }
        private bool _flashEnabled;
        private int _hertz;
        public int Count {get; set;}
        public Timer FlashTimer { get; set; }
        public bool FrequencyUpdated = true;
        public int Hertz
        {
            get => _hertz;
            set
            {
                _hertz = value;
                // update timer interval, if changing freq. value of flashing shape
                if (FlashEnabled)
                {
                    FlashTimer.Interval = 1000 / value; 
                }
              
            } 
        }
        public bool FlashEnabled
        {
          get => _flashEnabled;
          set
           {   
            _flashEnabled = value;
               if (value != true)
               {
                   if (FlashTimer != null)
                   { 
                      // if shape is flashing stop it
                      FlashTimer.Stop();
                      FlashTimer.Enabled = false; 
                   }
                   return;
               }
               FlashTimer = new Timer();
               FlashTimer.Tick += new EventHandler(Flash);
               FlashTimer.Start();
               FlashTimer.Interval = 1000/Hertz;
            }  
        }
        // drawing properties
        public System.Drawing.Graphics G { get; set; }
        public Pen P { get; set; }
        public Brush B { get; set; }
        // brush used for flashing... hardcoded as black
        public Brush BFlash  = new SolidBrush(Color.Black);
        public Color Color { get; set; }
        static Font TextFont = new Font("Arial", 16);
        public Rectangle ShapeBounds { get; set; }

        public Grid CurrGrid { get; set; }
        public string Text { get; set; }
        // language displayed for selection
        public List<string> Language { get; set; }

        public Shape(int shapeRow, int shapeCol, Color color, Grid grid, int hertz, string text = "sample text", int horPadding=5, int vertPadding=10)
        {   
            Row = shapeRow;
            Col = shapeCol;
            HorPadding = horPadding;
            VertPadding = vertPadding;
            Hertz = hertz;
            Fill = IsDisplayed = FlashEnabled = true;
            Count = 0;
            // Create Graphics objects for the Control.
            CurrGrid = grid;
            P = new Pen(color);
            B = new SolidBrush(color);
            Color = color;
            ShapeBounds = new Rectangle((Col * CurrGrid.CellWidth) + HorPadding, (Row * CurrGrid.CellHeight) + VertPadding, CurrGrid.CellWidth - HorPadding * 2, CurrGrid.CellHeight - VertPadding * 2);
            // add current shape to all shapes
            grid.AllShapes.Add(this);
            Text = text;
        }
        // a method that allows for creation of grids inside grids... make padding static to implement
        /*public static Rectangle CreateRectangle(int shapeRow, int shapeCol, Grid grid)
        {
            var result = new Rectangle((shapeCol * grid.CellWidth) + HorPadding, (shapeRow * grid.CellHeight) + VertPadding, grid.CellWidth - HorPadding * 2, grid.CellHeight - VertPadding * 2);
            return result;
        }*/
        public void UpdateShapeBounds()
        {
            ShapeBounds = new Rectangle((Col * CurrGrid.CellWidth) + HorPadding, (Row * CurrGrid.CellHeight) + VertPadding, CurrGrid.CellWidth - HorPadding * 2, CurrGrid.CellHeight - VertPadding * 2);
        }

        public void DrawBox()
        {   
            UpdateShapeBounds();
            CurrGrid.G.DrawRectangle(P, ShapeBounds);
            if (Fill)
            {
                CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            DrawString(Text, BFlash);
        }

        // This is the method to run when the timer is raised.
        public void Flash(Object thisShape,
            EventArgs myEventArgs)
        {   
            // uncomment below to write current Hertz to console
            // Console.WriteLine($"HERTZ: {Hertz}");
            Count++;
            if (IsDisplayed)
            {
                CurrGrid.G.FillRectangle(B, ShapeBounds);
                DrawString(Text, BFlash);
            }
            else
            {
                CurrGrid.G.FillRectangle(BFlash, ShapeBounds);
                DrawString(Text, B);
            }
            IsDisplayed = !IsDisplayed;
            if (Classification.CurrFrequency != Hertz && (Classification.IsTraining || Classification.IsValidation))
            {   
                Hertz = Classification.CurrFrequency;
                // indicate frequency has been updated
                FrequencyUpdated = true;
                BrainStorm0.MainGrid.RedrawGrid();
                DrawBox();
            }
            if (Classification.IsTyping)
            {
                ViewOnTypingState();
            }
        }

        public void DrawCircle()
        {   
            UpdateShapeBounds();
            CurrGrid.G.DrawEllipse(P, ShapeBounds);
            if (Fill)
            {
                CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            DrawString(Text, BFlash);
        }

        // see if shape already exists and if it falls within the grid
        public static bool IsValid(int shapeRow, int shapeCol, Grid grid)
        {
            // prevents adding a shape outside of grid
            if (shapeRow > grid.Rows || shapeCol > grid.Cols) return false;
            // prevents adding a shape on top of one that already exists
            foreach (var existingShape in grid.AllShapes)
            {
                if (shapeRow == existingShape.Row & shapeCol == existingShape.Col) return false;
            }
            return true;
        }

        public void DrawString(string innerText, Brush textBrush)
        {
            var x = (ShapeBounds.Right+ShapeBounds.Left)/2;
            var y = (ShapeBounds.Top+ShapeBounds.Bottom)/2;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            CurrGrid.G.DrawString(innerText, TextFont, textBrush, x, y, stringFormat);
        }

        // changes view based on typing state
        public void ViewOnTypingState()
        {
            if (Classification.IsTyping)
            {
                switch (Predictor.StrokeType)
                {
                    case Globals.StrokeTypes.Waiting:
                        return;
                    case Globals.StrokeTypes.Output:
                        TypingViews.UpdateOutputView();
                        break;
                    case Globals.StrokeTypes.Filter:
                        TypingViews.FilterView();
                        break;
                    case Globals.StrokeTypes.CtrlZ:
                        TypingViews.CtrlZView();
                        break;
                }
                // reset purity on view switch
                Classification.ResetFlagStateTyping();
                Predictor.StrokeType = Globals.StrokeTypes.Waiting;
            }
        }

    }
}
