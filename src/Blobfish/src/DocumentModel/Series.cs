namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Container for multiple values.
    /// </summary>
    public class Series : ISignableItemWithNameBase
    {
        /// <summary>
        /// Creates a new instance of class Series.
        /// </summary>
        /// <param name="name">The name of the Series.</param>
        /// <param name="seriesId">Identifier for the Series. Must be unique per SeriesSet.</param>
        /// <param name="dependency">Determines whether the series is independent (values on the X-Axis) or dependent (Y-Values).</param>
        /// <param name="seriesType">The data type of the Series. All values of the Series must be of the same data type.</param>
        public Series(string name, string seriesId, Dependency dependency, SeriesType seriesType)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);
            Guard.AgainstNullOrEmpty(nameof(seriesId), seriesId);

            this.Name = name;
            this.SeriesId = seriesId;
            this.Dependency = dependency;
            this.SeriesType = seriesType;
        }

        internal Series()
        {
        }

        /// <summary>
        /// Specifies whether the Series is independent or dependent.
        /// </summary>
        public Dependency Dependency { get; private set; }

        /// <summary>
        /// Specifies whether the data in this Series is typically plotted on a linear or logarithmic scale.
        /// </summary>
        public PlotScale? PlotScale { get; set; }

        /// <summary>
        /// Data type used by all values in this Series.
        /// </summary>
        public SeriesType SeriesType { get; private set; }

        /// <summary>
        /// Identifies the Series. Used in References from subordinate ExperimentSteps. Unique per SeriesSet.
        /// </summary>
        public string SeriesId { get; private set; }

        /// <summary>
        /// The scientific unit that applies to all values of the Series.
        /// </summary>
        /// <remarks>The unit defined for the Series is used to label the axis when displaying the Series data in a chart.</remarks>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets the list of ValueSets in the Series.
        /// </summary>
        public List<IValueSet> ValueSets { get; } = new List<IValueSet>();

        /// <summary>
        /// Specifes whether a Series should be displayed by default.
        /// </summary>
        public bool? Visible { get; set; }

        internal static Series FromXElement(XElement seriesElement)
        {
            Series series = new Series();

            //// Import attributes for the interfaces a Series implements
            series.ImportISignableItemWithName(seriesElement);

            //// Import all other attributes for a Series
            series.Dependency = seriesElement.Attribute("dependency").ImportDependency();
            series.SeriesId = seriesElement.Attribute("seriesID").Value;

            XAttribute visibleAttribute = seriesElement.Attribute("visible");
            if (visibleAttribute != null)
            {
                series.Visible = XmlConvert.ToBoolean(visibleAttribute.Value);
            }

            XAttribute plotScaleAttribute = seriesElement.Attribute("plotScale");
            if (plotScaleAttribute != null)
            {
                series.PlotScale = plotScaleAttribute.ImportPlotScale();
            }

            series.SeriesType = seriesElement.Attribute("seriesType").ImportSeriesType();

            //// Import the child elements of the Series
            series.ValueSets.AddRange(seriesElement.Elements(NamespaceHelper.GetXName("IndividualValueSet")).Select(x => IndividualValueSet.FromXElement(x, series.SeriesType)));
            series.ValueSets.AddRange(seriesElement.Elements(NamespaceHelper.GetXName("EncodedValueSet")).Select(x => EncodedValueSet.FromXElement(x, series.SeriesType)));
            series.ValueSets.AddRange(seriesElement.Elements(NamespaceHelper.GetXName("AutoIncrementedValueSet")).Select(x => AutoIncrementedValueSet.FromXElement(x, series.SeriesType)));

            XElement unitElement = seriesElement.Element(NamespaceHelper.GetXName("Unit"));
            if (unitElement != null)
            {
                series.Unit = Unit.FromXElement(unitElement);
            }

            return series;
        }

        internal XElement ToXElement()
        {
            XElement seriesElement = new XElement(NamespaceHelper.GetXName("Series"));

            //// Export attributes of all implemented interfaces
            seriesElement.ImportISignableItemWithName(this);

            //// Export all other attributes
            seriesElement.AddAttribute("dependency", this.Dependency.GetXmlRepresentation());
            seriesElement.AddAttribute("seriesID", this.SeriesId);
            seriesElement.AddAttributeIfNotNull("visible", this.Visible);

            if (this.PlotScale.HasValue)
            {
                seriesElement.AddAttribute("plotScale", this.PlotScale.Value.GetXmlRepresentation());
            }

            seriesElement.AddAttribute("seriesType", this.SeriesType.GetXmlRepresentation());

            //// Export the child elements of the current object
            foreach (IValueSet valueSet in this.ValueSets)
            {
                if (valueSet is IndividualValueSet indValueSet)
                {
                    seriesElement.Add(indValueSet.ToXElement());
                }
                else if (valueSet is EncodedValueSet encValueSet)
                {
                    seriesElement.Add(encValueSet.ToXElement());
                }
                else if (valueSet is AutoIncrementedValueSet autoIncValueSet)
                {
                    seriesElement.Add(autoIncValueSet.ToXElement());
                }
            }

            if (this.Unit != null)
            {
                seriesElement.Add(this.Unit.ToXElement());
            }

            return seriesElement;
        }
    }
}
