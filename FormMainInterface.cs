using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrainStorm.EEG;
using BrainStorm.Graphics;
using BrainStorm.nlp;

namespace BrainStorm
{   
    public partial class BrainStorm0 : Form
    {
        public static Control MainControl { get; set; }
        public Grid MainGrid { get; set; }
        public Shape TestShape { get; set; }
        public Timer TrainTimer { get; set; }
        public int TrainTimerCount = 0;
        public bool RecordEEG = true;
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
            MainGrid.DrawLines();
            foreach (var likelyWord in autoComplete.LikelyWords)
            {
                suggestedWordsPhrase += $"{likelyWord.Key}\n";
            }
            foreach (var likelyLetter in autoComplete.LikelyLetters)
            {
                suggestedLettersPhrase += $"{likelyLetter.Key}\n";
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
            var suggestedWordsShape = new Shape(1, 6, Color.WhiteSmoke, MainGrid, 25, suggestedWordsPhrase);
            var suggestedLettersShape = new Shape(1, 3, Color.WhiteSmoke, MainGrid, 15, suggestedLettersPhrase);
            var generalLettersShape = new Shape(1, 0, Color.WhiteSmoke, MainGrid, 10, generalLettersPhrase);
            suggestedWordsShape.DrawBox();
            suggestedLettersShape.DrawBox();
            generalLettersShape.DrawBox();
        }

        private void createTestingInstance(Object thisShape, EventArgs myEventArgs)
        {   
            TrainTimerCount += 1;
            // stop training if you reach specified number of trials
            if (TrainTimerCount == 20)
            {
                TrainTimer.Stop();
                TrainTimer.Dispose();
                MainGrid.ClearShapes();
            }
            else
            {
                // put test shape in random grid location
                Random rnd = new Random();
                var freq = rnd.Next(10, 25);
                TestShape.Col = rnd.Next(0, MainGrid.Cols);
                TestShape.Row = rnd.Next(0, MainGrid.Rows);
                TestShape.Hertz = freq;
                TestShape.Text = freq.ToString();
                if (TrainTimerCount != 0)
                {
                    MainGrid.RedrawGrid();
                }
                
                TestShape.DrawBox();
            }
        }

        // establish base grid on form load
        private void BrainStorm0_Load(object sender, EventArgs e)
        {
            MainControl = pboxInterface;
            MainGrid = new Grid(pboxInterface.Bounds, 2, 2);
            new StormControl(pboxClear, "Clear");
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {   
            // set testing grid dimensions
            MainGrid.Cols = 7;
            MainGrid.Rows = 3;
            MainGrid.DrawLines();
            // init testing shape to center of grid
            TestShape = new Shape(1, 6, Color.WhiteSmoke, MainGrid, 25, "Training");
            TrainTimer = new Timer();
            TrainTimer.Tick += new EventHandler(createTestingInstance);
            TrainTimer.Start();
            TrainTimer.Interval = 3000;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            EEGLogger.startLog();
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            EEGLogger.KeepRecording = false;
        }
    }
}
