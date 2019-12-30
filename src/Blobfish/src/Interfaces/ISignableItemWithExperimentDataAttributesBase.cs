namespace Blobfish
{
    /// <summary>
    /// Base class for classes that implement the ISignableItem and the IExperimentDataAttributes interface.
    /// </summary>
    public abstract class ISignableItemWithExperimentDataAttributesBase : ISignableItem, IExperimentDataAttributes
    {
        //// <summary>
        /// Anchor point for digital signature. This identifier is referred to from the "Reference" element in a Signature. Unique per document.
        //// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Role the experiment data plays within the current ExperimentStep.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Specifies whether the referenced experiment data is produced or consumed by the current ExperimentStep.
        /// </summary>
        public ExperimentDataPurpose DataPurpose { get; set; }
    }
}
