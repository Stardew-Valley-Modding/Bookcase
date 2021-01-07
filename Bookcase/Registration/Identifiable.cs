namespace Bookcase.Registration {

    /// <summary>
    /// This class serves as a default implementation of IIdentifiable. It provides common ID logic.
    /// </summary>
    public class Identifiable : IIdentifiable {

        /// <summary>
        /// A property that holds the identifier for the object. Please don't abuse public set.
        /// </summary>
        public Identifier Identifier { get; set; }
    }
}
