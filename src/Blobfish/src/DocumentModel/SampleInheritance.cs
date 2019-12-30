namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Inheritance of a Sample from the parent ExperimentStep.
    /// </summary>
    public class SampleInheritance : ISignableItemWithSampleAttributesBase
    {
        /// <summary>
        /// Creates a new instance of class SampleReference.
        /// </summary>
        /// <param name="role">The role of the sample in the ExperimentStep.</param>
        /// <param name="samplePurpose">The purpose of the sample in the ExperimentStep.</param>
        public SampleInheritance(string role, SamplePurpose samplePurpose)
        {
            Guard.AgainstNullOrEmpty(nameof(role), role);

            this.Role = role;
            this.SamplePurpose = samplePurpose;
        }

        internal SampleInheritance()
        {
        }

        internal static SampleInheritance FromXElement(XElement sampleReferenceElement)
        {
            SampleInheritance sampleInheritance = new SampleInheritance();

            //// Import attributes for the implemented interfaces
            sampleInheritance.ImportISignableItem(sampleReferenceElement);
            sampleInheritance.ImportISampleAttributes(sampleReferenceElement);

            return sampleInheritance;
        }

        internal XElement ToXElement()
        {
            XElement sampleInheritanceElement = new XElement(NamespaceHelper.GetXName("SampleInheritance"));

            //// Export attributes of all implemented interfaces
            sampleInheritanceElement.ImportISignableItem(this);
            sampleInheritanceElement.ImportISampleAttributes(this);

            return sampleInheritanceElement;
        }
    }
}
