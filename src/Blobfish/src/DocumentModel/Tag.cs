namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Tag to mark related data items. When a value is given, it may also serve as a reference to an external data system.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Initializes a new instance of the Tag class.
        /// </summary>
        /// <param name="name">The name of the Tag.</param>
        /// <exception cref="System.ArgumentException">Thrown when name is null or an empty string.</exception>
        public Tag(string name)
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the Tag class.
        /// </summary>
        /// <param name="name">The name of the Tag.</param>
        /// <param name="value">The value of the Tag.</param>
        /// <exception cref="System.ArgumentException">Thrown when name is null or an empty string.</exception>
        public Tag(string name, string value)
            : this(name)
        {
            this.Value = value;
        }

        internal Tag()
        {
        }

        /// <summary>
        /// Gets or sets the name of the Tag.
        /// </summary>
        /// <remarks>The name of a Tag must not be null or empty according to the AnIML core schema.</remarks>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or sets the value of the tag.
        /// </summary>
        /// <remarks>The value of a Tag may be null or empty according to the AnIML core schema where the attribute is marked as optional.</remarks>
        public string Value { get; set; }

        internal static Tag FromXElement(XElement tagSetElement)
        {
            Tag tag = new Tag();

            //// Import all attributes
            tag.Name = tagSetElement.Attribute("name").Value;
            tag.Value = tagSetElement.Attribute("value")?.Value;

            return tag;
        }

        internal XElement ToXElement()
        {
            XElement tagElement = new XElement(NamespaceHelper.GetXName("Tag"));

            // Export all attributes
            tagElement.AddAttribute("name", this.Name);
            tagElement.AddAttributeIfValueNotNullOrEmpty("value", this.Value);

            return tagElement;
        }
    }
}
