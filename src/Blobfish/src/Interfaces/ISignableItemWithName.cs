namespace Blobfish
{
    /// <summary>
    /// Defined properties for signable items with a name in an AnIML document.
    /// </summary>
    public interface ISignableItemWithName : ISignableItem
    {
        /// <summary>
        /// Plain-text name of this item.
        /// </summary>
        string Name { get; }
    }
}
