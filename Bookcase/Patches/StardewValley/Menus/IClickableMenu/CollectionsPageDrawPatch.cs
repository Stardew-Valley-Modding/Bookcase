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
    /// <summary>
    /// Patches the Menu.CollectionsPage - not cancellable, but will allow you to modify the elements being drawn.
    /// </summary>
    public class CollectionsPageDrawPatch : IGamePatch
    {
        public Type TargetType => typeof(CollectionsPage);

        public MethodBase TargetMethod => TargetType.GetMethod("draw");

        public static void Prefix(CollectionsPage __instance, ref string ___hoverText, ref int ___currentTab, ref int ___currentPage)
        {
            CollectionsPageDrawEvent evt = new CollectionsPageDrawEvent(___currentTab, ___currentPage, ___hoverText);
            BookcaseEvents.CollectionsPageDrawEvent.Post(evt);
            ___currentTab = evt.currentTab;
            ___currentPage = evt.currentPage;
            ___hoverText = evt.hoverText;
        }
    }
}
