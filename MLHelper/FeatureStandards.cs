using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm.MLHelper
{
    class FeatureStandards
    {
        public double StandardDeviation { get; set; }
        public double Mean { get; set; }

        public FeatureStandards(double mean, double stdDev)
        {
            Mean = mean;
            StandardDeviation = stdDev;
        }
    }
}
