namespace Blobfish
{
    /// <summary>
    /// Specifies how the data in this Series is typically plotted.
    /// </summary>
    public enum PlotScale
    {
        /// <summary>
        /// Specifies that this Series is typically plotted on a linear scale.
        /// </summary>
        Linear = 0,

        /// <summary>
        /// Specifies that this Series is typically plotted on a common logarithmic scale (base 10).
        /// </summary>
        Log = 1,

        /// <summary>
        /// Specifies that this Series is typically plotted on a natural logarithmic scale (base e).
        /// </summary>
        Ln = 2,

        /// <summary>
        /// Specifies that this Series is not plottable.
        /// </summary>
        None = 3,
    }
}
