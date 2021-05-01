using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using BrainStorm.CortexAccess;
using BrainStorm.MLHelper;
using Newtonsoft.Json.Linq;

namespace BrainStorm.EEG
{
    class SignalProcessor
    {
        public const int SamplingRate = 128;
        // nulls to insert into empty data cells for output file
        private const string OffsetNulls = "null/null/null/null/null/null";
        // number of electrodes on EPOC X
        private const int NumberElectrodes = 14;
        // additional calculations
        // EEG RAW std.
        public const string HeaderAddons = "AF3/std,F7/std,F3/std,FC5/std,T7/std,P7/std,O1/std,O2/std,P8/std,T8/std,FC6/std,F4/std,F8/std,AF4/std";
        // offset for eeg nulls
        public static int BandPowerNullsOffset { get; set; }
        // offset for band nulls
        public static int EEGNullsOffset { get; set; }
        // output file streams... all data & train data
        public static FileStream OutFileStream { get; set; }
        public static FileStream TrainFileStream { get; set; }
        public static StreamWriter FwAll { get; set; }
        public static Dictionary<string, Electrode> Electrodes = new Dictionary<string, Electrode>();
        // electrodes on epoch x headset
        public static List<string> ElectrodeNames = "AF3,F7,F3,FC5,T7,P7,O1,O2,P8,T8,FC6,F4,F8,AF4".Split(',').ToList();
        // freq. band names
        public static List<string> FreqBandNames { get; set; }
        // # of electrodes needed to fire for event to be considered an artifact... hardcoded
        public const int ArtifactThresholdEEG = 3;
        public static ArtifiactCurator ArtifactManager = new ArtifiactCurator();
        public static bool IsBackTest = false;
   
 


        // establishes csv header. Assumes eeg is added to data stream before band power.
        public static void SetHeaderAll(object sender, Dictionary<string, JArray> e)
        {
            CreateElectrodes();
            // initialize file stream writers
            FwAll = new StreamWriter(OutFileStream);

            ArrayList header = new ArrayList();
            foreach (string key in e.Keys)
            {
                if (key == "eeg")
                {
                    Console.WriteLine(String.Join(", ", e[key]));
                    // sets offset for freq. data... allows for seperation b/ween streams in csv file
                    BandPowerNullsOffset = e[key].Count;
                }
                if (key == "pow")
                {
                    // set names for each power band
                    FreqBandNames = e[key].ToObject<ArrayList>().Cast<string>().ToList();
                    EEGNullsOffset = e[key].Count;
                    SetClassificationIndices();
                }
                header.AddRange(e[key].ToObject<ArrayList>());
            }
            header.Insert(0, "Timestamp");
            // add standard deviation labels to header
            // header.AddRange(HeaderAddons.Split(','));
            WriteDataToFile(header, isHeader: true);
        }

        public static void SetClassificationIndices()
        {
            var currIndex = 0;
            foreach (var bandName in FreqBandNames)
            {
                // add electrode index to classification indices if specified
                if (Classification.ClassificationElectrodes.Any(electrodeName => bandName.Contains(electrodeName)))
                {
                    Classification.ClassificationElectrodesIndices.Add(currIndex);
                }
                currIndex += 1;
            }
        }
        // create electrode instance for each electrode name in list
        public static void CreateElectrodes()
        {
            foreach (var name in ElectrodeNames)
            {
                var electrode = new Electrode(name);
                Electrodes[name] = electrode;
            }
        }
        // Write Header and Data to File
        private static void WriteDataToFile(ArrayList data, bool needsOffset = false, bool isHeader = false)
        {
            //don't add nulls if writing header
            if (!isHeader)
            {   
                //CollectEEGSample(data);
                // add nulls for raw eeg values
                if (needsOffset)
                {
                    for (int i = 0; i < BandPowerNullsOffset + 1; i++)
                    {
                        data.Insert(i, OffsetNulls);
                    }
                }
                // add nulls for band values
                else
                {
                    for (int i = 0; i < EEGNullsOffset; i++)
                    {
                        data.Insert(BandPowerNullsOffset + i + 1, OffsetNulls);
                    }
                }
            }
            var writeData = string.Join(" ,", data.ToArray());
            FwAll.WriteLine(writeData);
        }

        // grab data points that we want to use for training
        private static void CollectEEGSample(ArrayList data)
        {   
            // only add sample that is pure and includes both frequency and band power
            if (Classification.IsRunning && Classification.IsPure && !data.Contains(OffsetNulls))
            {
                // exclude metadata attached to RawEEG

               
            }
        }

        public static void OnEEGDataReceived(object sender, ArrayList eegData)
        {
            var trainingFreq = HandleClassificationEEG();
            EEGPeakDetection(eegData, trainingFreq);
            // don't write data to file if running historical data
            if (IsBackTest) return;
            WriteDataToFile(eegData);
        }

        // event handler for freq. band data being recieved
        public static void OnBandPowerRecieved(object sender, ArrayList bandData)
        {
            var trainingFreq = HandleClassificationBand(bandData);
            BandPeakDetection(bandData, trainingFreq);
            // don't write data to file if running historical data
            if (IsBackTest) return;
            WriteDataToFile(bandData, needsOffset: true);
        }


