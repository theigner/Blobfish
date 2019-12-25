namespace Blobfish
{
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Name/Value Pair.
    /// </summary>
    public class Parameter : ISignableItemWithNameBase
    {
        private dynamic value;

        /// <summary>
        /// Creates a new instance of the Parameter class.
        /// </summary>
        /// <param name="name">The name of the Parameter.</param>
        /// <param name="value">The value of the Parameter.</param>
        /// <param name="unit">The unit of the Parameter.</param>
        /// <exception cref="Blobfish.TypeNotAllowedException">Thrown when the type of the value is not allowed.</exception>

        public Parameter(string name, dynamic value, Unit unit = null)
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);
            this.SetValueAndThrowOnFailure(value);

            this.Name = name;
            this.Unit = unit;
        }

        internal Parameter()
        {
        }

        /// <summary>
        /// Data type of this parameter.
        /// </summary>
        public ParameterType ParameterType { get; private set; }

        /// <summary>
        /// Gets or sets the unit of the Parameter.
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets or sets the value of the Paramter.
        /// </summary>
        /// <exception cref="Blobfish.TypeNotAllowedException">Thrown when the type of the value is not allowed.</exception>
        public dynamic Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.SetValueAndThrowOnFailure(value);
            }
        }

        internal static Parameter FromXElement(XElement parameterElement)
        {
            Parameter parameter = new Parameter();

            //// Import attributes for the implemented interfaces
            parameter.ImportISignableItemWithName(parameterElement);

            //// Import all other attributes
            parameter.ParameterType = parameterElement.Attribute("parameterType").ImportParameterType();

            //// Import the child elements of the current object
            switch (parameter.ParameterType)
            {
                case ParameterType.Int32:
                    {
                        parameter.Value = XmlConvert.ToInt32(parameterElement.Elements(NamespaceHelper.GetXName("I")).Single().Value);
                        break;
                    }

                case ParameterType.Int64:
                    {
                        parameter.Value = XmlConvert.ToInt64(parameterElement.Elements(NamespaceHelper.GetXName("L")).Single().Value);
                        break;
                    }

                case ParameterType.Float32:
                    {
                        parameter.Value = XmlConvert.ToSingle(parameterElement.Elements(NamespaceHelper.GetXName("F")).Single().Value);
                        break;
                    }

                case ParameterType.Float64:
                    {
                        parameter.Value = XmlConvert.ToDouble(parameterElement.Elements(NamespaceHelper.GetXName("D")).Single().Value);
                        break;
                    }

                case ParameterType.String:
                    {
                        parameter.Value = parameterElement.Elements(NamespaceHelper.GetXName("S")).Single().Value;
                        break;
                    }

                case ParameterType.Boolean:
                    {
                        parameter.Value = XmlConvert.ToBoolean(parameterElement.Elements(NamespaceHelper.GetXName("Boolean")).Single().Value);
                        break;
                    }

                case ParameterType.DateTime:
                    {
                        parameter.Value = XmlConvert.ToDateTime(parameterElement.Elements(NamespaceHelper.GetXName("DateTime")).Single().Value, XmlDateTimeSerializationMode.Utc);
                        break;
                    }

                case ParameterType.EmbeddedXML:
                    {
                        parameter.Value = new EmbeddedXml(parameterElement.Elements(NamespaceHelper.GetXName("EmbeddedXML")).Single().Value);
                        break;
                    }

                case ParameterType.PNG:
                    {
                        parameter.Value = new PngImage(parameterElement.Elements(NamespaceHelper.GetXName("PNG")).Single().Value);
                        break;
                    }

                case ParameterType.SVG:
                    {
                        parameter.Value = new SvgImage(parameterElement.Elements(NamespaceHelper.GetXName("SVG")).Single().Value);
                        break;
                    }
            }

            XElement unitElement = parameterElement.Element(NamespaceHelper.GetXName("Unit"));
            if (unitElement != null)
            {
                parameter.Unit = Unit.FromXElement(unitElement);
            }

            return parameter;
        }

        internal XElement ToXElement()
        {
            XElement parameterElement = new XElement(NamespaceHelper.GetXName("Parameter"));

            //// Export attributes of all implemented interfaces
            parameterElement.ImportISignableItemWithName(this);

            //// Export all other attributes
            parameterElement.AddAttribute("parameterType", this.ParameterType.GetXmlRepresentation());

            //// Export the child elements of the current object
            parameterElement.Add(DynamicValueHelper.XElementFromValue(this.Value));

            if (this.Unit != null)
            {
                parameterElement.Add(this.Unit.ToXElement());
            }

            return parameterElement;
        }

        private void SetValueAndThrowOnFailure(dynamic value)
        {
            DynamicValueHelper.EnsureValidDataType(value);

            this.value = value;
            this.ParameterType = DynamicValueHelper.GetParameterType(this.value);
        }
    }
}
