﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.Statistics.Analysis;
using BrainStorm.BackTesting;
using BrainStorm.CortexAccess;
using BrainStorm.Graphics;

namespace BrainStorm.EEG
{
    class Classification
    {   
        // indicate which component of classification
        public static bool IsTraining { get; set; }
        public static bool IsValidation { get; set; }
        public static bool IsTyping { get; set; }
        // number of samples collected thus far for current frequency
        public static int NumSamples = 0;
        // total number of frequency labels to collect
        public static int NumUniqueFrequencyLabels { get; set; }
        public static int NumUniqueLabelsToCollect { get; set; }
        public static bool RestartCount = false;
        public static bool IsRunning = false;
        public static bool IsPure = false;
        public static int CurrFrequency = 6;
        public static int _eegDataCount = 0;
        // toggle for classification and regression displays
        public static bool IsClassifier = false;
        // electrodes classification will extract features from
        public static List<string> ClassificationElectrodes = new List<string>() {"AF3", "F7", "F3", "F4", "F8", "AF4"};
        public static List<int> ClassificationElectrodesIndices = new List<int>();
        //How many seconds to wait until considered pure... hardcoded
        public const double PureSeconds = 2.5;
        // how many samples to collect at each frequency
        public static int SamplesToCollect = 8;
        public static bool PredictionMade = false;

        // frequency classes used for SSVEP
        public static List<int> FrequencyClasses = new List<int>()
        {
            15, 6, 35
        };

        // how many data points (of each type) have been collected for given train frequency
        public static int EEGDataCount
        {
            get => _eegDataCount;
            set
            {
                if (IsRunning)
                {
                    _eegDataCount += 1;
                }
                // if x seconds have elapsed... sample is pure... start collecting samples
                if (_eegDataCount > SignalProcessor.SamplingRate * PureSeconds)
                {
                    IsPure = true;
                }

                // for training...
                // if we have collected enough samples at current frequency... display new
                if (NumSamples == SamplesToCollect && !IsTyping)
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

                if (IsTyping && PredictionMade)
                {
                    _eegDataCount = 0;
                    NumSamples = 0;
                    IsPure = false;
                    PredictionMade = false;
                }

                // stop training if we have recieved requested amount of samples
                if (NumUniqueFrequencyLabels == NumUniqueLabelsToCollect)
                {
                    StopProcess();
                }
            }
        }

        public static void ResetFlagStateTyping()
        {
            EEGDataCount = 0;
            IsPure = false;
        }

        public static void StartTrainProcess(int numUniqueLabels = 50)
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


        public static void StartTypeProcess()
        {   
            IsRunning = true;
            IsPure = false;
            TypingViews.CreateInitialGrid();
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
                // don't show user message if running backtest with feature evaluation on
                if (BrainStorm0.BackTest != null && SignalProcessor.IsBackTest && BrainStorm0.BackTest.FeatureEvaluation)
                {

                }
                else
                {
                    Utils.UserMessage("Training successful!", messageType:Globals.MessageTypes.Status);
                }
                
                Trainer.FitData();
            }
            if (IsValidation)
            {
                Utils.UserMessage("Validation Complete.", messageType: Globals.MessageTypes.Status);
                Validation.Validate();
            }
            BrainStorm0.ClassificationShape = null;
            CurrFrequency = 2;
            IsTraining = false;
            IsValidation = false;
        }


        

        public static void DisplayNewFrequencyRegression()
        {
            if (SignalProcessor.IsBackTest)
            {
                CurrFrequency = BrainStorm0.BackTest.ClassificationFrequency;
            }
            else
            {
                Random rnd = new Random();
                CurrFrequency = rnd.Next(3, 40);
            }
            

            // uncomment to write frequency label to console
           /* if (IsTraining)
            {   
                Console.WriteLine($"Training Frequency: {CurrFrequency}");
            }
            if (IsValidation)
            {
                Console.WriteLine($"Predictor Frequency: {CurrFrequency}");
               
            }*/

            BrainStorm0.ClassificationShape.Text = CurrFrequency.ToString();
            BrainStorm0.ClassificationShape.FrequencyUpdated = false;


        }

        // only show k frequencies, where k is # of classes to train/ validate
        // show frequencies in random order to simulate live selection
        public static void DisplayNewFrequencyClassification(bool switchLocation=false)
        {
            Random rnd = new Random();
            var freq = FrequencyClasses[rnd.Next(FrequencyClasses.Count)];
            CurrFrequency = freq;

            

            // uncomment to write frequency label to console
            /*   if (IsTraining)
               {
                   Console.WriteLine($"Training Frequency: {CurrFrequency}");
               }

               if (IsValidation)
               {
                   Console.WriteLine($"Predictor Frequency: {CurrFrequency}");

               }*/
           
            BrainStorm0.ClassificationShape.Text = freq.ToString();
            if (switchLocation)
            {
                if (CurrFrequency == FrequencyClasses[0])
                {
                    BrainStorm0.ClassificationShape.Row = 1;
                    BrainStorm0.ClassificationShape.Col = 3;
                }
                if (CurrFrequency == FrequencyClasses[1])
                {
                    BrainStorm0.ClassificationShape.Row = 1;
                    BrainStorm0.ClassificationShape.Col = 0;
                }
                if (CurrFrequency == FrequencyClasses[2])
                {
                    BrainStorm0.ClassificationShape.Row = 1;
                    BrainStorm0.ClassificationShape.Col = 6;
                }
            }
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
