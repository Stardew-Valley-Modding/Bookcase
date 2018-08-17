using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    public class PostBundleSetupEvent : Event
    {
        public List<ClickableTextureComponent> ingredientList;
        public List<ClickableTextureComponent> ingredientSlots;
        public InventoryMenu inventory;
        /// <summary>
        /// No point trying to change this, it's local scope to the method and is never referenced again - it is merely a convenience.
        /// </summary>
        public readonly Bundle currentBundle;

        public PostBundleSetupEvent(List<ClickableTextureComponent> ingredientList, List<ClickableTextureComponent> ingredientSlots, InventoryMenu inventory, Bundle currentBundle)
        {
            this.ingredientList = ingredientList;
            this.ingredientSlots = ingredientSlots;
            this.inventory = inventory;
            this.currentBundle = currentBundle;
        }
    }
}
