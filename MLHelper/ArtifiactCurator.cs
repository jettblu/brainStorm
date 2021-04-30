using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm.MLHelper
{
    class ArtifiactCurator
    {
        public static bool PeakWasLast = false;
        public static int PeakStreak = 0;
        public static int StreakThreshold { get; set; }

        public ArtifiactCurator(int streakThreshold = 4)
        {
            StreakThreshold = streakThreshold;
        }

        public bool IsArtifact(bool CurrPeak)
        {
            if (CurrPeak)
            {
                PeakStreak += 1;
                PeakWasLast = true;
            }

            else
            {
                PeakStreak = 0;
                PeakWasLast = false;
            }
            return (PeakStreak > StreakThreshold);
        }
    }
}
