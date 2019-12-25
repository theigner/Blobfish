namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Definition of a Scientific Unit.
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Creates a new instance of class Unit.
        /// </summary>
        /// <param name="label">The visual representation of a Unit.</param>
        public Unit(string label)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(label), label);

            this.Label = label;
        }

        /// <summary>
        /// Creates a new instance of class Unit.
        /// </summary>
        /// <param name="label">The visual representation of a Unit.</param>
        /// <param name="quantity">The quantity the Unit is applicable to.</param>
        public Unit(string label, string quantity)
            : this(label)
        {
            Guard.AgainstEmpty(nameof(quantity), quantity);

            this.Quantity = quantity;
        }

        /// <summary>
        /// Creates a new instance of class Unit.
        /// </summary>
        /// <param name="label">The visual representation of a Unit.</param>
        /// <param name="quantity">The quantity the Unit is applicable to.</param>
        /// <param name="siUnits">A collection of SIUnits the Unit is based on.</param>
        public Unit(string label, string quantity, IEnumerable<SIUnit> siUnits)
            : this(label, quantity)
        {
            if (siUnits != null)
            {
                this.SIUnits.AddRange(siUnits);
            }
        }

        /// <summary>
        /// Creates a new instance of class Unit.
        /// </summary>
        /// <param name="label">The visual representation of a Unit.</param>
        /// <param name="siUnits">A collection of SIUnits the Unit is based on.</param>
        public Unit(string label, IEnumerable<SIUnit> siUnits)
            : this(label)
        {
            if (siUnits != null)
            {
                this.SIUnits.AddRange(siUnits);
            }
        }

        internal Unit()
        {
        }

        /// <summary>
        /// Defines the visual representation of a particular Unit.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Quantity the unit can be applied to.
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Combination of SI Units used to represent Scientific Unit.
        /// </summary>
        public List<SIUnit> SIUnits { get; } = new List<SIUnit>();

        internal static Unit FromXElement(XElement unitElement)
        {
            Unit unit = new Unit();

            //// Import all attributes
            unit.Label = unitElement.Attribute("label").Value;

            XAttribute quantityAttribute = unitElement.Attribute("quantity");
            if (quantityAttribute != null)
            {
                unit.Quantity = quantityAttribute.Value;
            }

            //// Import the child elements of the current object
            unit.SIUnits.AddRange(unitElement.Elements(NamespaceHelper.GetXName("SIUnit")).Select(SIUnit.FromXElement));

            return unit;
        }

        internal XElement ToXElement()
        {
            XElement unitElement = new XElement(NamespaceHelper.GetXName("Unit"));

            //// Export all attributes
            unitElement.AddAttribute("label", this.Label);

            if (this.Quantity != null)
            {
                unitElement.AddAttribute("quantity", this.Quantity);
            }

            //// Export all child elements
            this.SIUnits.ForEach(s => unitElement.Add(s.ToXElement()));

            return unitElement;
        }
    }
}
