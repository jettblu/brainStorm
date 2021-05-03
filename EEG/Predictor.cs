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
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Linear;
using BrainStorm.Graphics;
using BrainStorm.MLHelper;

namespace BrainStorm.EEG
{
    class Predictor:Classification
    {
        // Regression models
        public static MultipleLinearRegression MultipleGeneralRegression { get; set; }
        public static PolynomialRegression MultiplePolyRegression { get; set; }
        public static MultinomialLogisticRegression MultinomialLogisticRegression { get; set; }
        // Classification Models
        public static MinimumMeanDistanceClassifier MinimumMeanDistance { get; set; }

        public static RandomForest RandomForest { get; set; }
        // data to use for frequency prediction
        public static double[] CurrPredictionPoints { get; set; }
        // last prediction
        public static double PredictedFrequencyLinear { get; set; }
        public static double PredictedFrequencyGeneral { get; set; }
        public static int PredictedFrequencyClassifiers { get; set; }
        public static PrincipalComponentAnalysis PCA { get; set; }
        public static Normalizer FeatureNormalizer  = new Normalizer();





        public static void MakePrediction(bool normalize=false, bool usePca=false)
        {

            if (normalize || usePca) StandardizePredictors();
            // use stored PCA analysis to transform standardized features
            // only use if features are normalized first
            if(usePca) CurrPredictionPoints = PCA.Transform(CurrPredictionPoints);

            if (Classification.IsClassifier)
            {
                Classify();
            }
            else
            {
               Regression();
            }
        }




        public static void Classify()
        {
            var lgrPred = -1;
            var lgrProb = -1.0;
            if (MultinomialLogisticRegression != null)
            {
                lgrPred = MultinomialLogisticRegression.Decide(CurrPredictionPoints);
                lgrProb = MultinomialLogisticRegression.Probability(CurrPredictionPoints);
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Logistic Regression Predicted Frequency: {lgrPred} Probability: {lgrProb}");
            }

            var mmdPred = -1;
            var mmdScore = -1.0;
            if (MinimumMeanDistance != null)
            {
                mmdPred = MinimumMeanDistance.Decide(CurrPredictionPoints);
                mmdScore = MinimumMeanDistance.Score(CurrPredictionPoints);
                PredictedFrequencyClassifiers = mmdPred;
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Minimun Distance Predicted Frequency: {PredictedFrequencyClassifiers}");
            }

            var rfPred = -1;
            if (RandomForest != null)
            {
                rfPred = RandomForest.Decide(CurrPredictionPoints);
                Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Random Forest Predicted Frequency: {rfPred}");
            }
            
            
        }

        public static void Regression()
        {
            if (MultipleGeneralRegression != null)
            {
                PredictedFrequencyGeneral = MultipleGeneralRegression.Transform(CurrPredictionPoints);
                Console.WriteLine(
                    $"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} MGR Predicted Frequency: {PredictedFrequencyGeneral}");
            }
            else
            {
                Console.WriteLine("Multiple General Regression is null.");
            }
        }
        public static void StandardizePredictors()
        {
            var currIndex = 0;
            for (int i = 0; i < CurrPredictionPoints.Length; i++)
            {
                var value = CurrPredictionPoints[i];
                
                CurrPredictionPoints[currIndex] = (value - FeatureNormalizer.Standardization[currIndex].Mean) /
                                                  FeatureNormalizer.Standardization[currIndex].StandardDeviation;

                currIndex += 1;
            }
             
        }




        
    }
    
}
