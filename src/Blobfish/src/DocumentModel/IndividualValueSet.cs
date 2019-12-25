namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// A ValueSet that contains multiple values that are explicitly specified in the AnIML document.
    /// </summary>
    public class IndividualValueSet : ValueSet
    {
        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The newly created ValueSet does not contain values.
        /// </summary>
        /// <param name="seriesType">The type of values in the ValueSet.</param>
        public IndividualValueSet(SeriesType seriesType)
        {
            this.SeriesType = seriesType;
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="seriesType">The type of values in the ValueSet.</param>
        /// <param name="values">A list of values with that the ValueSet is initialized.</param>
        public IndividualValueSet(SeriesType seriesType, IEnumerable<dynamic> values)
            : this(seriesType)
        {
            this.AddRange(values);
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of int values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<int> values)
            : this(SeriesType.Int32)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of long values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<long> values)
            : this(SeriesType.Int64)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of float values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<float> values)
            : this(SeriesType.Float32)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of double values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<double> values)
            : this(SeriesType.Float64)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of string values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<string> values)
            : this(SeriesType.String)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of bool values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<bool> values)
            : this(SeriesType.Boolean)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of DateTime values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<DateTime> values)
            : this(SeriesType.DateTime)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of PngImage values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<PngImage> values)
            : this(SeriesType.PNG)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of EmbeddedXml values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<EmbeddedXml> values)
            : this(SeriesType.EmbeddedXML)
        {
            this.AddRange(values.Cast<dynamic>());
        }

        /// <summary>
        /// Creates a new instance of the IndividualValueSet class. The ValueSet is initialized with the supplied values.
        /// </summary>
        /// <param name="values">A list of SvgImage values with that the ValueSet is initialized.</param>
        public IndividualValueSet(IEnumerable<SvgImage> values)
            : this(SeriesType.SVG)
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

        internal static IndividualValueSet FromXElement(XElement individualValueSetElement, SeriesType seriesType)
        {
            IndividualValueSet valueSet = new IndividualValueSet(seriesType);

            //// Import attributes for the implemented interfaces
            valueSet.ImportIValueSet(individualValueSetElement);

            //// Import the values from the child elements
            if (seriesType == SeriesType.Int32)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("I")).Select(x => (dynamic)XmlConvert.ToInt32(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.Int64)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("L")).Select(x => (dynamic)XmlConvert.ToInt64(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.Float32)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("F")).Select(x => (dynamic)XmlConvert.ToSingle(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.Float64)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("D")).Select(x => (dynamic)XmlConvert.ToDouble(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.String)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("S")).Select(x => x.Value));
                return valueSet;
            }
            else if (seriesType == SeriesType.Boolean)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("Boolean")).Select(x => (dynamic)XmlConvert.ToBoolean(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.DateTime)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("DateTime")).Select(x => (dynamic)XmlConvert.ToDateTime(x.Value, XmlDateTimeSerializationMode.Utc)));
                return valueSet;
            }
            else if (seriesType == SeriesType.PNG)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("PNG")).Select(x => new PngImage(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.EmbeddedXML)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("EmbeddedXML")).Select(x => new EmbeddedXml(x.Value)));
                return valueSet;
            }
            else if (seriesType == SeriesType.SVG)
            {
                valueSet.AddRange(individualValueSetElement.Elements(NamespaceHelper.GetXName("SVG")).Select(x => new SvgImage(x.Value)));
                return valueSet;
            }
            else
            {
                throw new NotSupportedException($"{seriesType}' is not supported.");
            }
        }

        internal XElement ToXElement()
        {
            XElement individualValueSetElement = new XElement(NamespaceHelper.GetXName("IndividualValueSet"));

            //// Export attributes of all implemented interfaces
            individualValueSetElement.ImportIValueSet(this);

            //// Export the values to child elements
            this.ForEach(v => individualValueSetElement.Add(DynamicValueHelper.XElementFromValue(v)));

            return individualValueSetElement;
        }
    }
}
