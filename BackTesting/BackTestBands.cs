using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrainStorm.EEG;

namespace BrainStorm.BackTesting
{
    class BackTestBands
    {
        public double AF3Theta { get; set; }
        public double AF3Alpha { get; set; }
        public double AF3BetaL { get; set; }
        public double AF3BetaH { get; set; }
        public double AF3Gamma { get; set; }

        public double F7Theta { get; set; }
        public double F7Alpha { get; set; }
        public double F7BetaL { get; set; }
        public double F7BetaH { get; set; }
        public double F7Gamma { get; set; }

        public double F3Theta { get; set; }
        public double F3Alpha { get; set; }
        public double F3BetaL { get; set; }
        public double F3BetaH { get; set; }
        public double F3Gamma { get; set; }

        public double FC5Theta { get; set; }
        public double FC5Alpha { get; set; }
        public double FC5BetaL { get; set; }
        public double FC5BetaH { get; set; }
        public double FC5Gamma { get; set; }

        public double T7Theta { get; set; }
        public double T7Alpha { get; set; }
        public double T7BetaL { get; set; }
        public double T7BetaH { get; set; }
        public double T7Gamma { get; set; }

        public double P7Theta { get; set; }
        public double P7Alpha { get; set; }
        public double P7BetaL { get; set; }
        public double P7BetaH { get; set; }
        public double P7Gamma { get; set; }

        public double O1Theta { get; set; }
        public double O1Alpha { get; set; }
        public double O1BetaL { get; set; }
        public double O1BetaH { get; set; }
        public double O1Gamma { get; set; }

        public double O2Theta { get; set; }
        public double O2Alpha { get; set; }
        public double O2BetaL { get; set; }
        public double O2BetaH { get; set; }
        public double O2Gamma { get; set; }

        public double P8Theta { get; set; }
        public double P8Alpha { get; set; }
        public double P8BetaL { get; set; }
        public double P8BetaH { get; set; }
        public double P8Gamma { get; set; }

        public double T8Theta { get; set; }
        public double T8Alpha { get; set; }
        public double T8BetaL { get; set; }
        public double T8BetaH { get; set; }
        public double T8Gamma { get; set; }

        public double FC6Theta { get; set; }
        public double FC6Alpha { get; set; }
        public double FC6BetaL { get; set; }
        public double FC6BetaH { get; set; }
        public double FC6Gamma { get; set; }

        public double F4Theta { get; set; }
        public double F4Alpha { get; set; }
        public double F4BetaL { get; set; }
        public double F4BetaH { get; set; }
        public double F4Gamma { get; set; }

        public double F8Theta { get; set; }
        public double F8Alpha { get; set; }
        public double F8BetaL { get; set; }
        public double F8BetaH { get; set; }
        public double F8Gamma { get; set; }


        public double AF4Theta { get; set; }
        public double AF4Alpha { get; set; }
        public double AF4BetaL { get; set; }
        public double AF4BetaH { get; set; }
        public double AF4Gamma { get; set; }

        public ArrayList RawData = new ArrayList();


        public void CreateEventData()
        {   
            // clear old data
            RawData.Clear();
            // add dummy value in first col. to simulate real data feed
            RawData.Add(89);
            // we hardcode the additions, so order is preserved
            RawData.Add(AF3Theta);
            RawData.Add(AF3Alpha);
            RawData.Add(AF3BetaL);
            RawData.Add(AF3BetaH);
            RawData.Add(AF3Gamma);
           
            RawData.Add(F7Theta);
            RawData.Add(F7Alpha);
            RawData.Add(F7BetaL);
            RawData.Add(F7BetaH);
            RawData.Add(F7Gamma);
        
            RawData.Add(F3Theta);
            RawData.Add(F3Alpha);
            RawData.Add(F3BetaL);
            RawData.Add(F3BetaH);
            RawData.Add(F3Gamma);
        
            RawData.Add(FC5Theta);
            RawData.Add(FC5Alpha);
            RawData.Add(FC5BetaL);
            RawData.Add(FC5BetaH);
            RawData.Add(FC5Gamma);
    
            RawData.Add(T7Theta);
            RawData.Add(T7Alpha);
            RawData.Add(T7BetaL);
            RawData.Add(T7BetaH);
            RawData.Add(T7Gamma);

            RawData.Add(P7Theta);
            RawData.Add(P7Alpha);
            RawData.Add(P7BetaL);
            RawData.Add(P7BetaH);
            RawData.Add(P7Gamma);
    
            RawData.Add(O1Theta);
            RawData.Add(O1Alpha);
            RawData.Add(O1BetaL);
            RawData.Add(O1BetaH);
            RawData.Add(O1Gamma);
        
            RawData.Add(O2Theta);
            RawData.Add(O2Alpha);
            RawData.Add(O2BetaL);
            RawData.Add(O2BetaH);
            RawData.Add(O2Gamma);
           
            RawData.Add(P8Theta);
            RawData.Add(P8Alpha);
            RawData.Add(P8BetaL);
            RawData.Add(P8BetaH);
            RawData.Add(P8Gamma);

            RawData.Add(T8Theta);
            RawData.Add(T8Alpha);
            RawData.Add(T8BetaL);
            RawData.Add(T8BetaH);
            RawData.Add(T8Gamma);
  
            RawData.Add(FC6Theta);
            RawData.Add(FC6Alpha);
            RawData.Add(FC6BetaL);
            RawData.Add(FC6BetaH);
            RawData.Add(FC6Gamma);

            RawData.Add(F4Theta);
            RawData.Add(F4Alpha);
            RawData.Add(F4BetaL);
            RawData.Add(F4BetaH);
            RawData.Add(F4Gamma);

            RawData.Add(F8Theta);
            RawData.Add(F8Alpha);
            RawData.Add(F8BetaL);
            RawData.Add(F8BetaH);
            RawData.Add(F8Gamma);
 
            RawData.Add(AF4Theta);
            RawData.Add(AF4Alpha);
            RawData.Add(AF4BetaL);
            RawData.Add(AF4BetaH);
            RawData.Add(AF4Gamma);

        }

    }
}
