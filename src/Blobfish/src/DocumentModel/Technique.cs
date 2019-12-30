namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Reference to Technique Definition used in this Experiment.
    /// </summary>
    public class Technique : ISignableItemWithNameBase
    {
        /// <summary>
        /// Creates a new instance of the Technique class.
        /// </summary>
        /// <param name="uri">The URI where Technique Definition file can be fetched.</param>
        /// <param name="name">Plain-text name of this item.</param>
        public Technique(string uri, string name)
            : this(new Uri(uri), name)
        {
        }

        /// <summary>
        /// Creates a new instance of the Technique class.
        /// </summary>
        /// <param name="uri">the SHA256 checksum of the referenced Technique Definition</param>
        /// <param name="name">Plain-text name of this item.</param>
        public Technique(Uri uri, string name)
            : this()
        {
            Guard.AgainstNull(nameof(uri), uri);
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Uri = uri;
            this.Name = name;
        }

        internal Technique()
        {
        }

        /// <summary>
        /// Gets the Extensions that amend the referenced Technique.
        /// </summary>
        public List<Extension> Extensions { get; } = new List<Extension>();

        /// <summary>
        /// Gets or sets the URI where Technique Definition file can be fetched.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the SHA256 checksum of the referenced Technique Definition. Hex encoded, lower cased. Similar to the output of the sha256 unix command.
        /// </summary>
        public string Sha256 { get; set; }

        internal static Technique FromXElement(XElement techniqueElement)
        {
            Technique technique = new Technique();

            //// Import attributes for the implemented interfaces
            technique.ImportISignableItemWithName(techniqueElement);

            //// Import all other attributes
            technique.Uri = new Uri(techniqueElement.Attribute("uri").Value);
            technique.Sha256 = techniqueElement.Attribute("sha256")?.Value;

            //// Import the child elements of the current object
            technique.Extensions.AddRange(techniqueElement.Elements(NamespaceHelper.GetXName("Extension")).Select(Extension.FromXElement));

            return technique;
        }

        internal XElement ToXElement()
        {
            XElement techniqueElement = new XElement(NamespaceHelper.GetXName("Technique"));

            //// Export attributes of all implemented interfaces
            techniqueElement.ImportISignableItemWithName(this);

            //// Export all other attributes
            techniqueElement.AddAttribute("uri", this.Uri.OriginalString);
            techniqueElement.AddAttributeIfValueNotNullOrEmpty("sha256", this.Sha256);

            //// Export the child elements of the current object
            this.Extensions.ForEach(e => techniqueElement.Add(e.ToXElement()));

            return techniqueElement;
        }
    }
}
