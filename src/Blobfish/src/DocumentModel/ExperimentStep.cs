namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Container that documents a step in an experiment. Use one ExperimentStep per application of a Technique.
    /// </summary>
    public class ExperimentStep : ISignableItemWithNameAndISourceDataLocationBase
    {
        /// <summary>
        /// Creates a new instance of the ExperimentStep class.
        /// </summary>
        /// <param name="name">The name of the ExperimentStep.</param>
        /// <param name="experimentStepId">The identifier of the ExperimentStep used within the AnIML document to identify and reference the ExperimentStep.</param>
        public ExperimentStep(string name, string experimentStepId)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);
            Guard.AgainstNullOrEmpty(nameof(experimentStepId), experimentStepId);

            this.Name = name;
            this.ExperimentStepId = experimentStepId;
        }

        internal ExperimentStep()
        {
        }

        /// <summary>
        /// Unstructured text comment to further describe the ExperimentStep.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for this ExperimentStep. Used to point to this step from an ExperimentDataReference.
        /// </summary>
        public string ExperimentStepId { get; set; }

        /// <summary>
        /// Gets or sets the Infrastructure of the ExperimentStep which contains references to its context.
        /// </summary>
        public Infrastructure Infrastructure { get; set; }

        /// <summary>
        /// Gets the Method that was used in the ExperimentStep.
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// Gets a list of Results for the ExperimentStep.
        /// </summary>
        public List<Result> Results { get; } = new List<Result>();

        /// <summary>
        /// Gets or sets a TagSet containing Tags for the ExperimentStep.
        /// </summary>
        public TagSet TagSet { get; set; }

        /// <summary>
        /// Gets or sets a Technique used in the ExperimentStep.
        /// </summary>
        public Technique Technique { get; set; }

        /// <summary>
        /// Gets the name of the Template the ExperimentStep is based on.
        /// </summary>
        public string TemplateUsed { get; set; }

        internal static ExperimentStep FromXElement(XElement experimentStepElement)
        {
            ExperimentStep experimentStep = new ExperimentStep();

            //// Import attributes for the implemented interfaces
            experimentStep.ImportISignableItemWithName(experimentStepElement);
            experimentStep.ImportISourceDataLocation(experimentStepElement);

            //// Import all other attributes
            experimentStep.ExperimentStepId = experimentStepElement.Attribute("experimentStepID").Value;
            experimentStep.TemplateUsed = experimentStepElement.Attribute("templateUsed")?.Value;
            experimentStep.Comment = experimentStepElement.Attribute("comment")?.Value;

            //// Import the child elements of the current object
            XElement tagSetElement = experimentStepElement.Elements(NamespaceHelper.GetXName("TagSet")).SingleOrDefault();
            if (tagSetElement != null)
            {
                experimentStep.TagSet = TagSet.FromXElement(tagSetElement);
            }

            XElement techniqueElement = experimentStepElement.Elements(NamespaceHelper.GetXName("Technique")).SingleOrDefault();
            if (techniqueElement != null)
            {
                experimentStep.Technique = Technique.FromXElement(techniqueElement);
            }

            XElement infrastructureElement = experimentStepElement.Elements(NamespaceHelper.GetXName("Infrastructure")).SingleOrDefault();
            if (infrastructureElement != null)
            {
                experimentStep.Infrastructure = Infrastructure.FromXElement(infrastructureElement);
            }

            XElement methodElement = experimentStepElement.Elements(NamespaceHelper.GetXName("Method")).SingleOrDefault();
            if (methodElement != null)
            {
                experimentStep.Method = Method.FromXElement(methodElement);
            }

            experimentStep.Results.AddRange(experimentStepElement.Elements(NamespaceHelper.GetXName("Result")).Select(Result.FromXElement));

            return experimentStep;
        }

        internal XElement ToXElement()
        {
            XElement experimentStepElement = new XElement(NamespaceHelper.GetXName("ExperimentStep"));

            //// Export attributes of all implemented interfaces
            experimentStepElement.ImportISignableItemWithName(this);
            experimentStepElement.ImportISourceDataLocation(this);

            //// Export all other attributes
            experimentStepElement.AddAttribute("experimentStepID", this.ExperimentStepId);
            experimentStepElement.AddAttributeIfValueNotNullOrEmpty("templateUsed", this.TemplateUsed);
            experimentStepElement.AddAttributeIfValueNotNullOrEmpty("comment", this.Comment);

            //// Export the child elements of the current object
            if (this.TagSet?.Tags.Count > 0)
            {
                experimentStepElement.Add(this.TagSet.ToXElement());
            }

            if (this.Technique != null)
            {
                experimentStepElement.Add(this.Technique.ToXElement());
            }

            if (this.Infrastructure != null)
            {
                experimentStepElement.Add(this.Infrastructure.ToXElement());
            }

            if (this.Method != null)
            {
                experimentStepElement.Add(this.Method.ToXElement());
            }

            this.Results.ForEach(e => experimentStepElement.Add(e.ToXElement()));

            return experimentStepElement;
        }
    }
}
