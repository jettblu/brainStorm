using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BrainStorm.BackTesting;
using BrainStorm.CortexAccess;
using BrainStorm.EEG;
using BrainStorm.Graphics;
using BrainStorm.nlp;
using Timer = System.Windows.Forms.Timer;

namespace BrainStorm
{   
    public partial class BrainStorm0 : Form
    {   
        public static Control MainControl { get; set; }
        public static Grid MainGrid { get; set; }
        public static Shape ClassificationShape { get; set; }
        public static Timer TrainTimer { get; set; }
        public static Timer PurityTimer { get; set; }
        public static  int TrainTimerCount;
        public static int TrainSampleSize = 5;
        public static bool RecordEEG = true;
        public static BackTest BackTest { get; set; }
        public static Thread FormThread { get; set; }
        public string OutputText
        {
            get { return tboxOutput.Text; }
            set { tboxOutput.Text = value; }
        }
        public static BrainStorm0 MainForm { get; set; }
        public BrainStorm0()
        {
            InitializeComponent();
            MainForm = this;
            FormThread = Thread.CurrentThread;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            MainGrid.Cols = Convert.ToInt16(numCols.Value);
            MainGrid.Rows = Convert.ToInt16(numRows.Value);
            MainGrid.ClearShapes();
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
            try
            {
                await autoComplete.GetSearchSuggestions(tboxPhrase.Text);
            }
            catch
            {
                Utils.UserMessage("Please Connect to the internet before using autocomplete.", messageType:Globals.MessageTypes.Error);
            }
            //return if no autocomplete suggestions are returned
            if (autoComplete.AutoCompleteSuggestions.Count == 0)
            {
                return;
            }
            TypingViews.CreateSuggestionGrid(autoComplete);
        }

        

        private void RegressionTrainingRandomLocation(Object thisShape, EventArgs myEventArgs)
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
                ClassificationShape.Col = rnd.Next(0, MainGrid.Cols);
                ClassificationShape.Row = rnd.Next(0, MainGrid.Rows);
                ClassificationShape.Hertz = freq;
                ClassificationShape.Text = freq.ToString();
                if (TrainTimerCount != 0)
                {
                    MainGrid.RedrawGrid();
                }
                
                ClassificationShape.DrawBox();
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
            if (EEGLogger.IsConnected)
            {
                Classification.IsClassifier = cBoxClassification.Checked;
                Classification.IsTraining = true;
                Classification.StartTrainProcess();
                // enable validation after training
                btnValidate.Enabled = true;
                btnStartTyping.Enabled = true;
            }
            else
            {
                Utils.UserMessage("Please connect to headset before you begin training.", messageType: Globals.MessageTypes.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                EEGLogger.startLog();
                btnStopRecord.Enabled = true;
            }
            catch
            {
                Utils.UserMessage("Connection failed. Please try again. Check console for more details.", messageType:Globals.MessageTypes.Error);
            }
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            EEGLogger.KeepRecording = false;
        }


        public void HandleResponse(string EEGMessage, int threadID)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, int>(HandleResponse), EEGMessage, threadID);
                return;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (EEGLogger.IsConnected)
            {
                Classification.IsValidation = true;
                Classification.StartTrainProcess();
            }
            else
            {
                Utils.UserMessage("Please connect to headset before you run validation.", messageType: Globals.MessageTypes.Error);
            }
            
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            
            try
            {
                Utils.SendEmail("This Came from a Mind Controlled Keyboard!!", tboxOutput.Text);
                // disconnect from headset
                EEGLogger.KeepRecording = false;
                Utils.UserMessage("Email sent! Recording has stopped.", Globals.MessageTypes.Status);
            }
            catch
            {
                Utils.UserMessage("Issue sending email. Check error logs.", Globals.MessageTypes.Error);
            }
            
        }

        private void cBoxClassification_CheckedChanged(object sender, EventArgs e)
        {
            if (Classification.IsRunning) return;
            Classification.IsClassifier = cBoxClassification.Checked;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            Classification.IsClassifier = cBoxClassification.Checked;
            if (BackTestSelector.ShowDialog() != DialogResult.OK) return;
            BackTest = new BackTest();
            BackTest.FeatureEvaluation = cboxFeatureEvaluation.Checked;
            SignalProcessor.IsBackTest = true;
            BackTest.MaxSpeed = cBoxBackTestWait.Checked;
            // attach event handlers for back test
            BackTest.OnBackTestBandDataRecieved += SignalProcessor.OnBandPowerRecieved;
            BackTest.OnBackTestEEGDataRecieved += SignalProcessor.OnEEGDataReceived;
            if (!BackTest.FeatureEvaluation)
            {
                Utils.UserMessage("Backtest will start after dialogue is closed.", messageType:Globals.MessageTypes.Status);
            }
            new Thread(() =>
                {
                    
                    BackTest.HandleRecords(BackTestSelector.OpenFile());
                    if (BackTest.FeatureEvaluation)
                    {
                        while (Classification.ClassificationElectrodes.Count > 0)
                        {
                            SignalProcessor.IsBackTest = true;
                            Classification.IsClassifier = cBoxClassification.Checked;
                            Trainer.PredictorPointsTrainRaw.Clear();
                            Trainer.FrequencyLabelsRaw.Clear();
                            Classification.ClassificationElectrodes.RemoveAt(Classification.ClassificationElectrodes.Count-1);
                            BackTest.HandleRecords(BackTestSelector.OpenFile());
                        }
                    }
                    Utils.UserMessage("Backtesting Finished", messageType: Globals.MessageTypes.Status);

                })
                { IsBackground = true }.Start();
            
        }

        private void cBoxBackTestWait_CheckedChanged(object sender, EventArgs e)
        {   
            // don't switch speed while running
            if(SignalProcessor.IsBackTest) return;
        }

        private void btnStartTyping_Click(object sender, EventArgs e)
        {
            Classification.IsTyping = true;
            Classification.IsRunning = true;
            TypingViews.CreateInitialGrid();
        }



    }
}
