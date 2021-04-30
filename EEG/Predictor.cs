using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Analysis;
using Accord.Statistics.Models.Regression.Linear;
using BrainStorm.Graphics;
using BrainStorm.MLHelper;

namespace BrainStorm.EEG
{
    class Predictor:Classification
    {
        // Linear Regression parameters for predictions
        public static MultipleLinearRegression MultipleGeneralRegression { get; set; }
        // Classifier Models
        public static KNearestNeighbors KNN = new KNearestNeighbors(4);

        public static RandomForest RandomForest { get; set; }
        // data to use for frequency prediction
        public static double[] CurrPredictionPoints { get; set; }
        // last prediction
        public static double PredictedFrequencyLinear { get; set; }
        public static double PredictedFrequencyGeneral { get; set; }
        public static int PredictedFrequencyClassifiers { get; set; }
        public static PrincipalComponentAnalysis PCA { get; set; }
        public static Normalizer FeatureNormalizer {get; set; }



        public static void MakePrediction()
        {
            StandardizePredictors();
            // use stored PCA analysis to transform standardized features
            // only use if features are normalized first
            CurrPredictionPoints = PCA.Transform(CurrPredictionPoints);
            if (Classification.IsClassifier)
            {
                PredictedFrequencyClassifiers = KNN.Decide(CurrPredictionPoints);
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} KNN Predicted Frequency: {PredictedFrequencyClassifiers}");
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Random Forest Predicted Frequency: {RandomForest.Decide(CurrPredictionPoints)}");
            }
            else
            {
                PredictedFrequencyGeneral = MultipleGeneralRegression.Transform(CurrPredictionPoints);
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} MGR Predicted Frequency: {PredictedFrequencyGeneral}");
            }
        }

        public static void StandardizePredictors()
        {
            var currIndex = 0;
            foreach (var value in CurrPredictionPoints)
            {
                CurrPredictionPoints[currIndex] = (value - FeatureNormalizer.Standardization[currIndex].Mean) /
                                                  FeatureNormalizer.Standardization[currIndex].StandardDeviation;
                currIndex += 1;
            }
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
