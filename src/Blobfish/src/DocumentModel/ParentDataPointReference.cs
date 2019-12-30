namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Reference to a data point or value range in an independent Series in the parent Result.
    /// </summary>
    public class ParentDataPointReference : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of class ParentDataPointReference.
        /// </summary>
        /// <param name="seriesId">The identifier of the Series from that data points are referenced.</param>
        public ParentDataPointReference(string seriesId)
        {
            this.SeriesId = seriesId;
        }

        internal ParentDataPointReference()
        {
        }

        /// <summary>
        /// The identifier of the Series from that data points are referenced.
        /// </summary>
        public string SeriesId { get; set; }

        /// <summary>
        /// The upper boundary of the referenced values.
        /// </summary>
        public dynamic EndValue { get; set; }

        /// <summary>
        /// The lower boundary of the referenced values.
        /// </summary>
        public dynamic StartValue { get; set; }

        internal static ParentDataPointReference FromXElement(XElement parentDataPointReferenceElement)
        {
            ParentDataPointReference parentDataPointReference = new ParentDataPointReference();

            //// Import attributes for the implemented interfaces
            parentDataPointReference.ImportISignableItem(parentDataPointReferenceElement);

            //// Import all other attributes
            parentDataPointReference.SeriesId = parentDataPointReferenceElement.Attribute("seriesID").Value;

            //// Import the child elements of the current object
            parentDataPointReference.StartValue = parentDataPointReferenceElement.Element(NamespaceHelper.GetXName("StartValue")).ImportNumericValue();

            XElement endValueElement = parentDataPointReferenceElement.Element(NamespaceHelper.GetXName("EndValue"));
            if (endValueElement != null)
            {
                parentDataPointReference.EndValue = endValueElement.ImportNumericValue();
            }

            return parentDataPointReference;
        }

        internal XElement ToXElement()
        {
            XElement parentDataPointReferenceElement = new XElement(NamespaceHelper.GetXName("ParentDataPointReference"));

            //// Export attributes of all implemented interfaces
            parentDataPointReferenceElement.ImportISignableItem(this);

            //// Export all other attributes
            parentDataPointReferenceElement.AddAttribute("seriesID", this.SeriesId);

            //// Export the child elements of the current object
            XElement startValueElement = new XElement(NamespaceHelper.GetXName("StartValue"));
            startValueElement.Add(DynamicValueHelper.XElementFromValue(this.StartValue));
            parentDataPointReferenceElement.Add(startValueElement);

            if (this.EndValue != null)
            {
                XElement endValueElement = new XElement(NamespaceHelper.GetXName("EndValue"));
                endValueElement.Add(DynamicValueHelper.XElementFromValue(this.EndValue));
                parentDataPointReferenceElement.Add(endValueElement);
            }

            return parentDataPointReferenceElement;
        }
    }
}
