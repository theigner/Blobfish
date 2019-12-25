namespace Blobfish
{
    /// <summary>
    /// Base class for all signable items with name and source data location. Implements ISignableItemWithName, ISourceDataLocation and ISignableItem indirectly through ISignableItemWithName.
    /// </summary>
    public abstract class ISignableItemWithNameAndISourceDataLocationBase : ISignableItemWithName, ISourceDataLocation
    {
        /// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Plain-text name of this item.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Points to the original data source. May be a file name, uri, database ID, etc.
        /// </summary>
        public string SourceDataLocation { get; set; }
    }
}
