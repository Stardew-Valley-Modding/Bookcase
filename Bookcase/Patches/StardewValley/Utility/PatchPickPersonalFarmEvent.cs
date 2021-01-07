using Bookcase.Events;
using StardewValley.Events;
using System;
using System.Reflection;

namespace Bookcase.Patches {

    public class PatchPickPersonalFarmEvent : IGamePatch {

        public Type TargetType => typeof(StardewValley.Utility);

        public MethodBase TargetMethod => TargetType.GetMethod("pickPersonalFarmEvent");

        public static void Postfix(ref FarmEvent __result) {

            SelectFarmEvent selectEvent = new SelectFarmEvent(__result);
            __result = BookcaseEvents.SelectPersonalEvent.Post(selectEvent) ? null : selectEvent.SelectedEvent;
        }
    }
}