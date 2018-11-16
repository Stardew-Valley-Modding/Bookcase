namespace Bookcase.Registration {

    /// <summary>
    /// Interface used to define an identifiable object. Intended for use in Bookcase registries.
    /// </summary>
    public interface IIdentifiable {

        /// <summary>
        /// Property for the id. Implementation is up to implementer.
        /// </summary>
        Identifier Identifier { get; set; }
    }
}