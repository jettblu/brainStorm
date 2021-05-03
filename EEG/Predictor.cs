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
    class Predictor : Classification
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
        public static Normalizer FeatureNormalizer = new Normalizer();
        public static Dictionary<double, int> CurrPredictions = new Dictionary<double, int>();
        // percent of predictions needed to classify... hardcoded as a third
        public static double VotingThreshold = Classification.FrequencyClasses.Count / 3;
        // minimum number of predictions needed to classify
        public static double VoteTotalThreshold = Classification.FrequencyClasses.Count * 3;
        // indicate what stroke is for view
        public static Globals.StrokeTypes StrokeType { get; set; }
        // predicted language
        public static List<string> PredictedLanguage { get; set; }





        public static void MakePrediction(bool normalize = true, bool usePca = false)
        {

            if (normalize || usePca) StandardizePredictors();
            // use stored PCA analysis to transform standardized features
            // only use if features are normalized first
            if (usePca) CurrPredictionPoints = PCA.Transform(CurrPredictionPoints);

            if (Classification.IsClassifier)
            {
                Predict();
            }
            else
            {
                Regression();
            }
        }




        private static void Predict()
        {
            var lgrPred = -1;
            var lgrProb = -1.0;
            if (MultinomialLogisticRegression != null)
            {
                lgrPred = MultinomialLogisticRegression.Decide(CurrPredictionPoints);
                lgrProb = MultinomialLogisticRegression.Probability(CurrPredictionPoints);
                if (Classification.IsValidation)
                {
                    Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Logistic Regression Predicted Frequency: {lgrPred} Probability: {lgrProb}");
                }

            }

            var mmdPred = -1;
            var mmdScore = -1.0;
            if (MinimumMeanDistance != null)
            {
                mmdPred = MinimumMeanDistance.Decide(CurrPredictionPoints);
                mmdScore = MinimumMeanDistance.Score(CurrPredictionPoints);
                PredictedFrequencyClassifiers = mmdPred;
                if (Classification.IsValidation)
                {
                    Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Minimun Distance Predicted Frequency: {PredictedFrequencyClassifiers}");
                }

            }

            var rfPred = -1;
            if (RandomForest != null)
            {
                rfPred = RandomForest.Decide(CurrPredictionPoints);
                if (Classification.IsValidation)
                {
                    Console.WriteLine($"Real Frequency: {BrainStorm0.ClassificationShape.Hertz} Random Forest Predicted Frequency: {rfPred}");
                }

            }
        }

        public static void Classify()
        {
            var totalVotes = GetTotalVotes();
            // if there are enough predictions... 
            if (totalVotes >= VoteTotalThreshold)
            {
                // if a canidate has obtained minimum percent of votes
                var topCanidate = CurrPredictions.Keys.Max();
                if (CurrPredictions[topCanidate] / totalVotes >= VotingThreshold)
                {
                    var winningShape = GetClassifiedShape();
                    if (winningShape == null) return;
                    IndicateStrokeType(winningShape);
                }

            }
        }


        public static void IndicateStrokeType(Shape classifiedShape)
        {
            // if there is only one language piece in the shape add to output
            if (classifiedShape.Language.Count == 1)
            {
                StrokeType = Globals.StrokeTypes.Output;
            }
            else
            {
                StrokeType = Globals.StrokeTypes.Filter;
            }
            PredictedLanguage = classifiedShape.Language;
        }

        public static int GetTotalVotes()
        {
            var votecount = 0;
            foreach (var canidate in CurrPredictions)
            {
                votecount += canidate.Value;
            }
            return votecount;
        }

        public static Shape GetClassifiedShape()
        {
            if (BrainStorm0.MainGrid.AllShapes == null) return null;
            foreach (var shape in BrainStorm0.MainGrid.AllShapes)
            {
                if (shape.Hertz == PredictedFrequencyClassifiers)
                {
                    return shape; 
                }
            }
            return null;
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
