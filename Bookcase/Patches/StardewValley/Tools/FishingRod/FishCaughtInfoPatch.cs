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

        public static void Prefix(int whichFish, int fishSize, int fishQuality, int fishDifficulty, bool treasureCaught, bool wasPerfect = false)
        {
            FishCaughtInfoEvent caughtEvent = new FishCaughtInfoEvent(whichFish, fishSize, fishQuality, fishDifficulty, treasureCaught, wasPerfect);
            BookcaseEvents.FishCaughtInfo.Post(caughtEvent);
        }
    }
}