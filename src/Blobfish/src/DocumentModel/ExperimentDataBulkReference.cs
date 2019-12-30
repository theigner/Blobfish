namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Prefix-based reference to a set of Experiment Steps whose data are consumed.
    /// </summary>
    public class ExperimentDataBulkReference : ISignableItemWithExperimentDataAttributesBase
    {
        /// <summary>
        /// Creates a new instance of class ExperimentDataBulkReference.
        /// </summary>
        /// <param name="experimentStepIdPrefix">The prefix that is used to match the identifiers of the referenced ExperimentSteps.</param>
        /// <param name="role">Role the experiment data plays within the current ExperimentStep.</param>
        /// <param name="experimentDataPurpose">Specifies whether the referenced experiment data is produced or consumed by the current ExperimentStep.</param>
        public ExperimentDataBulkReference(string experimentStepIdPrefix, string role, ExperimentDataPurpose experimentDataPurpose)
        {
            Guard.AgainstNullOrEmpty(nameof(experimentStepIdPrefix), experimentStepIdPrefix);
            Guard.AgainstNullOrEmpty(nameof(role), role);

            this.ExperimentStepIdPrefix = experimentStepIdPrefix;
            this.Role = role;
            this.DataPurpose = experimentDataPurpose;
        }

        internal ExperimentDataBulkReference()
        {
        }

        /// <summary>
        /// Gets or sets the prefix that is used to match the identifiers of the referenced ExperimentSteps.
        /// </summary>
        public string ExperimentStepIdPrefix { get; set; }

        internal static ExperimentDataBulkReference FromXElement(XElement experimentDataBulkReferenceElement)
        {
            ExperimentDataBulkReference experimentDataBulkReference = new ExperimentDataBulkReference();

            //// Import attributes for the implemented interfaces
            experimentDataBulkReference.ImportISignableItem(experimentDataBulkReferenceElement);
            experimentDataBulkReference.ImportIExperimentDataAttributes(experimentDataBulkReferenceElement);

            //// Import all other attributes
            experimentDataBulkReference.ExperimentStepIdPrefix = experimentDataBulkReferenceElement.Attribute("experimentStepIDPrefix").Value;

            return experimentDataBulkReference;
        }

        internal XElement ToXElement()
        {
            XElement experimentDataBulkReferenceElement = new XElement(NamespaceHelper.GetXName("ExperimentDataBulkReference"));

            //// Export attributes of all implemented interfaces
            experimentDataBulkReferenceElement.ImportISignableItem(this);
            experimentDataBulkReferenceElement.ImportIExperimentDataAttributes(this);

            //// Export all other attributes
            experimentDataBulkReferenceElement.AddAttribute("experimentStepIDPrefix", this.ExperimentStepIdPrefix);

            return experimentDataBulkReferenceElement;
        }
    }
}
