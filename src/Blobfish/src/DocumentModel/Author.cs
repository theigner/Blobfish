namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Information about a person, a device or a piece of software authoring AnIML files.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Creates a new instance of the Author class.
        /// </summary>
        /// <param name="name">The common name of the Author.</param>
        /// <param name="userType"></param>
        public Author(string name, UserType userType)
        {
            this.Name = name;
            this.UserType = userType;
        }

        internal Author()
        {
        }

        /// <summary>
        /// Gets or sets the organization the Author is affiliated with.
        /// </summary>
        public string Affiliation { get; set; }

        /// <summary>
        /// Gets or sets the common name of the Author.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Role the Author plays within the organization.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the Authors email address. Must be RFC822-compliant.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Authors phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Authors location or physical address.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the type of user (human, device, software) the Author is.
        /// </summary>
        public UserType UserType { get; set; }

        internal static Author FromXElement(XElement authorElement)
        {
            Author author = new Author();

            //// Import all attributes
            author.UserType = authorElement.Attribute("userType").ImportUserType();

            //// Import the child elements of the current object
            author.Name = authorElement.Element(NamespaceHelper.GetXName("Name")).Value;
            author.Affiliation = authorElement.Element(NamespaceHelper.GetXName("Affiliation"))?.Value;
            author.Role = authorElement.Element(NamespaceHelper.GetXName("Role"))?.Value;
            author.Email = authorElement.Element(NamespaceHelper.GetXName("Email"))?.Value;
            author.Phone = authorElement.Element(NamespaceHelper.GetXName("Phone"))?.Value;
            author.Location = authorElement.Element(NamespaceHelper.GetXName("Location"))?.Value;

            return author;
        }

        internal XElement ToXElement()
        {
            XElement authorElement = new XElement(NamespaceHelper.GetXName("Author"));

            //// Export all attributes
            authorElement.AddAttribute("userType", this.UserType.GetXmlRepresentation());

            //// Export the child elements of the current object
            authorElement.AddElement("Name", this.Name);
            authorElement.AddElementIfValueNotNullOrEmpty("Affiliation", this.Affiliation);
            authorElement.AddElementIfValueNotNullOrEmpty("Role", this.Role);
            authorElement.AddElementIfValueNotNullOrEmpty("Email", this.Email);
            authorElement.AddElementIfValueNotNullOrEmpty("Phone", this.Phone);
            authorElement.AddElementIfValueNotNullOrEmpty("Location", this.Location);

            return authorElement;
        }
    }
}
