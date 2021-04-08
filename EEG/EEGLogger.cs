using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BrainStorm.CortexAccess;
using Newtonsoft.Json.Linq;

namespace BrainStorm.EEG
{   
    class EEGLogger
    {   
        //generate a unique file name to save data to
        static string OutFilePath = "C:\\Users\\jett2\\Documents\\test\\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv";
        const string licenseID = "bccbbd9b-1a8c-47c4-a3a9-bbf340ff9e0b";
        private static FileStream OutFileStream;
        public static bool KeepRecording = true;


        public static async void startLog()
        {   

            Console.WriteLine("EEG LOGGER");
            Console.WriteLine("Please wear Headset with good signal!!!");

            // Delete Output file if existed
            if (File.Exists(OutFilePath))
            {
                File.Delete(OutFilePath);
            }
            OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);


            DataStreamExample dse = new DataStreamExample();
            dse.AddStreams("eeg");                          // You can add more streams to subscribe multiple streams
            dse.OnSubscribed += SubscribedOK;
            dse.OnEEGDataReceived += OnEEGDataReceived;

            // Need a valid license key and activeSession when subscribe eeg data
            dse.Start(licenseID, true);

            Console.WriteLine("Press Esc to flush data to file and exit");
            // keep recording eeg data until class prop is changed to false
            while (KeepRecording) { }

            // Unsubcribe stream
            dse.UnSubscribe();
            Thread.Sleep(5000);

            // Close Session
            dse.CloseSession();
            Thread.Sleep(5000);
            // Close Out Stream
            OutFileStream.Dispose();
        }
        private static void SubscribedOK(object sender, Dictionary<string, JArray> e)
        {
            foreach (string key in e.Keys)
            {
                if (key == "eeg")
                {
                    // print header
                    ArrayList header = e[key].ToObject<ArrayList>();
                    //add timeStamp to header
                    header.Insert(0, "Timestamp");
                    WriteDataToFile(header);
                }
            }
        }

        // Write Header and Data to File
        private static void WriteDataToFile(ArrayList data)
        {
            int i = 0;
            for (; i < data.Count - 1; i++)
            {
                byte[] val = Encoding.UTF8.GetBytes(data[i].ToString() + ", ");

                if (OutFileStream != null)
                    OutFileStream.Write(val, 0, val.Length);
                else
                    break;
            }
            // Last element
            byte[] lastVal = Encoding.UTF8.GetBytes(data[i].ToString() + "\n");
            // write to file if file is valid and writing is specified
            if (OutFileStream != null)
                OutFileStream.Write(lastVal, 0, lastVal.Length);
        }

        private static void OnEEGDataReceived(object sender, ArrayList eegData)
        {
            WriteDataToFile(eegData);
        }
    }
}
