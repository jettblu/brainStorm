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
            await autoComplete.GetSearchSuggestions(tboxPhrase.Text);
            //return if no autocomplete suggestions are returned
            if (autoComplete.AutoCompleteSuggestions.Count == 0)
            {
                return;
            }
            createSuggestionGrid(autoComplete);
        }

        private void createSuggestionGrid(googleComplete autoComplete)
        {
            var suggestedWordsPhrase = "";
            var suggestedLettersPhrase = "";
            var generalLettersPhrase = "";
            MainGrid.ClearShapes();
            // create 3 by 1 space that will contain likely letters, likely words, and general letters bin
            MainGrid.Cols = 7;
            MainGrid.Rows = 3;
            foreach (var likelyWord in autoComplete.LikelyWords)
            {
                suggestedWordsPhrase += $"{likelyWord.Key}\n";
            }
            foreach (var likelyLetter in autoComplete.LikelyLetters)
            {
                suggestedLettersPhrase += $"{likelyLetter}\n";
            }
            var isNewLine = false;
            foreach (var genLetter in autoComplete.GenLetters)
            {
                if (isNewLine)
                {
                    generalLettersPhrase += $"{genLetter}\n";
                }
                else
                {
                    generalLettersPhrase += $"{genLetter}\t";
                }
                isNewLine = !isNewLine;

            }
            var suggestedWordsShape = new Shape(1, 6, Color.Blue, MainGrid, 25, suggestedWordsPhrase);
            var suggestedLettersShape = new Shape(1, 3, Color.Blue, MainGrid, 15, suggestedLettersPhrase);
            var generalLettersShape = new Shape(1, 0, Color.WhiteSmoke, MainGrid, 10, generalLettersPhrase);
            suggestedWordsShape.DrawBox();
            suggestedLettersShape.DrawBox();
            generalLettersShape.DrawBox();
        }
        // establish base grid on form load
        private void BrainStorm0_Load(object sender, EventArgs e)
        {
            MainGrid = new Grid(pboxInterface, 2, 2);
            new StormControl(pboxClear, "Clear");
        }
    }
}
