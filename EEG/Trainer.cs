using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainStorm.Graphics;
using MathNet.Numerics;

namespace BrainStorm.EEG
{
    class Trainer:Classification
    {
        public static List<double[]> PredictorPointsTrain  = new List<double[]>();
        public static List<double> FrequencyLabels = new List<double>();

        public static void FitData()
        {
            Predictor.MultipleLinearRegressionFunc = Fit.LinearMultiDimFunc(PredictorPointsTrain.ToArray(), FrequencyLabels.ToArray());
            Console.Write("Multiple LINEAR regression fit succesfully!");
            Predictor.MultipleGeneralRegressionFunc = Fit.MultiDimFunc(PredictorPointsTrain.ToArray(), FrequencyLabels.ToArray(), intercept: false);
            Console.Write("Multiple GENERAL regression fit succesfully!");
        }
       
    }
}
