using System;
using System.Reflection;
using Harmony;
using System.Collections.Generic;
using StardewValley;
using Bookcase.Events;

namespace Bookcase.Patches {

    public class DoFunctionPatch : IGamePatch {

        public Type TargetType => typeof(StardewValley.Tools.FishingRod);

        public MethodBase TargetMethod => TargetType.GetMethod("DoFunction");

        public static IEnumerable<CodeInstruction> Transpile(IEnumerable<CodeInstruction> instructions) {

            MethodBase targetMethod = typeof(GameLocation).GetMethod("getFish", new Type[] { typeof(Single), typeof(Int32), typeof(Int32), typeof(Farmer), typeof(Double) });
            MethodBase replacement = typeof(DoFunctionPatch).GetMethod("GameLocation_GetFish");

            return instructions.MethodReplacer(targetMethod, replacement);
        }

        public static StardewValley.Object GameLocation_GetFish(GameLocation originalLocation, float millisecondsAfterNibble, int bait, int waterDepth, Farmer who, double baitPotency) {

            StardewValley.Object originalFish = originalLocation.getFish(millisecondsAfterNibble, bait, waterDepth, who, baitPotency);
            FarmerFishItemEvent fishEvent = new FarmerFishItemEvent(originalFish, originalLocation, millisecondsAfterNibble, bait, waterDepth, who, baitPotency);
            BookcaseEvents.FishItem.Post(fishEvent);
            return fishEvent.FishedItem;
        }
    }
}