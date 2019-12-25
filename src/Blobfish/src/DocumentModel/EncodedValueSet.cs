namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// A ValueSet that contains multiple values that are encoded as base64 binary string. Little-endian byte order is used for encoding / decoding.
    /// </summary>
    public class EncodedValueSet : ValueSet
    {
        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The newly created ValueSet does not contain values.
        /// </summary>
        /// <param name="seriesType">The type of values in the ValueSet. Only numeric types are allowed (Int32, Int64, Float32, Float64).</param>
        /// <exception cref="System.ArgumentException">Thrown when the SeriesType represents a non-numeric SeriesType such as String or DateTime.</exception>
        public EncodedValueSet(SeriesType seriesType)
        {
            Guard.AgainstNonNumericSeriesType(nameof(seriesType), seriesType);

            this.SeriesType = seriesType;
        }

        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="seriesType">The type of values in the ValueSet.</param>
        /// <param name="values">A list of values with that the ValueSet is initialized.</param>
        public EncodedValueSet(SeriesType seriesType, IEnumerable<dynamic> values)
            : this(seriesType)
        {
            this.AddRange(values);
        }

        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of int values with that the ValueSet is initialized.</param>
        public EncodedValueSet(IEnumerable<int> values)
            : this(SeriesType.Int32)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of long values with that the ValueSet is initialized.</param>
        public EncodedValueSet(IEnumerable<long> values)
            : this(SeriesType.Int64)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of float values with that the ValueSet is initialized.</param>
        public EncodedValueSet(IEnumerable<float> values)
            : this(SeriesType.Float32)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the EncodedValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of double values with that the ValueSet is initialized.</param>
        public EncodedValueSet(IEnumerable<double> values)
            : this(SeriesType.Float64)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Returns the values of the ValueSet as List.
        /// </summary>
        /// <param name="length">The number of values in the ValueSet.</param>
        /// <returns>A List of values in the ValueSet.</returns>
        public override List<dynamic> ToList(int length)
        {
            return this;
        }

        internal static EncodedValueSet FromXElement(XElement encodedValueSetElement, SeriesType seriesType)
        {
            EncodedValueSet encodedValueSet = new EncodedValueSet(seriesType);

            //// Import attributes for the implemented interfaces
            encodedValueSet.ImportIValueSet(encodedValueSetElement);

            //// Import the values from the content
            if (seriesType == SeriesType.Int32)
            {
                encodedValueSet.AddRange(encodedValueSetElement.Value.ToIntArray().Cast<dynamic>());
                return encodedValueSet;
            }
            else if (seriesType == SeriesType.Int64)
            {
                encodedValueSet.AddRange(encodedValueSetElement.Value.ToLongArray().Cast<dynamic>());
                return encodedValueSet;
            }
            else if (seriesType == SeriesType.Float32)
            {
                encodedValueSet.AddRange(encodedValueSetElement.Value.ToFloatArray().Cast<dynamic>());
                return encodedValueSet;
            }
            else if (seriesType == SeriesType.Float64)
            {
                encodedValueSet.AddRange(encodedValueSetElement.Value.ToDoubleArray().Cast<dynamic>());
                return encodedValueSet;
            }
            else
            {
                throw new NotSupportedException($"SeriesType '{seriesType}' is not supported when importing an EncodedValueSet.");
            }
        }
       
        internal XElement ToXElement()
        {
            XElement encodedValueSetElement = new XElement(NamespaceHelper.GetXName("EncodedValueSet"));

            //// Export attributes of all implemented interfaces
            encodedValueSetElement.ImportIValueSet(this);

            //// Export the values to the content
            if (this.SeriesType == SeriesType.Int32)
            {
                encodedValueSetElement.Value = this.Cast<int>().ToArray().ToBase64String();
            }
            else if (this.SeriesType == SeriesType.Int64)
            {
                encodedValueSetElement.Value = this.Cast<long>().ToArray().ToBase64String();
            }
            else if (this.SeriesType == SeriesType.Float32)
            {
                encodedValueSetElement.Value = this.Cast<float>().ToArray().ToBase64String();
            }
            else if (this.SeriesType == SeriesType.Float64)
            {
                encodedValueSetElement.Value = this.Cast<double>().ToArray().ToBase64String();
            }
            else
            {
                throw new NotSupportedException($"SeriesType {this.SeriesType} is not supported when generating an XElement from an EncodedValueSet.");
            }

            return encodedValueSetElement;
        }
    }
}
