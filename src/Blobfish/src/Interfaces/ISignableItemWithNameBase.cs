namespace Blobfish
{
    /// <summary>
    /// Base class for all signable items with name. Implements ISignableItemWithName and ISignableItem through ISignableItemWithName.
    /// </summary>
    public abstract class ISignableItemWithNameBase : ISignableItemWithName
    {
        /// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Plain-text name of this item.
        /// </summary>
        public string Name { get; internal set; }
    }
}
