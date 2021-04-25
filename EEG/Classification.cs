using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrainStorm.CortexAccess;
using BrainStorm.Graphics;

namespace BrainStorm.EEG
{
    class Classification
    {   
        // indicate which component of classification
        public static bool IsTraining { get; set; }
        public static bool IsValidation { get; set; }
        // number of samples collected thus far for current frequency
        public static int NumSamples = 0;
        // total number of frequency labels to collect
        public static int NumUniqueFrequencyLabels { get; set; }
        public static int NumUniqueLabelsToCollect { get; set; }
        public static bool RestartCount = false;
        public static bool IsRunning = false;
        public static bool IsPure = false;
        public static int CurrFrequency = 2;
        public static int _eegDataCount = 0;
        // toggle for classification and regression displays
        public static bool IsClassifier = true;
        // electrodes classification will extract features from
        public static List<string> ClassificationElectrodes = new List<string>() {"AF3", "F7", "F3", "F4", "F8", "AF4"};
        public static List<int> ClassificationElectrodesIndices = new List<int>();
        // frequency classes used for SSVEP
        public static List<int> FrequencyClasses = new List<int>()
        {
            6, 15, 35
        };

        // how many data points (of each type) have been collected for given train frequency
        public static int EEGDataCount
        {
            get => _eegDataCount;
            set
            {
                if (IsRunning && BrainStorm0.ClassificationShape.FrequencyUpdated)
                {
                    _eegDataCount += 1;
                }
                // if two seconds have elapsed... sample is pure... start collecting samples
                if (_eegDataCount > SignalProcessor.SamplingRate * 2)
                {
                    IsPure = true;
                }

                // if we have collected enough samples at current frequency... display new
                if (NumSamples == SamplesToCollect)
                {
                    NumUniqueFrequencyLabels += 1;
                    if (IsClassifier)
                    {
                        DisplayNewFrequencyClassification();
                    }
                    else
                    {
                        DisplayNewFrequencyRegression();
                    }
                    
                    _eegDataCount = 0;
                    NumSamples = 0;
                    IsPure = false;
                }

                // stop training if we have recieved requested amount of samples
                if (NumUniqueFrequencyLabels == NumUniqueLabelsToCollect)
                {
                    StopProcess();
                }
            }
        }


        public static void StartProcess(int numUniqueLabels = 40)
        {
            BrainStorm0.MainGrid.ClearShapes();
            // set testing grid dimensions
            BrainStorm0.MainGrid.Cols = 7;
            BrainStorm0.MainGrid.Rows = 3;
            BrainStorm0.MainGrid.DrawLines();
            // init testing shape to center of grid
            var startText = "";
            if (IsTraining)
            {
                startText = "Training";
            }
            if (IsValidation)
            {
                startText = "Validation";
            }
            BrainStorm0.ClassificationShape = new Shape(BrainStorm0.MainGrid.Rows / 2, BrainStorm0.MainGrid.Cols / 2, Color.WhiteSmoke, BrainStorm0.MainGrid, CurrFrequency, startText);
            IsRunning = true;
            IsPure = false;
            NumUniqueLabelsToCollect = numUniqueLabels;
        }

        public static void StopProcess()
        {
            BrainStorm0.MainGrid.ClearShapes();
            _eegDataCount = 0;
            NumSamples = 0;
            NumUniqueFrequencyLabels = 0;
            IsPure = false;
            IsRunning = false;
            if (IsTraining)
            {   
                Utils.UserMessage("Training successful!", messageType:Globals.MessageTypes.Status);
                Trainer.FitData();
            }
            if (IsValidation)
            {
                Utils.UserMessage("Validation Complete.", messageType: Globals.MessageTypes.Status);
            }
            BrainStorm0.ClassificationShape = null;
            CurrFrequency = 2;
            IsTraining = false;
            IsValidation = false;
        }


        // how many samples to collect at each frequency
        public static int SamplesToCollect = 2;

        public static void DisplayNewFrequencyRegression()
        {

            Random rnd = new Random();
            var freq = rnd.Next(3, 40);
            CurrFrequency = freq;
            if (IsTraining)
            {   
                Console.WriteLine($"Training Frequency: {CurrFrequency}");
            }
            if (IsValidation)
            {
                Console.WriteLine($"Predictor Frequency: {CurrFrequency}");
               
            }
            BrainStorm0.ClassificationShape.Text = freq.ToString();
            BrainStorm0.ClassificationShape.FrequencyUpdated = false;


        }

        // only show k frequencies, where k is # of classes to train/ validate
        // show frequencies in random order to simulate live selection
        public static void DisplayNewFrequencyClassification()
        {
            Random rnd = new Random();
            var freq = FrequencyClasses[rnd.Next(FrequencyClasses.Count)];
            CurrFrequency = freq;

            if (IsTraining)
            {
                Console.WriteLine($"Training Frequency: {CurrFrequency}");
            }

            if (IsValidation)
            {
                Console.WriteLine($"Predictor Frequency: {CurrFrequency}");

            }
            BrainStorm0.ClassificationShape.Text = freq.ToString();
            BrainStorm0.ClassificationShape.FrequencyUpdated = false;
        }

        // filter data, so we only recieve data from bands/ nodes we care about
        public static List<Double> FilterBands(List<Double> bandDataAll)
        {
            var filteredBands = new List<Double>();
            foreach (var elecIndex in ClassificationElectrodesIndices)
            {
                filteredBands.Add(bandDataAll[elecIndex]);
            }
            return filteredBands;
        }
    }
}
