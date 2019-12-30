namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Container for audit trail entries describing changes to this document.
    /// </summary>
    public class AuditTrailEntrySet : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the AuditTrailEntrySet class.
        /// </summary>
        public AuditTrailEntrySet()
        {
        }

        /// <summary>
        /// Gets the list of AuditTrailEntries describing the changes to this document.
        /// </summary>
        public List<AuditTrailEntry> AuditTrailEntries { get; } = new List<AuditTrailEntry>();

        internal static AuditTrailEntrySet FromXElement(XElement auditTrailEntrySetElement)
        {
            if (auditTrailEntrySetElement is null)
            {
                return null;
            }

            AuditTrailEntrySet auditTrailEntrySet = new AuditTrailEntrySet();

            //// Import attributes for the implemented interfaces
            auditTrailEntrySet.ImportISignableItem(auditTrailEntrySetElement);

            //// Import the child elements of the current object
            auditTrailEntrySet.AuditTrailEntries.AddRange(auditTrailEntrySetElement.Elements(NamespaceHelper.GetXName("AuditTrailEntry")).Select(AuditTrailEntry.FromXElement));

            return auditTrailEntrySet;
        }

        internal XElement ToXElement()
        {
            XElement auditTrailEntrySetElement = new XElement(NamespaceHelper.GetXName("AuditTrailEntrySet"));

            //// Export attributes of all implemented interfaces
            auditTrailEntrySetElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            this.AuditTrailEntries.ForEach(a => auditTrailEntrySetElement.Add(a.ToXElement()));

            return auditTrailEntrySetElement;
        }
    }
}
