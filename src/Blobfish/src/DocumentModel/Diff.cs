namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Machine-readable description of changes made.
    /// </summary>
    public class Diff
    {
        /// <summary>
        /// Creates a new instance of the Diff class.
        /// </summary>
        /// <param name="scope">The scope of the Diff.</param>
        /// <param name="changedItem">The id of the SignableItem that was changed.</param>
        public Diff(Scope scope, string changedItem)
        {
            Guard.AgainstNullOrEmpty(nameof(changedItem), changedItem);

            this.Scope = scope;
            this.ChangedItem = changedItem;
        }

        /// <summary>
        /// Creates a new instance of the Diff class.
        /// </summary>
        /// <param name="scope">The scope of the Diff.</param>
        /// <param name="changedItem">The id of the SignableItem that was changed.</param>
        /// <param name="oldValue">The value before the change.</param>
        /// <param name="newValue">The value adter the change.</param>
        public Diff(Scope scope, string changedItem, string oldValue, string newValue)
            : this(scope, changedItem)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        internal Diff()
        {
        }

        /// <summary>
        /// Gets or sets the value before the change.
        /// </summary>
        public string OldValue { get; set; }

        /// <summary>
        /// Gets or sets the value after the change.
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// Gets or sets the scope of the Diff. May be "element" or "attribute".
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// Gets or sets the ID of the SignableItem that was changed.
        /// </summary>
        public string ChangedItem { get; set; }

        internal static Diff FromXElement(XElement diffElement)
        {
            Diff diff = new Diff();

            //// Import all attributes
            diff.Scope = diffElement.Attribute("scope").ImportScope();
            diff.ChangedItem = diffElement.Attribute("changedItem").Value;

            //// Import the child elements of the current object
            diff.OldValue = diffElement.Element(NamespaceHelper.GetXName("OldValue")).Value;
            diff.NewValue = diffElement.Element(NamespaceHelper.GetXName("NewValue")).Value;

            return diff;
        }

        internal XElement ToXElement()
        {
            XElement diffElement = new XElement(NamespaceHelper.GetXName("Diff"));

            //// Export all attributes
            diffElement.AddAttribute("scope", this.Scope.GetXmlRepresentation());
            diffElement.AddAttribute("changedItem", this.ChangedItem);

            //// Export the child elements of the current object
            diffElement.Add(new XElement(NamespaceHelper.GetXName("OldValue"), this.OldValue));
            diffElement.Add(new XElement(NamespaceHelper.GetXName("NewValue"), this.NewValue));

            return diffElement;
        }
    }
}
