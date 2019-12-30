namespace Blobfish
{
    /// <summary>
    /// Common attributes for sample references.
    /// </summary>
    public interface ISampleAttibutes
    {
        /// <summary>
        /// Role this sample plays within the current ExperimentStep.
        /// </summary>
        string Role { get; set; }

        /// <summary>
        /// Specifies whether the referenced sample is produced or consumed by the current ExperimentStep.
        /// </summary>
        SamplePurpose SamplePurpose { get; set; }
    }
}
