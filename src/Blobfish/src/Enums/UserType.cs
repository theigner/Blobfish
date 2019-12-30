namespace Blobfish
{
    /// <summary>
    /// Specifies whether a user is a real person, a device, or a software program.
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// Specifies that the user is a real person.
        /// </summary>
        Human = 0,

        /// <summary>
        /// Specifies that the user is a device.
        /// </summary>
        Device = 1,

        /// <summary>
        /// Specifies that the user is a software system.
        /// </summary>
        Software = 2,
    }
}
