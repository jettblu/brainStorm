using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainStorm.EEG;

namespace BrainStorm.MLHelper
{
    class ArtifiactCurator
    {
        public static bool PeakWasLast = false;
        public static int PeakStreak = 0;
        public static bool ArtifactWasLast = false;
        public static int ArtifactStreak = 0;
        public static int ArtifactBinMax = SignalProcessor.SamplingRate;
        public static int BinProgress = 0;
        public static int BinArtifactCount = 0;
        public static bool HasFiredThisBin = false;
        public static int PeakStreakThreshold { get; set; }
        public static int ArtifactStreakThreshold { get; set; }
        public static int ArtifactBinThreshold { get; set; }

        public ArtifiactCurator(int peakStreakThreshold = 2, int artifactStreakThresold = 3, int artifactBinThreshold=7)
        {
            PeakStreakThreshold = peakStreakThreshold;
            ArtifactStreakThreshold = artifactStreakThresold;
            ArtifactBinThreshold = artifactBinThreshold;
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
            if (PeakStreak > PeakStreakThreshold)
            {
                PeakStreak = 0;
                PeakWasLast = false;
                return true;
            }
            return false;
        }

        public bool IsArtifactCtrlZ(bool isArtifact)
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

            if (ArtifactStreak > ArtifactStreakThreshold)
            {
                ArtifactStreak = 0;
                ArtifactWasLast = false;
                return true;
            }

            return false;
                
        }

        public bool IsArtifactCtrlZBinned(bool isArtifact)
        {
            BinProgress += 1;
            var result = false;

            if (BinProgress == ArtifactBinMax)
            {
                BinProgress = 0;
                HasFiredThisBin = false;
            }

            if (isArtifact)
            {
                BinArtifactCount += 1;
            } 

            if (!HasFiredThisBin && (BinArtifactCount > ArtifactBinThreshold))
            {
                result = true;
                HasFiredThisBin = true;
                BinArtifactCount = 0;
            }

            return result;
        }
    }
}
