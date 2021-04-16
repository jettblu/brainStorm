using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm.EEG
{
    class EEGData
    {
        // last mean calculated.. unique to each sensor stream
        public double MovingAvg { get; set; }
        // last standard deviation calculated.. unique to each sensor stream
        public double MovingStd { get; set; }
        // decision bounds used to classify whther or not this point was a peak
        public double UpperBound { get; set; }
        public double LowerBound { get; set; }

        // all data points in window
        public List<double> WindowValues = new List<double>();
    }
}
