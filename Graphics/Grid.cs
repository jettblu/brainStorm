using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainStorm.Graphics
{
    public class Grid
    {
        public Rectangle Bounds { get; set; }

        public List<Shape> AllShapes = new List<Shape>();

        public int CellWidth { get; set; }
        public int CellHeight { get; set; }
        private int _rows;
        private int _cols;
        public int Rows
        {
            get => _rows;
            set
            {
                _rows = value;
                CellHeight = Bounds.Height / value;
            }
        }
        public int Cols
        {
            get => _cols;
            set
            {
                _cols = value;
                CellWidth = Bounds.Width / value;
            }
        }
        public Pen P { get; set; }
        public System.Drawing.Graphics G { get; set; }

        public Grid(Rectangle rectangle, int boardRows, int boardCols)
        {
            Bounds = rectangle;
            
            Rows = boardRows;
            Cols = boardCols;
            CellWidth = Bounds.Width / boardCols;
            CellHeight = Bounds.Height / boardRows;
            P = new Pen(Color.WhiteSmoke);
            // Create a Graphics object for the Control.
            G = BrainStorm0.MainControl.CreateGraphics();
        }

        public void DrawLines()
        {
            G.Clear(Color.Black);
            int y = 0;
            int x = 0;
            for (int i = 0; i < Rows-1; i++)
            {
                y += CellHeight;
                G.DrawLine(P, 0, y, Bounds.Width, y);
            }

            for (int i = 0; i < Cols-1; i++)
            {
                x += CellWidth;
                G.DrawLine(P, x, 0, x, Bounds.Bottom);
            }
            UpdateShapes();
        }

        // remove shapes and grids
        public void ClearShapes()
        {
            foreach (var shape in AllShapes)
            {
                shape.FlashEnabled = false;
            }
            AllShapes = new List<Shape>();
            var hasCleared = false;
            while (hasCleared == false)
            {

                try
            {
                G.Clear(Color.Black);
                hasCleared = true;
            }
            catch
            {
                  Console.WriteLine("Object in use somewhere else.");
            }

            }
            
      
            
            DrawLines();
            try
            {
                BrainStorm0.TrainTimer.Stop();
                BrainStorm0.TrainTimer.Dispose();
                BrainStorm0.TrainTimerCount = 0;
            }
            catch
            {
                Console.WriteLine("Did not clear train timer.");
            }
        }
        // redraw grid
        public void RedrawGrid()
        {
            G.Clear(Color.Black);
            DrawLines();
        }
        

        public void UpdateShapes()
        {
            foreach (var shape in AllShapes)
            {
                shape.DrawBox();
            }
        }
    }
}
