namespace Blobfish
{
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a SIUnit with factor, exponent and offset used to define a Unit.
    /// </summary>
    public class SIUnit
    {
        /// <summary>
        /// Creates a new instance of the SIUnit class.
        /// </summary>
        /// <param name="baseUnit">The SI base unit.</param>
        public SIUnit(SIBaseUnit baseUnit)
        {
            this.BaseUnit = baseUnit;
        }

        /// <summary>
        /// Creates a new instance of the SIUnit class. SIUnit = factor * (SIBaseUnit ^ exponent) + offset
        /// </summary>
        /// <param name="baseUnit">The SI base unit.</param>
        /// <param name="factor">The factor with that the SIBaseUnit is multiplied.</param>
        /// <param name="exponent">The exponent to that the SIBaseUnit is exponentiated.</param>
        /// <param name="offset">The offset that is added to the SIBaseUnit.</param>
        public SIUnit(SIBaseUnit baseUnit, double? factor = null, double? exponent = null, double? offset = null)
            : this(baseUnit)
        {
            this.Factor = factor;
            this.Exponent = exponent;
            this.Offset = offset;
        }

        internal SIUnit()
        {
        }

        /// <summary>
        /// Gets or sets the SIBaseUnit.
        /// </summary>
        public SIBaseUnit BaseUnit { get; set; }

        /// <summary>
        /// Gets or sets the factor with the the SIBaseUnit is multiplied.
        /// </summary>
        /// <remarks>In case the factor is null a value of 1 is assumed.</remarks>
        public double? Factor { get; set; }

        /// <summary>
        /// Gets or sets the exponent to that the SIBaseUnit is exponentiated.
        /// </summary>
        /// <remarks>In case the exponent is null a value of 1 is assumed.</remarks>
        public double? Exponent { get; set; }

        /// <summary>
        /// Gets or sets the offset that is added to the SIBaseUnit.
        /// </summary>
        /// <remarks>In case the offset is null a value of 0 is assumed.</remarks>
        public double? Offset { get; set; }

        internal static SIUnit FromXElement(XElement siUnitElement)
        {
            SIUnit siUnit = new SIUnit();

            //// Import all attributes
            XAttribute factorAttribute = siUnitElement.Attribute("factor");
            if (factorAttribute != null)
            {
                siUnit.Factor = XmlConvert.ToDouble(factorAttribute.Value);
            }

            XAttribute exponentAttribute = siUnitElement.Attribute("exponent");
            if (exponentAttribute != null)
            {
                siUnit.Exponent = XmlConvert.ToDouble(exponentAttribute.Value);
            }

            XAttribute offsetAttribute = siUnitElement.Attribute("offset");
            if (offsetAttribute != null)
            {
                siUnit.Offset = XmlConvert.ToDouble(offsetAttribute.Value);
            }

            //// Import the base unit from the content of the source element
            siUnit.BaseUnit = siUnitElement.ImportSIBaseUnit();

            return siUnit;

        }

        internal XElement ToXElement()
        {
            XElement siUnitElement = new XElement(NamespaceHelper.GetXName("SIUnit"));

            //// Export all attributes
            if (this.Factor.HasValue)
            {
                siUnitElement.AddAttribute("factor", XmlConvert.ToString(this.Factor.Value));
            }

            if (this.Exponent.HasValue)
            {
                siUnitElement.AddAttribute("exponent", XmlConvert.ToString(this.Exponent.Value));
            }

            if (this.Offset.HasValue)
            {
                siUnitElement.AddAttribute("offset", XmlConvert.ToString(this.Offset.Value));
            }

            //// Export the base unit as content of the SIUnit element
            siUnitElement.Value = this.BaseUnit.GetXmlRepresentation();

            return siUnitElement;
        }
    }
}
