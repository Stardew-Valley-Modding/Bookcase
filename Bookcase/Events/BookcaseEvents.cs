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

        /// <summary>
        /// This event is fired when a shop menu has been setup. Including inventory and prices.
        /// </summary>
        public static EventBus<ShopSetupEvent> ShopSetupEvent = new EventBus<ShopSetupEvent>();

        /// <summary>
        /// Stardew Valley's launch tick - fired once per game start.
        /// </summary>
        public static EventBus<Event> FirstGameTick = new EventBus<Event>();

        /// <summary>
        /// Wrapper of SMAPI's GameEvents.QuaterSecondTick - is fired every 250ms.
        /// </summary>
        public static EventBus<Event> GameQuaterSecondTick = new EventBus<Event>();

        /// <summary>
        /// Wrapper of SMAPI's GameEvents.HalfSecondTick - fired every 500ms.
        /// </summary>
        public static EventBus<Event> GameHalfSecondTick = new EventBus<Event>();

        /// <summary>
        /// Wrapper of SMAPI's GameEvents.SecondTick - fired every 1000ms.
        /// </summary>
        public static EventBus<Event> GameFullSecondTick = new EventBus<Event>();

        public static EventBus<CollectionsPageDrawEvent> CollectionsPageDrawEvent = new EventBus<CollectionsPageDrawEvent>();
    }
}