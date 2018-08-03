using System;

namespace Bookcase.Events {

    public static class BookcaseEvents {

        /// <summary>
        /// This event is fired when an item tooltip is displayed.
        /// </summary>
        public static EventBus<ItemTooltipEvent> OnItemTooltip = new EventBus<ItemTooltipEvent>();

        /// <summary>
        /// This event is fired when a fish/junk is successfully caught by the player.
        /// </summary>
        public static EventBus<FarmerCaughtFishEvent> FishCaughtInfo = new EventBus<FarmerCaughtFishEvent>();

        /// <summary>
        /// This event is fired when a player gains EXP for a skill.
        /// </summary>
        public static EventBus<FarmerGainExperienceEvent> OnSkillEXPGain = new EventBus<FarmerGainExperienceEvent>();
    }
}