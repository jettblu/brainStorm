using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BrainStorm.Graphics
{
    class StormControl
    {
        private Control _pBox;
        public System.Drawing.Graphics G { get; set; }
        public int TextX { get; set; }
        public int TextY { get; set; }

        public Control PictureBox
        {
            get => _pBox;
            set
            {
                _pBox = value;
                TextX = (value.Bounds.Right + value.Bounds.Left) / 2;
                TextY = (value.Bounds.Top + value.Bounds.Bottom) / 2;
                G = value.CreateGraphics();
            }
        }

        // text formatting properties
        public string Text { get; set; }
        public StringFormat StringStyle { get; set; }
        public Pen P { get; set; }
        public Brush B { get; set; }
        public Brush TextBrush = new SolidBrush(Color.WhiteSmoke);
        public Font TextFont = new Font("Arial", 8);
        // flashing properties
        private bool IsDisplayed { get; set; }
        private bool _flashEnabled;
        public int Count { get; set; }
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
                FlashTimer.Interval = 1000 / Hertz;
            }
        }


        public StormControl(Control picBox, string text, int hertz=10)
        {
            PictureBox = picBox;
            Hertz = hertz;
            FlashEnabled = IsDisplayed = true;
            G = PictureBox.CreateGraphics();
            StringStyle = new StringFormat();
            StringStyle.Alignment = StringAlignment.Center;
            StringStyle.LineAlignment = StringAlignment.Center;
            Text = text;
            G.DrawString(Text, TextFont, TextBrush, TextX, TextY, StringStyle);
        }

        public void Flash(Object thisShape,
            EventArgs myEventArgs)
        {
            Count++;
            if (IsDisplayed)
            {
                PictureBox.BackColor = Color.Black;
            }
            else
            {
                PictureBox.BackColor = Color.Blue;
            }
            IsDisplayed = !IsDisplayed;
            G.DrawString(Text, TextFont, TextBrush, TextX, TextY, StringStyle);
        }
    }
}
