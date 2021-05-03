using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math.Optimization;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Analysis;
using Accord.Statistics.Filters;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Fitting;
using Accord.Statistics.Models.Regression.Linear;
using BrainStorm.Graphics;
using BrainStorm.MLHelper;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;

namespace BrainStorm.EEG
{
    class Trainer:Classification
    {
        public static List<double[]> PredictorPointsTrainRaw  = new List<double[]>();
        // transformed points
        public static double[][] PredictorPointsTrain { get; set; }

        public static List<double> FrequencyLabelsRaw = new List<double>();
        // store labels in different formats for different regresssion/ classification techniques
        public static int[] FrequencyLabelsInt { get; set; }
        public static double[] FrequencyLabelsDouble { get; set; }

        // # of components to collect from PCA.. hardcoded
        public const int NumComponents = 7;
        // # of trees in random forest.. hardcoded
        public const int NumTrees = 100;

        public static void FitData(bool normalize = false, bool usePca = false)
        {   
            Predictor.FeatureNormalizer = new Normalizer();
            if(normalize || usePca) NormalizeFeatures();
            // set label types
            FrequencyLabelsInt = FrequencyLabelsRaw.ConvertAll(Convert.ToInt32).ToArray();
            FrequencyLabelsDouble = FrequencyLabelsRaw.ToArray();
            PredictorPointsTrain = PredictorPointsTrainRaw.ToArray();

            if (usePca) SetPrincipleComponents();

            if (IsClassifier)
            {
                TrainClassifiers();
                CalulateTrainStatisticsClassification();
            }
            else
            {
                TrainRegression();
                CalculateTrainStatisticsRegression();
            }
        }

        // normalize data to z scores using each feature's mean and std. dev.
        public static void NormalizeFeatures()
        {   
            var featureHolder = new List<List<double>>();

            // make a list for each feature
            for (int i = 0; i < PredictorPointsTrainRaw[0].Count(); i++)
            {
                featureHolder.Add(new List<double>());
            }

            // add features to feature list
            foreach (var row in PredictorPointsTrainRaw)
            {
                var featureIndex = 0;
                foreach (var feature in row)
                {   
                    featureHolder[featureIndex].Add(feature);
                    featureIndex += 1;
                }
            }

            // standardize each feature
            for (int i = 0; i < featureHolder.Count; i++)
            {
                featureHolder[i] = Standardize(featureHolder[i]);
            }


            var rowIndex = 0;
            // swap each value in predictorpointstrainraw with normalized version
            foreach (var normalizedFeatureSet in featureHolder)
            {
                var colIndex = 0;
                foreach (var normalizedValue in normalizedFeatureSet)
                {   
                    PredictorPointsTrainRaw[rowIndex][colIndex] = normalizedValue;
                }
                rowIndex += 1;
            }
            
     
        }

        // z score scaling (zero mean)
        public static List<double> Standardize(List<double> features)
        {
            var standardizedFeatures = new List<double>();
            var featureMean = features.Mean();
            var featureStd = features.StandardDeviation();
            var standardizer = new FeatureStandards(featureMean, featureStd);
            Predictor.FeatureNormalizer.Standardization.Add(standardizer);
            var currIndex = 0;
            foreach (var value in features)
            {   
                // swap raw value for normalized value
                standardizedFeatures.Add(value - featureMean / featureStd);
                currIndex += 1;
            }
            return standardizedFeatures;
        }

        public static void TrainRegression()
        {
            
            // use ordinary least squares as train type
            var ols = new OrdinaryLeastSquares()
            {
                UseIntercept = true
            };

            // Use Ordinary Least Squares to estimate a regression model
            Predictor.MultipleGeneralRegression = ols.Learn(PredictorPointsTrain, FrequencyLabelsDouble);


           

        }

        public static void CalculateTrainStatisticsRegression()
        {
            Console.WriteLine("----TRAIN Statistics----");
            // Compute the predicted points using
            double[] predictedMGR = Predictor.MultipleGeneralRegression.Transform(PredictorPointsTrain);


            // We can also compute other measures, such as the coefficient of determination r²
            double r2 = new RSquaredLoss(numberOfInputs: PredictorPointsTrain.Length, expected: FrequencyLabelsDouble).Loss(predictedMGR);

            Console.WriteLine($"Multiple Linear Regression R^2: {r2}\n");

            Console.Write("Multiple Linear regression fit succesfully!");
        }

        public static void TrainClassifiers()
        {
            // -------------------------- Logistic Regression ----------------------------------

            var MLRG = new MultinomialLogisticLearning<GradientDescent>();

            Predictor.MultinomialLogisticRegression = MLRG.Learn(PredictorPointsTrain, FrequencyLabelsInt);

           

            // -------------------------- Random Forest ----------------------------------

            var teacher = new RandomForestLearning()
            {
                NumberOfTrees = NumTrees,
            };
            Predictor.RandomForest = teacher.Learn(PredictorPointsTrain, FrequencyLabelsInt);     


            // -------------------------- Minimum Mean Distance ----------------------------------

            Predictor.MinimumMeanDistance= new MinimumMeanDistanceClassifier();

            // Compute the analysis and create a classifier
            Predictor.MinimumMeanDistance.Learn(PredictorPointsTrain, FrequencyLabelsInt);


        }

        public static void CalulateTrainStatisticsClassification()
        {
            Console.WriteLine("----TRAIN Statistics----");
            var cmLR = GeneralConfusionMatrix.Estimate(Predictor.MultinomialLogisticRegression, PredictorPointsTrain,
                FrequencyLabelsInt);

            Console.WriteLine($"LR CM: {cmLR} \n LR Error: {cmLR.Error} LR ACcuracy: {cmLR.Accuracy}");

            var cmMMD = GeneralConfusionMatrix.Estimate(Predictor.MinimumMeanDistance, PredictorPointsTrain,
                FrequencyLabelsInt);
            Console.WriteLine($"MMD CM: {cmMMD} \n MMD Error: {cmMMD.Error} MMD ACcuracy: {cmMMD.Accuracy}");

            var cmTree = GeneralConfusionMatrix.Estimate(Predictor.RandomForest, PredictorPointsTrain, FrequencyLabelsInt);
            Console.WriteLine($"RF CM: {cmTree} \n RF Error: {cmTree.Error} RF ACcuracy: {cmTree.Accuracy}");
        }

        public static void SetPrincipleComponents()
        {
            var data = PredictorPointsTrainRaw.ToArray();
            // An n analysis with centering (covariance method) but no standardization (correlation method) and whitening:
            Predictor.PCA = new PrincipalComponentAnalysis()
            {
                Method = PrincipalComponentMethod.Center,
                Whiten = true
            };
            Predictor.PCA.ExplainedVariance = 0.25;
            // Recieve first n components by setting 
            // NumberOfOutputs to the desired components:
            Predictor.PCA.NumberOfOutputs = NumComponents;
            Predictor.PCA.Learn(data);
            // And then calling transform again:
            PredictorPointsTrain = Predictor.PCA.Transform(data);
        }
       
    }
}
