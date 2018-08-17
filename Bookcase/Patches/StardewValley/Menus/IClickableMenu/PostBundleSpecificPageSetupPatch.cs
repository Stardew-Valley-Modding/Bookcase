using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bookcase.Events;

namespace Bookcase.Patches
{
    public class PostBundleSpecificPageSetupPatch : IGamePatch
    {
        public Type TargetType => typeof(JunimoNoteMenu);
        
        public MethodBase TargetMethod => TargetType.GetMethod("setUpBundleSpecificPage", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void Postfix(JunimoNoteMenu __instance, Bundle b)
        {
            BookcaseEvents.PostBundleSpecificPageSetup.Post(new PostBundleSetupEvent(__instance.ingredientList, __instance.ingredientSlots, __instance.inventory, b));
        }
    }
}
