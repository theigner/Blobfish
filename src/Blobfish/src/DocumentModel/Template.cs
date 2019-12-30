namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a template for an ExperimentStep.
    /// </summary>
    public class Template : ISignableItemWithNameAndISourceDataLocationBase
    {
        /// <summary>
        /// Creates a new instance of the Template class.
        /// </summary>
        /// <param name="name">The name of the Template.</param>
        /// <param name="templateId">The identifier of the Template used within the AnIML document to identify and reference this Template from an ExperimentSteps.</param>
        public Template(string name, string templateId)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);
            Guard.AgainstNullOrEmpty(nameof(templateId), templateId);

            this.Name = name;
            this.TemplateId = templateId;
        }

        internal Template()
        {
        }

        /// <summary>
        /// Gets or sets the Infrastructure of the ExperimentStep which contains references to its context.
        /// </summary>
        public Infrastructure Infrastructure { get; set; }

        /// <summary>
        /// Gets the Method used in the ExperimentStep.
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
        /// Gets or sets the unique identifier for this Template. Used to point to this Template from an ExperimentStep.
        /// </summary>
        public string TemplateId { get; set; }

        internal static Template FromXElement(XElement templateElement)
        {
            Template template = new Template();

            //// Import attributes for the implemented interfaces
            template.ImportISignableItemWithName(templateElement);
            template.ImportISourceDataLocation(templateElement);

            //// Import all other attributes
            template.TemplateId = templateElement.Attribute("templateId").Value;

            //// Import the child elements of the current object
            XElement tagSetElement = templateElement.Element(NamespaceHelper.GetXName("TagSet"));
            if (tagSetElement != null)
            {
                template.TagSet = TagSet.FromXElement(tagSetElement);
            }

            XElement techniqueElement = templateElement.Element(NamespaceHelper.GetXName("Technique"));
            if (techniqueElement != null)
            {
                template.Technique = Technique.FromXElement(techniqueElement);
            }

            XElement infrastructureElement = templateElement.Element(NamespaceHelper.GetXName("Infrastructure"));
            if (infrastructureElement != null)
            {
                template.Infrastructure = Infrastructure.FromXElement(infrastructureElement);
            }

            XElement methodElement = templateElement.Element(NamespaceHelper.GetXName("Method"));
            if (methodElement != null)
            {
                template.Method = Method.FromXElement(methodElement);
            }

            template.Results.AddRange(templateElement.Elements(NamespaceHelper.GetXName("Result")).Select(Result.FromXElement));

            return template;
        }

        internal XElement ToXElement()
        {
            XElement templateElement = new XElement(NamespaceHelper.GetXName("Template"));

            //// Export attributes of all implemented interfaces
            templateElement.ImportISignableItemWithName(this);
            templateElement.ImportISourceDataLocation(this);

            //// Export all other attributes
            templateElement.AddAttribute("templateID", this.TemplateId);

            //// Export the child elements of the current object
            if (this.TagSet?.Tags?.Count > 0)
            {
                templateElement.Add(this.TagSet.ToXElement());
            }

            if (this.Technique != null)
            {
                templateElement.Add(this.Technique.ToXElement());
            }

            if (this.Infrastructure != null)
            {
                templateElement.Add(this.Infrastructure.ToXElement());
            }

            if (this.Method != null)
            {
                templateElement.Add(this.Method.ToXElement());
            }

            if (this.Results?.Count > 0)
            {
                this.Results.ForEach(r => templateElement.Add(r.ToXElement()));
            }

            return templateElement;
        }
    }
}
