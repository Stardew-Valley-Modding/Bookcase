using StardewValley;

namespace Bookcase.Events {

    /// <summary>
    /// This event is fired when a player catches a fish, but before the fish that is caught has been determined.
    /// </summary>
    public class FarmerFishItemEvent : FarmerEvent {

        /// <summary>
        /// The item that the game originally determined to be caught.
        /// </summary>
        public Object OriginalItem { get; private set; }

        /// <summary>
        /// The item that the player fished up. This is the OriginalItem by default. This property is the one that is ultimately used to determine the fish that has actually been caught.
        /// </summary>
        public Object FishedItem { get; set; }

        /// <summary>
        /// The location the fish was caught in.
        /// </summary>
        public GameLocation Location { get; private set; }

        /// <summary>
        /// The type of bait used.
        /// </summary>
        public int Bait { get; private set; }

        /// <summary>
        /// The depth of the water tile the fish was caught on.
        /// </summary>
        public int Depth { get; private set; }

        /// <summary>
        /// The potency of the bait.
        /// </summary>
        public double BaitPotency { get; private set; }

        /// <summary>
        /// Amount of time in MS since the fish was hooked on the line.
        /// </summary>
        public float MillisecondsAfterNibble { get; private set; }

        public FarmerFishItemEvent(Object originalItem, GameLocation originalLocation, float millisecondsAfterNibble, int bait, int waterDepth, Farmer who, double baitPotency) : base(who) {

            this.FishedItem = originalItem;
            this.Location = originalLocation;
            this.Bait = bait;
            this.Depth = waterDepth;
            this.BaitPotency = baitPotency;
            this.MillisecondsAfterNibble = millisecondsAfterNibble;
        }
    }
}