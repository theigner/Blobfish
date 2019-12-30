namespace Blobfish
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Reference to an Extension to amend the active Technique Definition.
    /// </summary>
    public class Extension
    {
        /// <summary>
        /// Creates a new instance of the Extension class.
        /// </summary>
        /// <param name="uri">The URI where Extension file can be fetched.</param>
        /// <param name="name">The name of the Extension to be used. Must match the Name given in Extension Definition file.</param>
        public Extension(string uri, string name)
            : this(new Uri(uri), name)
        {
        }

        /// <summary>
        /// Creates a new instance of the Extension class.
        /// </summary>
        /// <param name="uri">The URI where Extension file can be fetched.</param>
        /// <param name="name">The name of the Extension to be used. Must match the Name given in Extension Definition file.</param>
        public Extension(Uri uri, string name)
        {
            Guard.AgainstNull(nameof(uri), uri);
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Uri = uri;
            this.Name = name;
        }

        internal Extension()
        {
        }

        /// <summary>
        /// Gets or sets the URI where Extension file can be fetched.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the name of the Extension to be used. Must match the Name given in Extension Definition file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SHA256 checksum of the referenced Extension. Hex encoded, lower cased. Similar to the output of the sha256 unix command.
        /// </summary>
        public string Sha256 { get; set; }

        internal static Extension FromXElement(XElement extensionElement)
        {
            Extension extension = new Extension();

            //// Import all attributes
            extension.Uri = new Uri(extensionElement.Attribute("uri").Value);
            extension.Name = extensionElement.Attribute("name").Value;
            extension.Sha256 = extensionElement.Attribute("sha256")?.Value;

            return extension;
        }

        internal XElement ToXElement()
        {
            XElement extensionElement = new XElement(NamespaceHelper.GetXName("Extension"));

            //// Export all attributes
            extensionElement.AddAttribute("uri", this.Uri.OriginalString);
            extensionElement.AddAttribute("name", this.Name);
            extensionElement.AddAttributeIfValueNotNullOrEmpty("sha256", this.Sha256);

            return extensionElement;
        }
    }
}
