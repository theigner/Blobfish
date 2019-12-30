namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Contains references to the parent Result.
    /// </summary>
    public class ParentDataPointReferenceSet
    {
        /// <summary>
        /// Creates a new instance of class ParentDataPointReferenceSet.
        /// </summary>
        public ParentDataPointReferenceSet()
        {
        }

        /// <summary>
        /// Gets the references to the parent Results.
        /// </summary>
        public List<ParentDataPointReference> ParentDataPointReferences { get; } = new List<ParentDataPointReference>();

        internal static ParentDataPointReferenceSet FromXElement(XElement parentDataPointReferenceSetElement)
        {
            ParentDataPointReferenceSet parentDataPointReferenceSet = new ParentDataPointReferenceSet();

            //// Import the child elements of the current object
            parentDataPointReferenceSet.ParentDataPointReferences.AddRange(parentDataPointReferenceSetElement.Elements(NamespaceHelper.GetXName("ParentDataPointReference")).Select(ParentDataPointReference.FromXElement));

            return parentDataPointReferenceSet;
        }

        internal XElement ToXElement()
        {
            XElement parentDataPointReferenceSetElement = new XElement(NamespaceHelper.GetXName("ParentDataPointReferenceSet"));

            //// Export the child elements of the current object
            this.ParentDataPointReferences.ForEach(p => parentDataPointReferenceSetElement.Add(p.ToXElement()));

            return parentDataPointReferenceSetElement;
        }
    }
}
