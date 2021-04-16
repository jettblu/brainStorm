using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BrainStorm.EEG
{
    class SignalProcessor
    {
        // number of electrodes on EPOC X
        private const int NumberElectrodes = 14;
        // additional calculations
        // EEG RAW std.
        public const string HeaderAddons = "AF3/std,F7/std,F3/std,FC5/std,T7/std,P7/std,O1/std,O2/std,P8/std,T8/std,FC6/std,F4/std,F8/std,AF4/std";
        // offset for eeg nulls
        public static int BandPowerNullsOffset { get; set; }
        // offset for band nulls
        public static int EEGNullsOffset { get; set; }
        // output file stream
        public static FileStream OutFileStream { get; set; }
        public static StreamWriter Fw { get; set; }
        public static Dictionary<string, Electrode> Electrodes = new Dictionary<string, Electrode>();
        // electrodes on epoch x headset
        public static List<string> ElectrodeNames = "AF3,F7,F3,FC5,T7,P7,O1,O2,P8,T8,FC6,F4,F8,AF4".Split(',').ToList();
        // freq. band names
        public static List<string> FreqBandNames { get; set; }



        // establishes csv header. Assumes eeg is added to data stream before band power.
        public static void setHeader(object sender, Dictionary<string, JArray> e)
        {
            CreateElectrodes();
            Fw = new StreamWriter(OutFileStream);
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
                }
                header.AddRange(e[key].ToObject<ArrayList>());
            }
            header.Insert(0, "Timestamp");
            // add standard deviation labels to header
            // header.AddRange(HeaderAddons.Split(','));
            WriteDataToFile(header, isHeader: true);
        }

        // create electrode instance for each electrode name in list
        private static void CreateElectrodes()
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
                // add nulls for raw eeg values
                if (needsOffset)
                {
                    for (int i = 0; i < BandPowerNullsOffset + 1; i++)
                    {
                        data.Insert(i, "null/null/null/null/null/null");
                    }
                }
                // add nulls for band values
                else
                {
                    for (int i = 0; i < EEGNullsOffset; i++)
                    {
                        data.Insert(BandPowerNullsOffset + i + 1, "null/null/null/null/null/null");
                    }
                }
            }
            var writeData = string.Join(" ,", data.ToArray());
            Fw.WriteLine(writeData);
        }


        public static void OnEEGDataReceived(object sender, ArrayList eegData)
        {
            EEGPeakDetection(eegData);
            WriteDataToFile(eegData);
        }

        // event handler for freq. band data being recieved
        public static void OnBandPowerRecieved(object sender, ArrayList bandData)
        {
            BandPeakDetection(bandData);
            WriteDataToFile(bandData, needsOffset: true);
        }


        public static void EEGPeakDetection(ArrayList eegData)
        {
            //copy current data feed so loop isn't messed up when adding calculations to eegData
            var loopEEGData = eegData;
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
                    //discard peaks from baseline electrodes
                    if (currElectrode.Name != " T7" && currElectrode.Name != " T8")
                    {
                        voteCount += 1;
                        Console.WriteLine(ElectrodeNames[i]);
                        Console.WriteLine("!!!");
                    }
                }

                // add current electrode's moving standard dev. to file output. Mark preload w/ 0.
                if (Electrode.IsEEGPreLoad)
                {
                    dataChunk += $"/null/{dataHasPeak}/null/null/null";
                }
                else
                {
                    dataChunk += $"/{stdDev}/{dataHasPeak}/{currElectrode.EEGRaw.MovingAvg}/{currElectrode.EEGRaw.UpperBound}/{currElectrode.EEGRaw.LowerBound}";
                }
                eegData[dataIndex] = dataChunk;
            }
            if (voteCount >= 3) Console.WriteLine("handle blink 98vi8jvh3jhvujhurhgv3hghgjhjkghr");
            if (voteCount != 0)
            {
                Console.WriteLine(voteCount);
            }
        }

        public static void BandPeakDetection(ArrayList bandData)
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
                    //discard peaks from baseline electrodes
                    if (currElectrode.Name != " T7" && currElectrode.Name != " T8" && bandName == "theta")
                    {

                        voteCount += 1;
                        Console.WriteLine(currElectrode.Name);
                        Console.WriteLine("!!! BANDDD");
                    }
                }


                // add current electrode's moving standard dev. to file output. Mark preload w/ -1.
                if (Electrode.IsBandPreload)
                {
                    dataChunk += $"/null/{dataHasPeak}/null/null/null";
                    bandData[i] = dataChunk;
                }
                else
                {
                    dataChunk += $"/{stdDev}/{dataHasPeak}/{currBand.MovingAvg}/{currBand.UpperBound}/{currBand.LowerBound}";
                    bandData[i] = dataChunk;
                }

            }


            if (voteCount >= 14) Console.WriteLine("handle blink BANDDDDDDDDDDDDDD");
            if (voteCount != 0)
            {
                Console.WriteLine(voteCount);
            }
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
            switch (bandName)
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

