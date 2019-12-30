namespace Blobfish
{
    /// <summary>
    /// Scope of diff. May be "element" or "attribute".
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// This diff describes the whole element before and after the change.
        /// </summary>
        Element = 0,

        /// <summary>
        /// This diff only describes a change in attributes. The child elements remain unchanged (and are not reflected in the diff to save space).
        /// </summary>
        Attributes = 1,
    }
}
