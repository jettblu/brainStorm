using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public static string BasePath = Properties.Settings.Default.BasePath;
        public static string OutFilePath = BasePath + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv";
        public const string licenseID = "bccbbd9b-1a8c-47c4-a3a9-bbf340ff9e0b";
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

            SignalProcessor.OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);


            DataStream dse = new DataStream();
            dse.AddStreams("eeg");     // You can add more streams to subscribe multiple streams
            dse.AddStreams("pow");
            dse.OnSubscribed += SignalProcessor.setHeader;
            dse.OnEEGDataReceived += SignalProcessor.OnEEGDataReceived;
            dse.OnBandPowerDataReceived += SignalProcessor.OnBandPowerRecieved;


            // Need a valid license key and activeSession when subscribe eeg data
            dse.Start(licenseID, true);

            Console.WriteLine("Press Esc to flush data to file and exit");
            // form thread
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // keep recording eeg data until class prop is changed to false
            new Thread(() =>
                {
                    while (KeepRecording) { }
                    
                        // Unsubcribe stream
                        dse.UnSubscribe();
                        Thread.Sleep(5000);

                        // Close Session
                        dse.CloseSession();
                        Thread.Sleep(5000);
                        // Close Out Stream
                        SignalProcessor.OutFileStream.Dispose();

                })
                { IsBackground = true}.Start();
        }
     
    }
}
