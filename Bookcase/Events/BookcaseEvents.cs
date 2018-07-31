using System;

namespace Bookcase.Events {

    public static class BookcaseEvents {

        /// <summary>
        /// This event is fired when an item tooltip is displayed.
        /// </summary>
        public static EventBus<ItemTooltipEvent> OnItemTooltip = new EventBus<ItemTooltipEvent>();
        /// <summary>
        /// This event is fired when a fish/junk is successfully caught by the player, provides immutable information about fish caught.
        /// </summary>
        public static EventBus<FishCaughtInfoEvent> FishCaughtInfo = new EventBus<FishCaughtInfoEvent>();
        public static EventBus<FarmerGainExperienceEvent> OnSkillEXPGain = new EventBus<FarmerGainExperienceEvent>();
    }
}