using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainStorm
{
    public class Globals
    {
        public enum MessageTypes
        {
            None = 0,
            Error = 1,
            Status = 2
        }

        public enum StrokeTypes
        {
            Output = 0,
            Filter = 1,
            CtrlZ = 2,
            Waiting = 3
        }

    }
}