        public static void EEGPeakDetection(ArrayList eegData, string trainingFreq)
        {
            //copy current data feed so loop isn't messed up when adding calculations to eegData
            var loopEEGData = eegData;
            //vote count for blink decisions
            var voteCount = 0;
           

            for (int i = 0; i < NumberElectrodes; i++)
            {
                var currElectrode = GetElectrodeByName(ElectrodeNames[i]);
                // i+3... because 2 is index where electrode data starts
                var dataIndex = i + 3;

                var dataChunk = loopEEGData[dataIndex].ToString().Trim();
                var dataHasPeak = "false";

                var stdDev = currElectrode.EEGRaw.MovingStd;
                if (Electrode.hasPeak(currElectrode.EEGRaw, Convert.ToDouble(loopEEGData[dataIndex])))
                {
                    dataHasPeak = "true";
                    voteCount += 1;
                    // uncomment to indicate which electrode fired
                   /* Console.WriteLine(ElectrodeNames[i]);
                    Console.WriteLine("!!!");*/
                }

                // add current electrode's moving standard dev. to file output. Mark preload w/ 0.
                if (Electrode.IsEEGPreLoad)
                {
                    dataChunk += $"/null/{dataHasPeak}/null/null/null/{trainingFreq}";
                }
                else
                {
                    dataChunk += $"/{stdDev}/{dataHasPeak}/{currElectrode.EEGRaw.MovingAvg}/{currElectrode.EEGRaw.UpperBound}/{currElectrode.EEGRaw.LowerBound}/{trainingFreq}";
                }
                eegData[dataIndex] = dataChunk;
            }

            // artifact detection
            var isArtifact = ArtifactManager.IsArtifact(CurrPeak: voteCount >= ArtifactThresholdEEG);
            if (isArtifact)
            {
                Console.WriteLine("--------- Artifact Detected -------------");
            }
        }


        public static string HandleClassificationEEG()
        {
            var trainingFreq = "null";

            if (Classification.IsRunning)
            {
                // increment eegDataCount
                Classification.EEGDataCount += 1;
                // add label to data if training and pure
                if (Classification.IsPure && Classification.IsTraining)
                {
                    trainingFreq = $"{BrainStorm0.ClassificationShape.Hertz}";
                }
            }
            return trainingFreq;
        }

        public static string HandleClassificationBand(ArrayList bandData)
        {
            List<double> currPredictorPoints = new List<double>();
            var trainingFreq = "null";
            // add label to data if training and pure
            if (Classification.IsRunning && Classification.IsPure)
            {

                //exclude first element of band data
                for (int i = 1; i < bandData.Count; i++)
                {
                    currPredictorPoints.Add(Convert.ToDouble(bandData[i]));
                }

                // update classification parameters depending on whther training or predicting
                currPredictorPoints = Classification.FilterBands(currPredictorPoints);
                if (Classification.IsTraining)
                {
                    trainingFreq = $"{BrainStorm0.ClassificationShape.Hertz}";
                    // add current data sample
                    Trainer.PredictorPointsTrainRaw.Add(currPredictorPoints.ToArray());
                    // add current frequency as label for above sample
                    Trainer.FrequencyLabelsRaw.Add(Convert.ToDouble(BrainStorm0.ClassificationShape.Hertz));
                }
                if (Classification.IsValidation)
                {   
                    Predictor.CurrPredictionPoints = currPredictorPoints.ToArray();
                    Predictor.MakePrediction();
                }

                Classification.NumSamples += 1;
            }
            return trainingFreq;
        }

        public static void BandPeakDetection(ArrayList bandData, string trainingFreq)
        {
            
            bandData.RemoveAt(0);
            var voteCount = 0;
            
            for (int i = 0; i < FreqBandNames.Count; i++)
            {
                // band data header is output in the following format: (electrode name)/(band type)
                var dataIndex = i;
                var nameParts = FreqBandNames[i].Split('/');
                var currElectrode = GetElectrodeByName(nameParts[0]);
                var bandName = nameParts[1];
                var currBand = GetBandByName(bandName, currElectrode);

                var dataChunk = bandData[dataIndex].ToString().Trim();
                var dataHasPeak = "false";
                var stdDev = currBand.MovingStd;

                if (Electrode.hasPeak(currBand, Convert.ToDouble(bandData[dataIndex]), isBand: true))
                {
                        dataHasPeak = "true";
                        voteCount += 1;
                    // uncoment to indicate which electrode band fired
   /*                   Console.WriteLine(currElectrode.Name);
                        Console.WriteLine("!!! BANDDD");*/
                }


                // add current electrode's moving standard dev. to file output. Mark preload w/ -1.
                if (Electrode.IsBandPreload)
                {
                    dataChunk += $"/null/{dataHasPeak}/null/null/null/{trainingFreq}";
                    bandData[i] = dataChunk;
                }
                else
                {
                    dataChunk += $"/{stdDev}/{dataHasPeak}/{currBand.MovingAvg}/{currBand.UpperBound}/{currBand.LowerBound}/{trainingFreq}";
                    bandData[i] = dataChunk;
                }

            }


            if (voteCount >= 35) Console.WriteLine($"Hnadle Blink BAND: {voteCount} Votes");
        }

        // helper function that returns current electrode
        public static Electrode GetElectrodeByName(string name)
        {
            return Electrodes[name];
        }


        // helper function that returns current electrode
        public static EEGData GetBandByName(string bandName, Electrode currElectrode)
        {
            // grab relevant eeg data
            switch (bandName.Trim())
            {
                case "theta":
                    return currElectrode.Theta;
                case "alpha":
                    return currElectrode.Alpha;
                case "betaL":
                    return currElectrode.BetaL;
                case "betaH":
                    return currElectrode.BetaH;
                case "gamma":
                    return currElectrode.Gamma;
            }
            // if band matches none of the above types
            return null;
        }
    }
}

