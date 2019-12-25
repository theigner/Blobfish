namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Set of Tag elements.
    /// </summary>
    public class TagSet
    {
        /// <summary>
        /// Initializes a new instance of the TagSet class.
        /// </summary>
        public TagSet()
        {
        }

        /// <summary>
        /// Gets a collection of Tags contained by the TagSet.
        /// </summary>
        public List<Tag> Tags { get; } = new List<Tag>();

        internal static TagSet FromXElement(XElement tagSetElement)
        {
            TagSet tagSet = new TagSet();

            //// Import the child elements of the current object
            tagSet.Tags.AddRange(tagSetElement.Elements(NamespaceHelper.GetXName("Tag")).Select(Tag.FromXElement));

            return tagSet;
        }

        internal XElement ToXElement()
        {
            XElement tagSetElement = new XElement(NamespaceHelper.GetXName("TagSet"));

            //// Export the child elements of the current object
            this.Tags.ForEach(t => tagSetElement.Add(t.ToXElement()));

            return tagSetElement;
        }
    }
}
