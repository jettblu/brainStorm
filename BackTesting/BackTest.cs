using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainStorm.EEG;

namespace BrainStorm.BackTesting
{
    public class BackTest
    {
        public event EventHandler<ArrayList> OnBackTestEEGDataRecieved; // back test eeg data
        public event EventHandler<ArrayList> OnBackTestBandDataRecieved; // back test band data
        public bool ClassificationHasStarted = false;
        public const int FrequencyCSVIndex = 4;
        public static int ClassificationFrequency;
        public void HandleRecords(Stream csvStream)
        {   
            Console.WriteLine("Records Opened");
            using (var reader = new StreamReader(csvStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    bool isBand = csv.GetField("AF3 ").Split('/')[0].Contains("null");

                   
                    if (isBand)
                    {
                        if (!csv.GetField("AF3/theta ").Split('/')[FrequencyCSVIndex].Contains("null"))
                        {
                            if (!ClassificationHasStarted)
                            {   
                                Classification.StartProcess();
                                ClassificationHasStarted = true;
                            }
                            ClassificationFrequency = Convert.ToInt32(csv.GetField("AF3/theta ").Split('/')[FrequencyCSVIndex].Trim());
                            
                        }
                        
                        var bandsData = new BackTestBands
                        {
                           
                            AF3Theta = Convert.ToDouble(csv.GetField("AF3/theta ").Split('/')[0]),
                            F7Theta = Convert.ToDouble(csv.GetField("F7/theta ").Split('/')[0]),
                            F3Theta = Convert.ToDouble(csv.GetField("F3/theta ").Split('/')[0]),
                            FC5Theta = Convert.ToDouble(csv.GetField("FC5/theta ").Split('/')[0]),
                            T7Theta = Convert.ToDouble(csv.GetField("T7/theta ").Split('/')[0]),
                            P7Theta = Convert.ToDouble(csv.GetField("P7/theta ").Split('/')[0]),
                            O1Theta = Convert.ToDouble(csv.GetField("O1/theta ").Split('/')[0]),
                            O2Theta = Convert.ToDouble(csv.GetField("O2/theta ").Split('/')[0]),
                            P8Theta = Convert.ToDouble(csv.GetField("P8/theta ").Split('/')[0]),
                            T8Theta = Convert.ToDouble(csv.GetField("T8/theta ").Split('/')[0]),
                            FC6Theta = Convert.ToDouble(csv.GetField("FC6/theta ").Split('/')[0]),
                            F4Theta = Convert.ToDouble(csv.GetField("F4/theta ").Split('/')[0]),
                            F8Theta = Convert.ToDouble(csv.GetField("AF3/theta ").Split('/')[0]),
                            AF4Theta = Convert.ToDouble(csv.GetField("AF4/theta ").Split('/')[0]),

                            AF3Alpha = Convert.ToDouble(csv.GetField("AF3/alpha ").Split('/')[0]),
                            F7Alpha = Convert.ToDouble(csv.GetField("F7/alpha ").Split('/')[0]),
                            F3Alpha = Convert.ToDouble(csv.GetField("F3/alpha ").Split('/')[0]),
                            FC5Alpha = Convert.ToDouble(csv.GetField("FC5/alpha ").Split('/')[0]),
                            T7Alpha = Convert.ToDouble(csv.GetField("T7/alpha ").Split('/')[0]),
                            P7Alpha = Convert.ToDouble(csv.GetField("P7/alpha ").Split('/')[0]),
                            O1Alpha = Convert.ToDouble(csv.GetField("O1/alpha ").Split('/')[0]),
                            O2Alpha = Convert.ToDouble(csv.GetField("O2/alpha ").Split('/')[0]),
                            P8Alpha = Convert.ToDouble(csv.GetField("P8/alpha ").Split('/')[0]),
                            T8Alpha = Convert.ToDouble(csv.GetField("T8/alpha ").Split('/')[0]),
                            FC6Alpha = Convert.ToDouble(csv.GetField("FC6/alpha ").Split('/')[0]),
                            F4Alpha = Convert.ToDouble(csv.GetField("F4/alpha ").Split('/')[0]),
                            F8Alpha = Convert.ToDouble(csv.GetField("AF3/alpha ").Split('/')[0]),
                            AF4Alpha = Convert.ToDouble(csv.GetField("AF4/alpha ").Split('/')[0]),

                            AF3BetaL = Convert.ToDouble(csv.GetField("AF3/betaL ").Split('/')[0]),
                            F7BetaL = Convert.ToDouble(csv.GetField("F7/betaL ").Split('/')[0]),
                            F3BetaL = Convert.ToDouble(csv.GetField("F3/betaL ").Split('/')[0]),
                            FC5BetaL = Convert.ToDouble(csv.GetField("FC5/betaL ").Split('/')[0]),
                            T7BetaL = Convert.ToDouble(csv.GetField("T7/betaL ").Split('/')[0]),
                            P7BetaL = Convert.ToDouble(csv.GetField("P7/betaL ").Split('/')[0]),
                            O1BetaL = Convert.ToDouble(csv.GetField("O1/betaL ").Split('/')[0]),
                            O2BetaL = Convert.ToDouble(csv.GetField("O2/betaL ").Split('/')[0]),
                            P8BetaL = Convert.ToDouble(csv.GetField("P8/betaL ").Split('/')[0]),
                            T8BetaL = Convert.ToDouble(csv.GetField("T8/betaL ").Split('/')[0]),
                            FC6BetaL = Convert.ToDouble(csv.GetField("FC6/betaL ").Split('/')[0]),
                            F4BetaL = Convert.ToDouble(csv.GetField("F4/betaL ").Split('/')[0]),
                            F8BetaL = Convert.ToDouble(csv.GetField("AF3/betaL ").Split('/')[0]),
                            AF4BetaL = Convert.ToDouble(csv.GetField("AF4/betaL ").Split('/')[0]),

                            AF3BetaH = Convert.ToDouble(csv.GetField("AF3/betaH ").Split('/')[0]),
                            F7BetaH = Convert.ToDouble(csv.GetField("F7/betaH ").Split('/')[0]),
                            F3BetaH = Convert.ToDouble(csv.GetField("F3/betaH ").Split('/')[0]),
                            FC5BetaH = Convert.ToDouble(csv.GetField("FC5/betaH ").Split('/')[0]),
                            T7BetaH = Convert.ToDouble(csv.GetField("T7/betaH ").Split('/')[0]),
                            P7BetaH = Convert.ToDouble(csv.GetField("P7/betaH ").Split('/')[0]),
                            O1BetaH = Convert.ToDouble(csv.GetField("O1/betaH ").Split('/')[0]),
                            O2BetaH = Convert.ToDouble(csv.GetField("O2/betaH ").Split('/')[0]),
                            P8BetaH = Convert.ToDouble(csv.GetField("P8/betaH ").Split('/')[0]),
                            T8BetaH = Convert.ToDouble(csv.GetField("T8/betaH ").Split('/')[0]),
                            FC6BetaH = Convert.ToDouble(csv.GetField("FC6/betaH ").Split('/')[0]),
                            F4BetaH = Convert.ToDouble(csv.GetField("F4/betaH ").Split('/')[0]),
                            F8BetaH = Convert.ToDouble(csv.GetField("AF3/betaH ").Split('/')[0]),
                            AF4BetaH = Convert.ToDouble(csv.GetField("AF4/betaH ").Split('/')[0]),

                            AF3Gamma = Convert.ToDouble(csv.GetField("AF3/gamma ").Split('/')[0]),
                            F7Gamma = Convert.ToDouble(csv.GetField("F7/gamma ").Split('/')[0]),
                            F3Gamma = Convert.ToDouble(csv.GetField("F3/gamma ").Split('/')[0]),
                            FC5Gamma = Convert.ToDouble(csv.GetField("T7/gamma ").Split('/')[0]),
                            P7Gamma = Convert.ToDouble(csv.GetField("P7/gamma ").Split('/')[0]),
                            O1Gamma = Convert.ToDouble(csv.GetField("O1/gamma ").Split('/')[0]),
                            O2Gamma = Convert.ToDouble(csv.GetField("O2/gamma ").Split('/')[0]),
                            P8Gamma = Convert.ToDouble(csv.GetField("P8/gamma ").Split('/')[0]),
                            T8Gamma = Convert.ToDouble(csv.GetField("T8/gamma ").Split('/')[0]),
                            FC6Gamma = Convert.ToDouble(csv.GetField("FC6/gamma ").Split('/')[0]),
                            F4Gamma = Convert.ToDouble(csv.GetField("F4/gamma ").Split('/')[0]),
                            F8Gamma = Convert.ToDouble(csv.GetField("AF3/gamma ").Split('/')[0]),
                            AF4Gamma = Convert.ToDouble(csv.GetField("AF4/gamma ").Split('/')[0]),

                        };
                        bandsData.CreateEventData();
                        OnBackTestBandDataRecieved(this, bandsData.RawData);
                    }
                    else
                    {
                        if (!csv.GetField("AF3 ").Split('/')[FrequencyCSVIndex].Contains("null"))
                        {
                            if (!ClassificationHasStarted)
                            {
                                Classification.StartProcess();
                                ClassificationHasStarted = true;
                            }
                            ClassificationFrequency =
                                Convert.ToInt32(csv.GetField("AF3 ").Split('/')[FrequencyCSVIndex].Trim());
                        }

                        var rawEEGData = new BackTestEEGRaw
                        {

                            AF3Raw = Convert.ToDouble(csv.GetField("AF3 ").Split('/')[0]),
                            F7Raw = Convert.ToDouble(csv.GetField("F7 ").Split('/')[0]),
                            F3Raw = Convert.ToDouble(csv.GetField("F3 ").Split('/')[0]),
                            FC5Raw = Convert.ToDouble(csv.GetField("FC5 ").Split('/')[0]),
                            T7Raw = Convert.ToDouble(csv.GetField("T7 ").Split('/')[0]),
                            P7Raw = Convert.ToDouble(csv.GetField("P7 ").Split('/')[0]),
                            O1Raw = Convert.ToDouble(csv.GetField("O1 ").Split('/')[0]),
                            O2Raw = Convert.ToDouble(csv.GetField("O2 ").Split('/')[0]),
                            P8Raw = Convert.ToDouble(csv.GetField("P8 ").Split('/')[0]),
                            T8Raw = Convert.ToDouble(csv.GetField("T8 ").Split('/')[0]),
                            FC6Raw = Convert.ToDouble(csv.GetField("FC6 ").Split('/')[0]),
                            F4Raw = Convert.ToDouble(csv.GetField("F4 ").Split('/')[0]),
                            F8Raw = Convert.ToDouble(csv.GetField("AF3 ").Split('/')[0]),
                            AF4Raw = Convert.ToDouble(csv.GetField("AF4 ").Split('/')[0]),

                        };
                        rawEEGData.CreateEventData();
                        OnBackTestEEGDataRecieved(this, rawEEGData.RawData);
                    }


                }
            }
            // indicate back test is complete
            SignalProcessor.IsBackTest = false;
        }
    }
}
