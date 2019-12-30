namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Describes how this Experiment was performed.
    /// </summary>
    public class Method : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the Method class.
        /// </summary>
        public Method()
        {
        }

        /// <summary>
        /// Gets or sets information about a person, a device or a piece of software authoring AnIML files.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Gets the Category list assigned to the Method.
        /// </summary>
        public List<Category> Categories { get; } = new List<Category>();

        /// <summary>
        /// Gets or sets information about the Device used to perform experiment.
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// Gets or sets information about the Software used to perform an Experiment.
        /// </summary>
        public Software Software { get; set; }

        /// <summary>
        /// Optional method name, as defined in the instrument software.
        /// </summary>
        public string Name { get; set; }

        internal static Method FromXElement(XElement methodElement)
        {
            Method method = new Method();

            //// Import attributes for the implemented interfaces
            method.ImportISignableItem(methodElement);

            //// Import all other attributes
            method.Name = methodElement.Attribute("name")?.Value;

            //// Import the child elements of the current object
            XElement authorElement = methodElement.Elements(NamespaceHelper.GetXName("Author")).SingleOrDefault();
            if (authorElement != null)
            {
                method.Author = Author.FromXElement(authorElement);
            }

            XElement deviceElement = methodElement.Elements(NamespaceHelper.GetXName("Device")).SingleOrDefault();
            if (deviceElement != null)
            {
                method.Device = Device.FromXElement(deviceElement);
            }

            XElement softwareElement = methodElement.Elements(NamespaceHelper.GetXName("Software")).SingleOrDefault();
            if (softwareElement != null)
            {
                method.Software = Software.FromXElement(softwareElement);
            }

            method.Categories.AddRange(methodElement.Elements(NamespaceHelper.GetXName("Category")).Select(Category.FromXElement));

            return method;
        }

        internal XElement ToXElement()
        {
            XElement methodElement = new XElement(NamespaceHelper.GetXName("Method"));

            //// Export attributes of all implemented interfaces
            methodElement.ImportISignableItem(this);

            //// Export all other attributes
            methodElement.AddAttributeIfValueNotNullOrEmpty("name", this.Name);

            //// Export the child elements of the current object
            if (this.Author != null)
            {
                methodElement.Add(this.Author.ToXElement());
            }

            if (this.Device != null)
            {
                methodElement.Add(this.Device.ToXElement());
            }

            if (this.Software != null)
            {
                methodElement.Add(this.Software.ToXElement());
            }

            if (this.Categories?.Count > 0)
            {
                this.Categories.ForEach(c => methodElement.Add(c.ToXElement()));
            }

            return methodElement;
        }
    }
}
