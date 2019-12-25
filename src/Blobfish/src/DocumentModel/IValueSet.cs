namespace Blobfish
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines properties and methods exposed by all kinds of ValueSet implementations.
    /// </summary>
    public interface IValueSet
    {
        /// <summary>
        /// Zero-based index of the last entry in this Value Set. The specification is inclusive.
        /// </summary>
        int? EndIndex { get; set; }

        /// <summary>
        /// Zero-based index of the first entry in this Value Set. The specification is inclusive.
        /// </summary>
        int? StartIndex { get; set; }

        /// <summary>
        /// Determines if values in the ValueSet are in ascending or descending order.
        /// </summary>
        /// <returns>True if the values are in descending order, otherwise false.</returns>
        bool IsInReverseOrder();

        /// <summary>
        /// Returns the values of the ValueSet as List.
        /// </summary>
        /// <param name="length">The number of values in the ValueSet.</param>
        /// <returns>A List of values in the ValueSet.</returns>
        List<dynamic> ToList(int length);
    }
}
