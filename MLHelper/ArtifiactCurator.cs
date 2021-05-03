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
        public static bool ArtifactWasLast = false;
        public static int ArtifactStreak = 0;
        public static int PeakStreakThreshold { get; set; }
        public static int ArtifactStreakThreshold { get; set; }

        public ArtifiactCurator(int peakStreakThreshold = 4, int artifactThresold = 3)
        {
            PeakStreakThreshold = peakStreakThreshold;
            ArtifactStreakThreshold = artifactThresold;
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
            return (PeakStreak > PeakStreakThreshold);
        }

        public bool IsArtifactSend(bool isArtifact)
        {
            if (isArtifact)
            {
                ArtifactStreak += 1;
                ArtifactWasLast = true;
            }
            else
            {
                ArtifactStreak = 0;
                ArtifactWasLast = false;
            }
            return ArtifactStreak > ArtifactStreakThreshold;
        }
    }
}
