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
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Analysis;
using Accord.Statistics.Filters;
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

        public static void FitData()
        {   
            Predictor.FeatureNormalizer = new Normalizer();
            NormalizeFeatures();
            // set label types
            FrequencyLabelsInt = FrequencyLabelsRaw.ConvertAll(Convert.ToInt32).ToArray();
            FrequencyLabelsDouble = FrequencyLabelsRaw.ToArray();
            PredictorPointsTrain = PredictorPointsTrainRaw.ToArray();
            //SetPrincipleComponents();
            if (IsClassifier)
            {
                TrainClassifiers();
            }
            else
            {
                RunRegression();
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
            foreach (var featureList in featureHolder)
            {
                Standardize(featureList);
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
        public static void Standardize(List<double> features)
        {
            var featureMean = features.Mean();
            var featureStd = features.StandardDeviation();
            var standardizer = new FeatureStandards(featureMean, featureStd);
            Predictor.FeatureNormalizer.Standardization.Add(standardizer);
            var currIndex = 0;
            foreach (var value in features)
            {   
                // swap raw value for normalized value
                features[currIndex] =  value - featureMean / featureStd;
                currIndex += 1;
            }
        }

        public static void RunRegression()
        {
            
            // use ordinary least squares as train type
            var ols = new OrdinaryLeastSquares()
            {
                UseIntercept = true
            };

            // Use Ordinary Least Squares to estimate a regression model
            Predictor.MultipleGeneralRegression = ols.Learn(PredictorPointsTrain, FrequencyLabelsDouble);


            // We can compute the predicted points using
            double[] predicted = Predictor.MultipleGeneralRegression.Transform(PredictorPointsTrain);


            // We can also compute other measures, such as the coefficient of determination r²
            double r2 = new RSquaredLoss(numberOfInputs: PredictorPointsTrain.Length, expected: FrequencyLabelsDouble).Loss(predicted); 
            
            Console.WriteLine($"Multiple Linear Regression R^2: {r2}\n");

            Console.Write("Multiple Linear regression fit succesfully!");
        }


        public static void TrainClassifiers()
        {

            var knn = Predictor.KNN;

            // We learn the algorithm:
            knn.Learn(PredictorPointsTrain, FrequencyLabelsInt);

            // compute the error matrix for the classifier:
            var cm = GeneralConfusionMatrix.Estimate(knn, PredictorPointsTrain, FrequencyLabelsInt);
            Console.WriteLine($"KNN CM: {cm} \n KNN Error: {cm.Error} KNN ACcuracy: {cm.Accuracy}");

            // Create forest learning algorithm
            var teacher = new RandomForestLearning()
            {
                NumberOfTrees = NumTrees,
            };
            // Learn a random forest from eeg features
            Predictor.RandomForest = teacher.Learn(PredictorPointsTrain, FrequencyLabelsInt);
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

            // Recieve first n components by setting 
            // NumberOfOutputs to the desired components:
            Predictor.PCA.NumberOfOutputs = NumComponents;
            Predictor.PCA.Learn(data);
            // And then calling transform again:
            PredictorPointsTrain = Predictor.PCA.Transform(data);

        }
       
    }
}
