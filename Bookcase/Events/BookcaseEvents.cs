using System;

namespace Bookcase.Events {

    public static class BookcaseEvents {

        /// <summary>
        /// An enum containing the various event priorities. 
        /// 
        /// Higher priority events happen first. Lower priority happen last.
        /// </summary>
        public enum Priority { Highest, Hight, Normal, Low, Lowest };

        /// <summary>
        /// This event is fired when an item tooltip is displayed.
        /// </summary>
        public static EventBus<ItemTooltipEvent> OnItemTooltip = new EventBus<ItemTooltipEvent>();

        /// <summary>
        /// This event is fired when a fish/junk is successfully caught by the player.
        /// </summary>
        public static EventBus<FarmerCaughtFishEvent> FishCaughtInfo = new EventBus<FarmerCaughtFishEvent>();

        /// <summary>
        /// This event is fired when the item that is fished up is actually determined. After the player has realed the item in.
        /// </summary>
        public static EventBus<FarmerFishItemEvent> FishItem = new EventBus<FarmerFishItemEvent>();

        /// <summary>
        /// This event is fired when a player gains EXP for a skill.
        /// </summary>
        public static EventBus<FarmerGainExperienceEvent> OnSkillEXPGain = new EventBus<FarmerGainExperienceEvent>();

        /// <summary>
        /// This event is fired when the nightly farm event is selected.
        /// </summary>
        public static EventBus<SelectFarmEvent> SelectFarmEvent = new EventBus<SelectFarmEvent>();

        /// <summary>
        /// This event is fired when the nightly personal event is selected.
        /// </summary>
        public static EventBus<SelectFarmEvent> SelectPersonalEvent = new EventBus<SelectFarmEvent>();
    }
}