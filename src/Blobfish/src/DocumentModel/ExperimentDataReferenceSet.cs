namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents relations between ExperimentSteps.
    /// </summary>
    public class ExperimentDataReferenceSet : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the ExperimentDataReferenceSet class.
        /// </summary>
        public ExperimentDataReferenceSet()
        {
        }

        /// <summary>
        /// Gets or sets the references to other ExperimentSteps.
        /// </summary>
        public List<ExperimentDataReference> ExperimentDataReferences { get; } = new List<ExperimentDataReference>();

        /// <summary>
        /// Gets or sets bulk references that reference other ExperimentSteps based on prefixes of their identifiers.
        /// </summary>
        public List<ExperimentDataBulkReference> ExperimentDataBulkReferences { get; } = new List<ExperimentDataBulkReference>();

        internal static ExperimentDataReferenceSet FromXElement(XElement sampleReferenceSetElement)
        {
            ExperimentDataReferenceSet experimentDataReferenceSet = new ExperimentDataReferenceSet();

            //// Import attributes for the implemented interfaces
            experimentDataReferenceSet.ImportISignableItem(sampleReferenceSetElement);

            //// Import the child elements of the current object
            experimentDataReferenceSet.ExperimentDataReferences.AddRange(sampleReferenceSetElement.Elements(NamespaceHelper.GetXName("ExperimentDataReference")).Select(ExperimentDataReference.FromXElement));
            experimentDataReferenceSet.ExperimentDataBulkReferences.AddRange(sampleReferenceSetElement.Elements(NamespaceHelper.GetXName("ExperimentDataBulkReference")).Select(ExperimentDataBulkReference.FromXElement));

            return experimentDataReferenceSet;
        }

        internal XElement ToXElement()
        {
            XElement experimentDataReferenceSetElement = new XElement(NamespaceHelper.GetXName("ExperimentDataReferenceSet"));

            //// Export attributes of all implemented interfaces
            experimentDataReferenceSetElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            this.ExperimentDataReferences.ForEach(s => experimentDataReferenceSetElement.Add(s.ToXElement()));
            this.ExperimentDataBulkReferences.ForEach(s => experimentDataReferenceSetElement.Add(s.ToXElement()));

            return experimentDataReferenceSetElement;
        }
    }
}
