namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Container for n-dimensional Data.
    /// </summary>
    public class SeriesSet : ISignableItemWithNameBase
    {
        /// <summary>
        /// Creates a new instance of class SeriesSet.
        /// </summary>
        /// <param name="name">The name of the SeriesSet.</param>
        /// <param name="length">The number of data points each Series is the SeriesSet contains.</param>
        /// <remarks>Every series in the SeriesSet must have the same number of data points.</remarks>
        public SeriesSet(string name, int length)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);
            Guard.AgainstNegativeValue(nameof(length), length);

            this.Name = name;
            this.Length = length;
        }

        internal SeriesSet()
        {
        }

        /// <summary>
        /// Number of data points each Series contains.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets the list of Series in the SeriesSet.
        /// </summary>
        public List<Series> Series { get; } = new List<Series>();

        internal static SeriesSet FromXElement(XElement seriesSetElement)
        {
            SeriesSet seriesSet = new SeriesSet();

            //// Import attributes for the implemented interfaces
            seriesSet.ImportISignableItemWithName(seriesSetElement);

            //// Import all other attributes
            seriesSet.Length = XmlConvert.ToInt32(seriesSetElement.Attribute("length").Value);

            //// Import the child elements of the current object
            seriesSet.Series.AddRange(seriesSetElement.Elements(NamespaceHelper.GetXName("Series")).Select(Blobfish.Series.FromXElement));

            return seriesSet;
        }

        internal XElement ToXElement()
        {
            XElement seriesSetElement = new XElement(NamespaceHelper.GetXName("SeriesSet"));

            //// Export attributes of all implemented interfaces
            seriesSetElement.ImportISignableItemWithName(this);

            //// Export all other attributes
            seriesSetElement.AddAttribute("length", XmlConvert.ToString(this.Length));

            //// Export the child elements of the current object
            this.Series.ForEach(s => seriesSetElement.Add(s.ToXElement()));

            return seriesSetElement;
        }
    }
}
