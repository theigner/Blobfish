namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Container for multiple ExperimentSteps that describe the process and results.
    /// </summary>
    public class ExperimentStepSet : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the ExperimentStepSet class.
        /// </summary>
        public ExperimentStepSet()
        {
        }

        /// <summary>
        /// Gets the ExperimentSteps in the ExperimentStepSet.
        /// </summary>
        public List<ExperimentStep> ExperimentSteps { get; } = new List<ExperimentStep>();

        /// <summary>
        /// Gets the Templates for the ExperimentSteps in the ExperimentStepSet.
        /// </summary>
        public List<Template> Templates { get; } = new List<Template>();

        internal static ExperimentStepSet FromXElement(XElement experimentStepSetElement)
        {
            if (experimentStepSetElement is null)
            {
                return null;
            }

            ExperimentStepSet experimentStepSet = new ExperimentStepSet();

            //// Import attributes for the implemented interfaces
            experimentStepSet.ImportISignableItem(experimentStepSetElement);

            //// Import the child elements of the current object
            experimentStepSet.ExperimentSteps.AddRange(experimentStepSetElement.Elements(NamespaceHelper.GetXName("ExperimentStep")).Select(ExperimentStep.FromXElement));
            experimentStepSet.Templates.AddRange(experimentStepSetElement.Elements(NamespaceHelper.GetXName("Template")).Select(Template.FromXElement));

            return experimentStepSet;
        }

        internal XElement ToXElement()
        {
            XElement experimentStepSetElement = new XElement(NamespaceHelper.GetXName("ExperimentStepSet"));

            //// Export attributes of all implemented interfaces
            experimentStepSetElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            this.ExperimentSteps.ForEach(s => experimentStepSetElement.Add(s.ToXElement()));
            this.Templates.ForEach(t => experimentStepSetElement.Add(t.ToXElement()));

            return experimentStepSetElement;
        }
    }
}
