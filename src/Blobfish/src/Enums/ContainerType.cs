namespace Blobfish
{
    /// <summary>
    /// Describes what kind of container the current sample is.
    /// </summary>
    public enum ContainerType
    {
        /// <summary>
        /// This container holds exactly one sample (e.g. well, vial, tube).
        /// </summary>
        Simple = 0,

        /// <summary>
        /// Positions within this container are precisely defined and known in advance (e.g. racks, ...)
        /// </summary>
        Determinate = 1,

        /// <summary>
        /// Positions within this container are not precisely defined or known in advance (e.g. gels, surfaces)
        /// </summary>
        Indeterminate = 2,

        /// <summary>
        /// Rectangular tray with unknown (or other) number of positions.
        /// </summary>
        RectangularTray = 3,

        /// <summary>
        /// Microtiter plate or tray with 6 positions.
        /// </summary>
        Wells6 = 4,

        /// <summary>
        /// Microtiter plate or tray with 24 positions.
        /// </summary>
        Wells24 = 5,

        /// <summary>
        /// Microtiter plate or tray with 96 positions.
        /// </summary>
        Wells96 = 6,

        /// <summary>
        /// Microtiter plate or tray with 384 positions.
        /// </summary>
        Wells384 = 7,

        /// <summary>
        /// Microtiter plate or tray with 1536 positions.
        /// </summary>
        Wells1536 = 8,
    }
}
