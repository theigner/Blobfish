namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents links to samples that were referenced or inherited in an ExperimentStep.
    /// </summary>
    public class SampleReferenceSet : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the SampleReferenceSet class.
        /// </summary>
        public SampleReferenceSet()
        {
        }

        /// <summary>
        /// Gets a list of samples that were referenced in an ExperimentStep.
        /// </summary>
        public List<SampleReference> SampleReferences { get; } = new List<SampleReference>();

        /// <summary>
        /// Gets a list of samples that were inherited by the ExperimentStep from its parent ExperimentStep.
        /// </summary>
        public List<SampleInheritance> SampleInheritances { get; } = new List<SampleInheritance>();

        internal static SampleReferenceSet FromXElement(XElement sampleReferenceSetElement)
        {
            SampleReferenceSet sampleReferenceSet = new SampleReferenceSet();

            //// Import attributes for the implemented interfaces
            sampleReferenceSet.ImportISignableItem(sampleReferenceSetElement);

            //// Import the child elements of the current object
            sampleReferenceSet.SampleReferences.AddRange(sampleReferenceSetElement.Elements(NamespaceHelper.GetXName("SampleReference")).Select(SampleReference.FromXElement));
            sampleReferenceSet.SampleInheritances.AddRange(sampleReferenceSetElement.Elements(NamespaceHelper.GetXName("SampleInheritance")).Select(SampleInheritance.FromXElement));

            return sampleReferenceSet;
        }

        internal XElement ToXElement()
        {
            XElement sampleReferenceSetElement = new XElement(NamespaceHelper.GetXName("SampleReferenceSet"));

            //// Export attributes of all implemented interfaces
            sampleReferenceSetElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            this.SampleReferences.ForEach(s => sampleReferenceSetElement.Add(s.ToXElement()));
            this.SampleInheritances.ForEach(s => sampleReferenceSetElement.Add(s.ToXElement()));

            return sampleReferenceSetElement;
        }
    }
}
