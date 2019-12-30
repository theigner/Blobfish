namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Defines the context of an ExperimentStep.
    /// </summary>
    public class Infrastructure : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the Infrastructure class.
        /// </summary>
        public Infrastructure()
        {
        }

        /// <summary>
        /// Gets or sets the SampleReferenceSet in that the relation of the ExperimentStep to Samples is described.
        /// </summary>
        public SampleReferenceSet SampleReferencetSet { get; set; }

        /// <summary>
        /// Gets or sets the ParentDataPointReferenceSet in that the relation to parent Results is described.
        /// </summary>
        public ParentDataPointReferenceSet ParentDataPointReferenceSet { get; set; }
        
        /// <summary>
        /// Gets or sets the ExperimentDataReferenceSet in that the relation to other ExperimentSteps is described.
        /// </summary>
        public ExperimentDataReferenceSet ExperimentDataReferenceSet { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the Experiment.
        /// </summary>
        public DateTime? Timestamp { get; set; }

        internal static Infrastructure FromXElement(XElement infrastructureElement)
        {
            Infrastructure infrastructure = new Infrastructure();

            //// Import attributes for the implemented interfaces
            infrastructure.ImportISignableItem(infrastructureElement);

            //// Import the child elements of the current object
            XElement sampleReferenceSetElement = infrastructureElement.Element(NamespaceHelper.GetXName("SampleReferenceSet"));
            if (sampleReferenceSetElement != null)
            {
                infrastructure.SampleReferencetSet = SampleReferenceSet.FromXElement(sampleReferenceSetElement);
            }

            XElement parentDataPointReferenceSetElement = infrastructureElement.Element(NamespaceHelper.GetXName("ParentDataPointReferenceSet"));
            if (parentDataPointReferenceSetElement != null)
            {
                infrastructure.ParentDataPointReferenceSet = ParentDataPointReferenceSet.FromXElement(parentDataPointReferenceSetElement);
            }

            XElement experimentDataReferenceSetElement = infrastructureElement.Element(NamespaceHelper.GetXName("ExperimentDataReferenceSet"));
            if (experimentDataReferenceSetElement != null)
            {
                infrastructure.ExperimentDataReferenceSet = ExperimentDataReferenceSet.FromXElement(experimentDataReferenceSetElement);
            }

            XElement timestampElement = infrastructureElement.Element(NamespaceHelper.GetXName("Timestamp"));
            if (timestampElement != null)
            {
                infrastructure.Timestamp = XmlConvert.ToDateTime(timestampElement.Value, XmlDateTimeSerializationMode.Utc);
            }

            return infrastructure;
        }

        internal XElement ToXElement()
        {
            XElement infrastructureElement = new XElement(NamespaceHelper.GetXName("Infrastructure"));

            //// Export attributes of all implemented interfaces
            infrastructureElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            if (this.SampleReferencetSet != null)
            {
                infrastructureElement.Add(this.SampleReferencetSet.ToXElement());
            }

            if (this.ParentDataPointReferenceSet != null)
            {
                infrastructureElement.Add(this.ParentDataPointReferenceSet.ToXElement());
            }

            if (this.ExperimentDataReferenceSet != null)
            {
                infrastructureElement.Add(this.ExperimentDataReferenceSet.ToXElement());
            }

            if (this.Timestamp.HasValue)
            {
                infrastructureElement.Add(new XElement(NamespaceHelper.GetXName("Timestamp"), XmlConvert.ToString(this.Timestamp.Value, XmlDateTimeSerializationMode.Utc)));
            }

            return infrastructureElement;
        }
    }
}
