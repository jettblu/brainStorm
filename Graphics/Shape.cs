using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Timer = System.Windows.Forms.Timer;


namespace BrainStorm.Graphics
{
    public class Shape : Form
    {   
        public List<Shape> AllShapes = new List<Shape>();
        // grid properties
        public int Padding { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Fill { get; set; }
        // flashing properties
        private bool IsDisplayed { get; set; }
        private bool _flashEnabled;
        public int Count {get; set;}
        public Timer FlashTimer { get; set; }
        public int Hertz { get; set; }
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
        public Color Color { get; set; }
        public Brush TextBrush = new SolidBrush(Color.GhostWhite);
        static Font TextFont = new Font("Arial", 16);
        public Rectangle ShapeBounds { get; set; }

        public Grid CurrGrid { get; set; }
        public string Text { get; set; }

        public Shape(int shapeRow, int shapeCol, Color color, Grid grid, int hertz, string text = "sample text")
        {   
            Row = shapeRow;
            Col = shapeCol;
            Padding = 5;
            Hertz = hertz;
            Fill = IsDisplayed = FlashEnabled = true;
            Count = 0;
            // Create Graphics objects for the Control.
            CurrGrid = grid;
            P = new Pen(color);
            B = new SolidBrush(color);
            Color = color;
            ShapeBounds = new Rectangle((Col * CurrGrid.CellWidth) + Padding, (Row * CurrGrid.CellHeight) + Padding, CurrGrid.CellWidth - Padding * 2, CurrGrid.CellHeight - Padding * 2);
            // add current shape to all shapes
            grid.AllShapes.Add(this);
            Text = text;
        }

        public void UpdateShapeBounds()
        {
            ShapeBounds = new Rectangle((Col * CurrGrid.CellWidth) + Padding, (Row * CurrGrid.CellHeight) + Padding, CurrGrid.CellWidth - Padding * 2, CurrGrid.CellHeight - Padding * 2);
        }

        public void DrawBox()
        {   
            UpdateShapeBounds();
            CurrGrid.G.DrawRectangle(P, ShapeBounds);
            if (Fill)
            {
                CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            DrawString(Text);
        }

        // This is the method to run when the timer is raised.
        public void Flash(Object thisShape,
            EventArgs myEventArgs)
        {
            Count++;
            if (IsDisplayed)
            {
                B = new SolidBrush(Color.Black);
                CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            else
            {
                B = new SolidBrush(Color);
            CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            IsDisplayed = !IsDisplayed;
            DrawString(Text);
        }

        public void DrawCircle()
        {   
            UpdateShapeBounds();
            CurrGrid.G.DrawEllipse(P, ShapeBounds);
            if (Fill)
            {
                CurrGrid.G.FillRectangle(B, ShapeBounds);
            }
            DrawString(Text);
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

        public void DrawString(string innerText)
        {
            var x = (ShapeBounds.Right+ShapeBounds.Left)/2;
            var y = (ShapeBounds.Top+ShapeBounds.Bottom)/2;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            CurrGrid.G.DrawString(innerText, TextFont, TextBrush, x, y, stringFormat);
        }

    }
}
