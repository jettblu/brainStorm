using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrainStorm.Graphics;

namespace BrainStorm.EEG
{
    class Predictor:Classification
    {
        // Linear Regression parameters for predictions
        public static Func<double[], double> MultipleLinearRegressionFunc { get; set; }
        public static Func<double [], double> MultipleGeneralRegressionFunc { get; set; }
        // data to use for frequency prediction
        public static double[] CurrPredictionPoints { get; set; }
        // last prediction
        public static double PredictedFrequencyLinear { get; set; }
        public static double PredictedFrequencyGeneral { get; set; }


        public static void MakePrediction()
        {
            PredictedFrequencyLinear = MultipleLinearRegressionFunc(CurrPredictionPoints);
            Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} MLR Predicted Frequency: {PredictedFrequencyLinear}");
            PredictedFrequencyGeneral = MultipleGeneralRegressionFunc(CurrPredictionPoints);
            Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} MGR Predicted Frequency: {PredictedFrequencyGeneral}");
        }

        public static void StopValidation()
        {
            _eegDataCount = 0;
            NumSamples = 0;
            IsPure = false;
            BrainStorm0.MainGrid.ClearShapes();
            IsRunning = false;
        }

        
    }
    
}
