namespace Blobfish
{
    /// <summary>
    /// Type of change made (created, modified, ...)
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// The given user has created the references item(s).
        /// </summary>
        Created = 0,

        /// <summary>
        /// Item already existed and has been modified. Modifications are explained in the Description element.
        /// </summary>
        Modified = 1,

        /// <summary>
        /// Item has been converted into AnIML format.
        /// </summary>
        Converted = 2,

        /// <summary>
        /// The given user has exercised read access on the referenced item(s).
        /// </summary>
        Read = 3,

        /// <summary>
        /// The given user has attached a digital signature.
        /// </summary>
        Signed = 4,

        /// <summary>
        /// The referenced items were deleted. No reference is specified. Description explains what was deleted.
        /// </summary>
        Deleted = 5,
    }
}
