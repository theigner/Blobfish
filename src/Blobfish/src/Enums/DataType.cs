namespace Blobfish
{
    /// <summary>
    /// Names of Data Types.
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Represents an individual integer value (32 bits, signed).
        /// </summary>
        Int32 = 0,

        /// <summary>
        /// Represents an individual long integer value (64 bits, signed).
        /// </summary>
        Int64 = 1,

        /// <summary>
        /// Represents an individual 32-bit floating point value.
        /// </summary>
        Float32 = 2,

        /// <summary>
        /// Represents an individual 64-bit floating point value.
        /// </summary>
        Float64 = 3,

        /// <summary>
        /// Represents an individual string value.
        /// </summary>
        String = 4,

        /// <summary>
        /// Represents an individual Boolean value.
        /// </summary>
        Boolean = 5,

        /// <summary>
        /// Represents an individual ISO date/time value.
        /// </summary>
        DateTime = 6,

        /// <summary>
        /// Represents a Value governed by a different XML Schema.
        /// </summary>
        EmbeddedXML = 7,

        /// <summary>
        /// Base 64 encoded PNG image
        /// </summary>
        PNG = 8,

        /// <summary>
        /// Value governed by the SVG DTD. Used to represent vector graphic images.
        /// </summary>
        SVG = 9,
    }
}
