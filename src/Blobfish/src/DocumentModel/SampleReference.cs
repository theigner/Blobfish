namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Reference to a Sample used in this Experiment.
    /// </summary>
    public class SampleReference : ISignableItemWithSampleAttributesBase
    {
        /// <summary>
        /// Creates a new instance of class SampleReference.
        /// </summary>
        /// <param name="sampleId">The identifier of the referenced sample.</param>
        /// <param name="role">The role of the sample in the ExperimentStep.</param>
        /// <param name="samplePurpose">The purpose of the sample in the ExperimentStep.</param>
        public SampleReference(string sampleId, string role, SamplePurpose samplePurpose)
        {
            Guard.AgainstNullOrEmpty(nameof(sampleId), sampleId);
            Guard.AgainstNullOrEmpty(nameof(role), role);

            this.SampleId = sampleId;
            this.Role = role;
            this.SamplePurpose = samplePurpose;
        }

        internal SampleReference()
        {
        }

        /// <summary>
        /// Gets or sets the identifier of the referenced sample.
        /// </summary>
        public string SampleId { get; set; }

        internal static SampleReference FromXElement(XElement sampleReferenceElement)
        {
            SampleReference sampleReference = new SampleReference();

            //// Import attributes for the implemented interfaces
            sampleReference.ImportISignableItem(sampleReferenceElement);
            sampleReference.ImportISampleAttributes(sampleReferenceElement);

            //// Import all other attributes
            sampleReference.SampleId = sampleReferenceElement.Attribute("sampleID").Value;

            return sampleReference;
        }

        internal XElement ToXElement()
        {
            XElement sampleReferenceElement = new XElement(NamespaceHelper.GetXName("SampleReference"));

            //// Export attributes of all implemented interfaces
            sampleReferenceElement.ImportISignableItem(this);
            sampleReferenceElement.ImportISampleAttributes(this);

            //// Export all other attributes
            sampleReferenceElement.AddAttribute("sampleID", this.SampleId);

            return sampleReferenceElement;
        }
    }
}
