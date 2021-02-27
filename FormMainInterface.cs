using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrainStorm.Graphics;
using BrainStorm.nlp;

namespace BrainStorm
{
    public partial class BrainStorm0 : Form
    {
        public Grid MainGrid { get; set; }
        public BrainStorm0()
        {
            InitializeComponent();
            MainGrid = new Grid(pboxInterface, 2, 2);
            new StormControl(pboxClear, "Clear");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MainGrid.Cols = Convert.ToInt16(numCols.Value);
            MainGrid.Rows = Convert.ToInt16(numRows.Value);
            MainGrid.DrawLines();
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            if (Shape.IsValid(Convert.ToInt16(numShapeRow.Value), Convert.ToInt16(numShapeCol.Value), MainGrid))
            {
                 var newShape = new Shape(Convert.ToInt16(numShapeRow.Value), Convert.ToInt16(numShapeCol.Value), Color.Blue, MainGrid, Convert.ToInt16(numFreq.Value));
                 newShape.DrawBox();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MainGrid.ClearShapes();
        }

        private void BrainStorm0_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed
            Application.Exit();
        }

        private async void btnAutoComplete_ClickAsync(object sender, EventArgs e)
        {
            var autoComplete = new googleComplete();
            var suggestions = new List<GoogleSuggestion>();
            await autoComplete.GetSearchSuggestions();
            suggestions = autoComplete.AutoCompleteSuggestions;
        }
    }
}
