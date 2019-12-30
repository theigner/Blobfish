namespace Blobfish
{
    /// <summary>
    /// Specifies whether the referenced ExperimentStep data is consumed or produced in an experiment.
    /// </summary>
    public enum ExperimentDataPurpose
    {
        /// <summary>
        /// Specifies whether the referenced ExperimentStep data is produced in an experiment.
        /// </summary>
        Produced = 0,

        /// <summary>
        /// Specifies whether the referenced ExperimentStep data is consumed in an experiment.
        /// </summary>
        Consumed = 1,
    }
}
