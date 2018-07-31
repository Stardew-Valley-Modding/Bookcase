using Bookcase.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Patches
{
    public class FishCaughtPatch : IGamePatch
    {
        public Type TargetType => typeof(StardewValley.Tools.FishingRod);

        public MethodInfo TargetMethod => TargetType.GetMethod("pullFishFromWater");

        public static bool Prefix(int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect = false)
        {
            AfterFishCaughtEvent caughtEvent = new AfterFishCaughtEvent
            {
                fishID = whichFish,
                fishSize = fishSize,
                fishQuality = fishQuality,
                fishDifficulty = fishDifficulty,
                treasureCaught = treasureCaught,
                wasPerfect = wasPerfect
            };
            BookcaseEvents.AfterFishCaught.Post(caughtEvent);
            return true;
        }
    }
}
