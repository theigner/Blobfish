namespace Blobfish
{
    /// <summary>
    /// Defines properties for signable items in an AnIML document.
    /// </summary>
    public interface ISignableItem
    {
        /// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        /// </summary>
        string Id { get; set; }
    }
}
