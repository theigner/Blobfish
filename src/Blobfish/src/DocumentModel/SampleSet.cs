namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Container for Samples used in this AnIML document.
    /// </summary>
    public class SampleSet : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of a SampleSet.
        /// </summary>
        public SampleSet()
        {
        }

        /// <summary>
        /// A collection of samples of the AnIML document.
        /// </summary>
        public List<Sample> Samples { get; } = new List<Sample>();

        internal static SampleSet FromXElement(XElement sampleSetElement)
        {
            if (sampleSetElement is null)
            {
                return null;
            }

            SampleSet sampleSet = new SampleSet();

            //// Import attributes for the implemented interfaces
            sampleSet.ImportISignableItem(sampleSetElement);

            //// Import the child elements of the current object
            sampleSet.Samples.AddRange(sampleSetElement.Elements(NamespaceHelper.GetXName("Sample")).Select(Sample.FromXElement));
            return sampleSet;
        }

        internal XElement ToXElement()
        {
            XElement sampleSetElement = new XElement(NamespaceHelper.GetXName("SampleSet"));

            //// Export attributes of all implemented interfaces
            sampleSetElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            this.Samples.ForEach(s => sampleSetElement.Add(s.ToXElement()));

            return sampleSetElement;
        }
    }
}
