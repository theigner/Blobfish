namespace Blobfish
{
    /// <summary>
    /// Attribute group which points to the original data source.
    /// </summary>
    public interface ISourceDataLocation
    {
        /// <summary>
        /// Points to the original data source. May be a file name, uri, database ID, etc.
        /// </summary>
        string SourceDataLocation { get; set; }
    }
}
