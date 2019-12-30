namespace Blobfish
{
    /// <summary>
    /// Specifies the referenced entity is consumed or produced in an experiment.
    /// </summary>
    public enum SamplePurpose
    {
        /// <summary>
        /// Specifies whether a sample is produced in an experiment.
        /// </summary>
        Produced = 0,

        /// <summary>
        /// Specifies whether a sample is consumed in an experiment.
        /// </summary>
        Consumed = 1,
    }
}
