namespace Blobfish
{
    /// <summary>
    /// Common attributes for experiment data references.
    /// </summary>
    public interface IExperimentDataAttributes
    {
        /// <summary>
        /// Role the experiment data plays within the current ExperimentStep.
        /// </summary>
        string Role { get; set; }

        /// <summary>
        /// Specifies whether the referenced experiment data is produced or consumed by the current ExperimentStep.
        /// </summary>
        ExperimentDataPurpose DataPurpose { get; set; }
    }
}
