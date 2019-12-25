namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Individual Sample, referenced from other parts of this AnIML document.
    /// </summary>
    public class Sample : ISignableItemWithNameAndISourceDataLocationBase
    {
        /// <summary>
        /// Creates a new instance of the Sample class.
        /// </summary>
        /// <param name="name">The name of the Sample.</param>
        /// <param name="sampleId">The identifier of the Sample used within the AnIML document to identify and reference the Sample.</param>
        public Sample(string name, string sampleId)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(sampleId), sampleId);
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Name = name;
            this.SampleId = sampleId;
        }

        internal Sample()
        {
        }

        /// <summary>
        /// Value of barcode label that is attached to sample container.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Gets a collection of Categories assigned to the Sample.
        /// </summary>
        public List<Category> Categories { get; } = new List<Category>();

        /// <summary>
        /// Unstructured text comment to further describe the Sample.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Sample ID of container in which this sample is located.
        /// </summary>
        public string ContainerId { get; set; }

        /// <summary>
        /// Whether this sample is also a container for other samples. Set to "simple" if not.
        /// </summary>
        public ContainerType? ContainerType { get; set; }

        /// <summary>
        /// Indicates whether this is a derived Sample. A derived Sample is a Sample that has been created by applying a Technique. (Sub-Sampling, Processing, ...)
        /// </summary>
        public bool? Derived { get; set; }

        /// <summary>
        /// Coordinates of this sample within the enclosing container. In case of microplates or trays, the row is identified by letters and the column is identified by numbers (1-based) while in landscape orientation. Examples: A10 = 1st row, 10th column, Z1 = 26th row, 1st column, AB2 = 28th row, 2nd column.
        /// </summary>
        public string LocationInContainer { get; set; }

        /// <summary>
        /// Gets the identfier of the Sample.
        /// </summary>
        public string SampleId { get; private set; }

        /// <summary>
        /// Gets or sets the TagSet for the Sample.
        /// </summary>
        public TagSet TagSet { get; set; }

        internal static Sample FromXElement(XElement sampleElement)
        {
            Sample sample = new Sample();

            //// Import attributes for the implemented interfaces
            sample.ImportISignableItemWithName(sampleElement);
            sample.ImportISourceDataLocation(sampleElement);

            //// Import all other attributes
            sample.SampleId = sampleElement.Attribute("sampleID").Value;
            sample.Barcode = sampleElement.Attribute("barcode")?.Value;
            sample.Comment = sampleElement.Attribute("comment")?.Value;

            XAttribute dervivedAttribute = sampleElement.Attribute("derived");
            if (dervivedAttribute != null)
            {
                sample.Derived = XmlConvert.ToBoolean(dervivedAttribute.Value);
            }

            XAttribute containerTypeAttribute = sampleElement.Attribute("containerType");
            if (containerTypeAttribute != null)
            {
                sample.ContainerType = EnumConverter.ImportContainerType(containerTypeAttribute.Value);
            }

            sample.ContainerId = sampleElement.Attribute("containerID")?.Value;
            sample.LocationInContainer = sampleElement.Attribute("locationInContainer")?.Value;

            //// Import the child elements of the current object
            XElement tagSetElement = sampleElement.Element(NamespaceHelper.GetXName("TagSet"));
            if (tagSetElement != null)
            {
                sample.TagSet = TagSet.FromXElement(tagSetElement);
            }

            sample.Categories.AddRange(sampleElement.Elements(NamespaceHelper.GetXName("Category")).Select(Category.FromXElement));

            return sample;
        }

        internal XElement ToXElement()
        {
            XElement sampleElement = new XElement(NamespaceHelper.GetXName("Sample"));

            //// Export attributes of all implemented interfaces
            sampleElement.ImportISignableItemWithName(this);
            sampleElement.ImportISourceDataLocation(this);

            //// Export all other attributes
            sampleElement.AddAttribute("sampleID", this.SampleId);
            sampleElement.AddAttributeIfValueNotNullOrEmpty("barcode", this.Barcode);
            sampleElement.AddAttributeIfValueNotNullOrEmpty("comment", this.Comment);
            sampleElement.AddAttributeIfNotNull("derived", this.Derived);
            sampleElement.AddAttributeIfNotNull("containerType", this.ContainerType);
            sampleElement.AddAttributeIfValueNotNullOrEmpty("containerID", this.ContainerId);
            sampleElement.AddAttributeIfValueNotNullOrEmpty("locationInContainer", this.LocationInContainer);

            //// Export the child elements of the current object
            
            //// Do not export an empty TagSet
            if (this.TagSet?.Tags.Count > 0)
            {
                sampleElement.Add(this.TagSet.ToXElement());
            }

            this.Categories.ForEach(c => sampleElement.Add(c.ToXElement()));

            return sampleElement;
        }
    }
}
