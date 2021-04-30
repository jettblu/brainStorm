using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm.BackTesting
{
    class BackTestEEGRaw
    {
        public double AF3Raw { get; set; }

        public double F7Raw { get; set; }

        public double F3Raw { get; set; }

        public double FC5Raw { get; set; }

        public double T7Raw { get; set; }

        public double P7Raw { get; set; }

        public double O1Raw { get; set; }

        public double O2Raw { get; set; }

        public double P8Raw { get; set; }

        public double T8Raw { get; set; }

        public double FC6Raw { get; set; }

        public double F4Raw { get; set; }
        public double F8Raw { get; set; }


        public double AF4Raw { get; set; }
        public ArrayList RawData = new ArrayList();


        public void CreateEventData()
        {   
            // clear list of previous values
            RawData.Clear();
            // add dummy values in first three col.s to simulate real data feed
            RawData.Add(89);
            RawData.Add(89);
            RawData.Add(89);
            RawData.Add(AF3Raw);
            RawData.Add(F7Raw);
            RawData.Add(F3Raw);
            RawData.Add(FC5Raw);
            RawData.Add(T7Raw);
            RawData.Add(P7Raw);
            RawData.Add(O1Raw);
            RawData.Add(O2Raw);
            RawData.Add(P8Raw);
            RawData.Add(T8Raw);
            RawData.Add(FC6Raw);
            RawData.Add(F4Raw);
            RawData.Add(F8Raw);
            RawData.Add(AF4Raw);
            // add dummy values in last three col.s to simulate real data feed
            RawData.Add(89);
            RawData.Add(89);
            RawData.Add(89);
        }
    }
}
