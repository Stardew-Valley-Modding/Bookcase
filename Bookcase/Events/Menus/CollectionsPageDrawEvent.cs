using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events
{
    public class CollectionsPageDrawEvent : Event
    {
        public int currentTab;
        public int currentPage;
        public string hoverText;

        public CollectionsPageDrawEvent(int currentTab, int currentPage, string hoverText)
        {
            this.currentTab = currentTab;
            this.currentPage = currentPage;
            this.hoverText = hoverText;
        }

        public override string ToString()
        {
            return $"Tab: {currentTab}\nPage: {currentPage}\nHoverText: {hoverText}";
        }
    }
}
