using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    /// <summary>
    /// Readonly information about the currently caught fish - intercepted from the Networking call by FishingRod. Immutable.
    /// </summary>
    public class FishCaughtInfoEvent : Event
    {
        /// <summary>
        /// The fish's object id.
        /// </summary>
        public int FishID { get; private set; }
        /// <summary>
        /// The size of the fish in inches.
        /// </summary>
        public int FishSize { get; private set; }
        /// <summary>
        /// The quality of the fish.
        /// </summary>
        public int FishQuality { get; private set; }
        public int FishDifficulty { get; private set; }
        /// <summary>
        /// If there was a treasure caught aswell.
        /// </summary>
        public bool TreasureCaught { get; private set; }
        /// <summary>
        /// If the fishing minigame was completed with a perfect score.
        /// </summary>
        public bool WasPerfect { get; private set; }

        internal FishCaughtInfoEvent(int fishID, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect)
        {
            FishID = fishID;
            FishSize = fishSize;
            FishQuality = fishQuality;
            FishDifficulty = fishDifficulty;
            TreasureCaught = treasureCaught;
            WasPerfect = wasPerfect;
        }
    }
}
