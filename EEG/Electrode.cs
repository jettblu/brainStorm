using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm.EEG
{
    class Electrode
    {
        //file stream for peak detection plotting
        public static FileStream OutFileStreamPeak { get; set; }
        // filestream writer for peak file stream
        public static StreamWriter StreamWriterPeak { get; set; }

        public static string HeaderPeak =
            "AF3/Std,F7/Std,F3/Std,FC5/Std,T7/Std,P7/Std,O1/Std,O2/Std,P8/Std,T8/Std,FC6/Std,F4/Std,F8,AF4";


        // how far we look back to smooth data
        public static int WindowSizeEEG { get; set; }
        // value b/ween 0 & 1 indicating how much influence peaks have on calaculations
        public static double InfluenceEEG { get; set; }

        // number of standard deviations away at which algorithm hits
        public static double ZThresholdEEG { get; set; }

        // .........parameters for band data...........
        public static int WindowSizeBand { get; set; }
        // value b/ween 0 & 1 indicating how much influence peaks have on calaculations
        public static double InfluenceBand { get; set; }

        // number of standard deviations away at which algorithm hits
        public static double ZThresholdBand { get; set; }
        // mark if preload or not
        public static bool IsEEGPreLoad = true;

        public static bool IsBandPreload = true;


        public string Name { get; set; }
        public EEGData EEGRaw { get; set; }
        // frequency bands provided by Emotiv... calculated twice per second w/ 2 second window
        // 4-8 Hz
        public EEGData Theta { get; set; }
        // 8-12 Hz
        public EEGData Alpha { get; set; }
        // 12-18 Hz
        public EEGData BetaL { get; set; }
        //18-25 Hz
        public EEGData BetaH { get; set; }
        // Greater than 25 Hz
        public EEGData Gamma { get; set; }



        public Electrode(string name, int windowSizeEEG = 180, double influenceEEG = .2, double zThresholdEEG = 3.5, int windowSizeBand = 10, double influenceBand = 0, double zThresholdBand = 3.5)
        {
            Name = name;
            // set electrode parameters
            WindowSizeEEG = windowSizeEEG;
            InfluenceEEG = influenceEEG;
            ZThresholdEEG = zThresholdEEG;
            // band data parameters
            WindowSizeBand = windowSizeBand;
            InfluenceBand = influenceBand;
            ZThresholdBand = zThresholdBand;
            // initialize eeg data containers
            EEGRaw = new EEGData();
            Theta = new EEGData();
            Alpha = new EEGData();
            BetaL = new EEGData();
            BetaH = new EEGData();
            Gamma = new EEGData();
        }

        // recieves historical data and current data point (cld. be band or raw signal) as input
        // indicates whether current data point represents a peak as output
        public static bool hasPeak(EEGData eegData, double currSignal, bool isBand = false)
        {
            int windowSizePeak = new int();
            double influencePeak = new double();
            double zThresholdPeak = new double();

            // change parameters based on whether band or raw eeg
            if (isBand)
            {
                windowSizePeak = WindowSizeBand;
                influencePeak = InfluenceBand;
                zThresholdPeak = ZThresholdBand;
            }
            else
            {
                windowSizePeak = WindowSizeEEG;
                influencePeak = InfluenceEEG;
                zThresholdPeak = ZThresholdEEG;
            }

            var isPeak = false;

            // if preload still needs to occur
            if (eegData.WindowValues.Count < windowSizePeak)
            {
                eegData.WindowValues.Add(currSignal);
                // calculate window average
                eegData.MovingAvg = eegData.WindowValues.Average();
                // calculate window standard deviation
                eegData.MovingStd = Math.Sqrt(eegData.WindowValues.Average(v => Math.Pow(v - eegData.MovingAvg, 2)));
                return false;
            }
            // indicate preload is done
            else
            {
                if (isBand) IsBandPreload = false;
                else IsEEGPreLoad = false;
            }
            // set decision boundaries for file write
            eegData.UpperBound = eegData.MovingAvg + (zThresholdPeak * eegData.MovingStd);
            eegData.LowerBound = eegData.MovingAvg - (zThresholdPeak * eegData.MovingStd);
            // if extreme
            if (Math.Abs(currSignal - eegData.MovingAvg) > zThresholdPeak * eegData.MovingStd)
            {
                // if peak
                if (currSignal > eegData.MovingAvg)
                {
                    // set last value of window equal to current value
                    currSignal = influencePeak * currSignal + (1 - influencePeak) * currSignal;
                    isPeak = true;
                }


            }
            // set last value of window equal to current value after removing old data
            eegData.WindowValues.RemoveAt(0);
            eegData.WindowValues.Add(currSignal);
            // calculate window average
            eegData.MovingAvg = eegData.WindowValues.Average();
            // calculate window standard deviation
            eegData.MovingStd = Math.Sqrt(eegData.WindowValues.Average(v => Math.Pow(v - eegData.MovingAvg, 2)));
            return isPeak;
        }

    }
}
