namespace Blobfish
{
    /// <summary>
    /// Base class for classes that implement the ISignableItem and the ISampleAttributes interface.
    /// </summary>
    public abstract class ISignableItemWithSampleAttributesBase : ISignableItem, ISampleAttibutes
    {
        //// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        //// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Role this sample plays within the current ExperimentStep.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Specifies whether the referenced sample is produced or consumed by the current ExperimentStep.
        /// </summary>
        public SamplePurpose SamplePurpose { get; set; }
    }
}
