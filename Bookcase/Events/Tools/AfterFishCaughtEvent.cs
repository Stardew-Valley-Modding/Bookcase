using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    /// <summary>
    /// Readonly information about the currently caught fish - intercepted from the Networking call by FishingRod
    /// </summary>
    public class AfterFishCaughtEvent : Event
    {
        public int fishID;
        public int fishSize;
        public int fishQuality;
        public int fishDifficulty;
        public bool treasureCaught;
        public bool wasPerfect;
            //int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect = false
    }
}
