using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    /// <summary>
    /// Readonly information about the currently caught fish - intercepted from the Networking call by FishingRod.
    /// </summary>
    public class AfterFishCaughtEvent : Event
    {
        /// <summary>
        /// The fish's object id.
        /// </summary>
        public int fishID;
        /// <summary>
        /// The size of the fish in inches.
        /// </summary>
        public int fishSize;
        /// <summary>
        /// The quality of the fish.
        /// </summary>
        public int fishQuality;
        public int fishDifficulty;
        /// <summary>
        /// If there was a treasure caught aswell.
        /// </summary>
        public bool treasureCaught;
        /// <summary>
        /// If the fishing minigame was completed with a perfect score.
        /// </summary>
        public bool wasPerfect;
    }
}
