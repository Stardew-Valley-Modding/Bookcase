using Bookcase.Events;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Patches
{
    public class CollectionsPageDrawPatch : IGamePatch
    {
        public Type TargetType => typeof(CollectionsPage);
        public MethodInfo TargetMethod => TargetType.GetMethod("draw");/*
        public static void Postfix(CollectionsPage __instance, int currentTab, int index, ref string __result)
        {
            if (currentTab == 5 || currentTab == 6)
                return;

            BookcaseMod.logger.Alert(__result);
            __result += "\nTest";
        }*/
        public static bool Prefix(CollectionsPage __instance, int itemIndex, int currentTab, int currentPage)
        {
            CollectionsPageDrawEvent evt = new CollectionsPageDrawEvent(itemIndex, currentTab, currentPage);
            BookcaseEvents.CollectionsPageDrawEvent.Post(evt);
            return true;
        }
    }
}
