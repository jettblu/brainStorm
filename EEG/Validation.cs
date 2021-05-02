using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Analysis;

namespace BrainStorm.EEG
{
    class Validation:Classification
    {
        public static double[][] PredictorPoints { get; set; }
        public static List<double[]> PredictorPointsValidateRaw = new List<double[]>();
        public static List<double> FrequencyLabelsRaw = new List<double>();
        public static int[] FrequencyLabelsInt { get; set; }
        public static double[] FrequencyLabelsDouble { get; set; }

        public static void Validate()
        {
            FrequencyLabelsInt = FrequencyLabelsRaw.ConvertAll(Convert.ToInt32).ToArray();
            FrequencyLabelsDouble = FrequencyLabelsRaw.ToArray();
            PredictorPoints = PredictorPointsValidateRaw.ToArray();
            if(IsClassifier) ClassifierStatistics();
            if(!IsClassifier) RegressionStatistics();
        }

        public static void StopValidation()
        {
            _eegDataCount = 0;
            NumSamples = 0;
            IsPure = false;
            BrainStorm0.MainGrid.ClearShapes();
            IsRunning = false;
        }

        public static void RegressionStatistics()
        {
            // Compute the predicted points using
            double[] predictedMGR = Predictor.MultipleGeneralRegression.Transform(PredictorPoints);


            // We can also compute other measures, such as the coefficient of determination r²
            double r2 = new RSquaredLoss(numberOfInputs: PredictorPoints.Length, expected: FrequencyLabelsDouble).Loss(predictedMGR);

            Console.WriteLine($"Multiple Linear Regression R^2 VALIDATION: {r2}\n");

            Console.Write("Multiple Linear regression fit succesfully!");
        }

        public static void ClassifierStatistics()
        {

            var cmLR = GeneralConfusionMatrix.Estimate(Predictor.MultinomialLogisticRegression, Validation.PredictorPoints,
                FrequencyLabelsInt);

            Console.WriteLine($"LR CM: {cmLR} \n LR Error: {cmLR.Error} LR ACcuracy: {cmLR.Accuracy}");

            var cmTree = GeneralConfusionMatrix.Estimate(Predictor.RandomForest, PredictorPoints, FrequencyLabelsInt);
            Console.WriteLine($"RF CM: {cmTree} \n RF Error: {cmTree.Error} RF ACcuracy: {cmTree.Accuracy}");

            var cmMMD = GeneralConfusionMatrix.Estimate(Predictor.MinimumMeanDistance, PredictorPoints,
                FrequencyLabelsInt);
            Console.WriteLine($"RF CM: {cmMMD} \n RF Error: {cmMMD.Error} RF ACcuracy: {cmMMD.Accuracy}");
        }
    }
}
