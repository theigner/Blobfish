namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Describes a set of changes made to the particular AnIML document by one user at a given time.
    /// </summary>
    public class AuditTrailEntry : ISignableItemBase
    {
        /// <summary>
        /// Creates a new instance of the AuditTrailEntry class.
        /// </summary>
        /// <param name="timestamp">The timestamp of the modification.</param>
        /// <param name="author">Information about the author or the modification.</param>
        /// <param name="action">The type of change made.</param>
        public AuditTrailEntry(DateTime timestamp, Author author, Action action)
            : this()
        {
            this.Timestamp = timestamp;
            this.Author = author;
            this.Action = action;
        }

        internal AuditTrailEntry()
        {
        }

        /// <summary>
        /// Gets or sets the Timestamp of the modification.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets information about a person, a device or a piece of software authoring AnIML files.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Gets or sets information about the Software used to author this.
        /// </summary>
        public Software Software { get; set; }

        /// <summary>
        /// Gets or sets the type of change made (created, modified, ...)
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// Gets or sets an explanation why changes were made.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets a human-readable comment further explaining the changes.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets a list of machine-readable description of changes made.
        /// </summary>
        public List<Diff> Diffs { get; } = new List<Diff>();

        /// <summary>
        /// Gets or sets the IDs of the SignableItems that were affected. If none is specified, entire document is covered.
        /// </summary>
        public List<string> References { get; } = new List<string>();

        internal static AuditTrailEntry FromXElement(XElement auditTrailEntryElement)
        {
            AuditTrailEntry auditTrailEntry = new AuditTrailEntry();

            //// Import attributes for the implemented interfaces
            auditTrailEntry.ImportISignableItem(auditTrailEntryElement);

            //// Import the child elements of the current object
            auditTrailEntry.Timestamp = XmlConvert.ToDateTime(auditTrailEntryElement.Element(NamespaceHelper.GetXName("Timestamp")).Value, XmlDateTimeSerializationMode.Utc);
            auditTrailEntry.Author = Author.FromXElement(auditTrailEntryElement.Element(NamespaceHelper.GetXName("Author")));

            XElement softwareElement = auditTrailEntryElement.Elements(NamespaceHelper.GetXName("Software")).SingleOrDefault();
            if (softwareElement != null)
            {
                auditTrailEntry.Software = Software.FromXElement(softwareElement);
            }

            auditTrailEntry.Action = auditTrailEntryElement.Element(NamespaceHelper.GetXName("Action")).ImportAction();

            XElement reasonElement = auditTrailEntryElement.Element(NamespaceHelper.GetXName("Reason"));
            if (reasonElement != null)
            {
                auditTrailEntry.Reason = reasonElement.Value;
            }

            XElement commentElement = auditTrailEntryElement.Element(NamespaceHelper.GetXName("Comment"));
            if (commentElement != null)
            {
                auditTrailEntry.Comment = commentElement.Value;
            }

            auditTrailEntry.Diffs.AddRange(auditTrailEntryElement.Elements(NamespaceHelper.GetXName("Diff")).Select(Diff.FromXElement));
            auditTrailEntry.References.AddRange(auditTrailEntryElement.Elements(NamespaceHelper.GetXName("Reference")).Select(x => x.Value));

            return auditTrailEntry;
        }

        internal XElement ToXElement()
        {
            XElement auditTrailEntryElement = new XElement(NamespaceHelper.GetXName("AuditTrailEntry"));

            //// Export attributes of all implemented interfaces
            auditTrailEntryElement.ImportISignableItem(this);

            //// Export the child elements of the current object
            auditTrailEntryElement.Add(new XElement(NamespaceHelper.GetXName("Timestamp"), XmlConvert.ToString(this.Timestamp, XmlDateTimeSerializationMode.Utc)));
            auditTrailEntryElement.Add(this.Author.ToXElement());

            if (this.Software != null)
            {
                auditTrailEntryElement.Add(this.Software.ToXElement());
            }

            auditTrailEntryElement.Add(this.Action.GetXmlRepresentation());

            if (this.Reason != null)
            {
                auditTrailEntryElement.Add(new XElement(NamespaceHelper.GetXName("Reason"), this.Reason));
            }

            if (this.Comment != null)
            {
                auditTrailEntryElement.Add(new XElement(NamespaceHelper.GetXName("Comment"), this.Comment));
            }

            if (this.References?.Count > 0)
            {
                this.References.ForEach(r => auditTrailEntryElement.Add(new XElement(NamespaceHelper.GetXName("Reference"), r)));
            }

            return auditTrailEntryElement;
        }
    }
}
