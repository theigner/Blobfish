namespace Blobfish
{
    /// <summary>
    /// Base class for all signable items. Implements ISignableItem.
    /// </summary>
    public abstract class ISignableItemBase : ISignableItem
    {
        //// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        //// </summary>
        public string Id { get; set; }
    }
}
