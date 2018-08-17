using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    public class CollectionsPageDrawEvent : Event
    {
        public int itemParentSheetIndex = -1;
        public int currentTab = -1;
        public int currentPage = -1;

        public CollectionsPageDrawEvent(int itemParentSheetIndex, int currentTab, int currentPage)
        {
            this.itemParentSheetIndex = itemParentSheetIndex;
            this.currentTab = currentTab;
            this.currentPage = currentPage;
        }
    }
}
