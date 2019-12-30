namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Software used to author this.
    /// </summary>
    public class Software
    {
        /// <summary>
        /// Creates a new instance of the Software class.
        /// </summary>
        /// <param name="name">The common name of the Software.</param>
        public Software(string name)
        {
            this.Name = name;
        }

        internal Software()
        {
        }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the common name of the Software.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version identifier of a Software release.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the operating system the Software was running on.
        /// </summary>
        public string OperatingSystem { get; set; }

        internal static Software FromXElement(XElement softwareElement)
        {
            Software software = new Software();

            //// Import the child elements of the current object
            software.Manufacturer = softwareElement.Element(NamespaceHelper.GetXName("Manufacturer"))?.Value;
            software.Name = softwareElement.Element(NamespaceHelper.GetXName("Name")).Value;
            software.Version = softwareElement.Element(NamespaceHelper.GetXName("Version"))?.Value;
            software.OperatingSystem = softwareElement.Element(NamespaceHelper.GetXName("OperatingSystem"))?.Value;

            return software;
        }

        internal XElement ToXElement()
        {
            XElement softwareElement = new XElement(NamespaceHelper.GetXName("Software"));

            softwareElement.AddElementIfValueNotNullOrEmpty("Manufacturer", this.Manufacturer);
            softwareElement.AddElement("Name", this.Name);
            softwareElement.AddElementIfValueNotNullOrEmpty("Version", this.Version);
            softwareElement.AddElementIfValueNotNullOrEmpty("OperatingSystem", this.OperatingSystem);

            return softwareElement;
        }
    }
}
