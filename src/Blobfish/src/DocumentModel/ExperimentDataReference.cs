namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Reference to an Experiment Step whose data are consumed.
    /// </summary>
    public class ExperimentDataReference : ISignableItemWithExperimentDataAttributesBase
    {
        /// <summary>
        /// Creates a new instance of class ExperimentDataReference.
        /// </summary>
        /// <param name="experimentStepId">The identifier of the referenced ExperimentStep.</param>
        /// <param name="role">Role the experiment data plays within the current ExperimentStep.</param>
        /// <param name="experimentDataPurpose">Specifies whether the referenced experiment data is produced or consumed by the current ExperimentStep.</param>
        public ExperimentDataReference(string experimentStepId, string role, ExperimentDataPurpose experimentDataPurpose)
        {
            Guard.AgainstNullOrEmpty(nameof(experimentStepId), experimentStepId);
            Guard.AgainstNullOrEmpty(nameof(role), role); ;

            this.ExperimentStepId = experimentStepId;
            this.Role = role;
            this.DataPurpose = experimentDataPurpose;
        }

        internal ExperimentDataReference()
        {
        }

        /// <summary>
        /// Gets or sets the identifier of the referenced ExperimentStep.
        /// </summary>
        public string ExperimentStepId { get; set; }

        internal static ExperimentDataReference FromXElement(XElement experimentDataReferenceElement)
        {
            ExperimentDataReference experimentDataReference = new ExperimentDataReference();

            //// Import attributes for the implemented interfaces
            experimentDataReference.ImportISignableItem(experimentDataReferenceElement);
            experimentDataReference.ImportIExperimentDataAttributes(experimentDataReferenceElement);

            //// Import all other attributes
            experimentDataReference.ExperimentStepId = experimentDataReferenceElement.Attribute("experimentStepID").Value;

            return experimentDataReference;
        }

        internal XElement ToXElement()
        {
            XElement experimentDataReferenceElement = new XElement(NamespaceHelper.GetXName("ExperimentDataReference"));

            //// Export attributes of all implemented interfaces
            experimentDataReferenceElement.ImportISignableItem(this);
            experimentDataReferenceElement.ImportIExperimentDataAttributes(this);

            //// Export all other attributes
            experimentDataReferenceElement.AddAttribute("experimentStepID", this.ExperimentStepId);

            return experimentDataReferenceElement;
        }
    }
}
