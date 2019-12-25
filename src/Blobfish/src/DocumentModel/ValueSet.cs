namespace Blobfish
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Abstract base class for all ValueSets.
    /// </summary>
    public abstract class ValueSet : List<dynamic>, IValueSet
    {
        /// <summary>
        /// Zero-based index of the first entry in this Value Set. The specification is inclusive.
        /// </summary>
        public int? EndIndex { get; set; }

        /// <summary>
        /// Zero-based index of the first entry in this Value Set. The specification is inclusive.
        /// </summary>
        public int? StartIndex { get; set; }

        /// <summary>
        /// Gets or sets the type of values contained by the ValueSet.
        /// </summary>
        public SeriesType SeriesType { get; protected set; }

        /// <summary>
        /// Determines if values in the ValueSet are in ascending or descending order.
        /// </summary>
        /// <returns>True if the values are in descending order, otherwise false.</returns>
        /// <remarks>This method returns false if the ValueSet contains no values. The order is determined by comparing the first and the last value in the ValueSet.</remarks>
        public virtual bool IsInReverseOrder()
        {
            if (this.Count > 0)
            {
                return this[0] > this[this.Count - 1];
            }

            return false;
        }

        /// <summary>
        /// Returns the values of the ValueSet as List.
        /// </summary>
        /// <param name="length">The number of values in the ValueSet.</param>
        /// <returns>A List of values in the ValueSet.</returns>
        public abstract List<dynamic> ToList(int length);
    }
}
