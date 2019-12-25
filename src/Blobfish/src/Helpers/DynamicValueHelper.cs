namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    internal static class DynamicValueHelper
    {
        private static Dictionary<Type, DataType> allowedDataTypes = new Dictionary<Type, DataType>()
        {
            { typeof(int), DataType.Int32 },
            { typeof(long), DataType.Int64 },
            { typeof(float), DataType.Float32 },
            { typeof(double), DataType.Float64 },
            { typeof(string), DataType.String },
            { typeof(bool), DataType.Boolean },
            { typeof(DateTime), DataType.DateTime },
            { typeof(EmbeddedXml), DataType.EmbeddedXML },
            { typeof(PngImage), DataType.PNG },
            { typeof(SvgImage), DataType.SVG },
        };

        private static Dictionary<Type, DataType> allowedNumericDataTypes = new Dictionary<Type, DataType>()
        {
            { typeof(int), DataType.Int32 },
            { typeof(long), DataType.Int64 },
            { typeof(float), DataType.Float32 },
            { typeof(double), DataType.Float64 },
        };

        internal static void EnsureValidDataType(dynamic value)
        {
            if (!allowedDataTypes.ContainsKey(value.GetType()))
            {
                throw new TypeNotAllowedException();
            }
        }

        internal static void EnsureValidNumericDataType(dynamic value)
        {
            if (!allowedNumericDataTypes.ContainsKey(value.GetType()))
            {
                throw new TypeNotAllowedException();
            }
        }

        internal static ParameterType GetParameterType(dynamic value)
        {
            if (allowedDataTypes.TryGetValue(value.GetType(), out DataType dataType))
            {
                return (ParameterType)dataType;
            }

            throw new TypeNotAllowedException();
        }

        internal static XElement XElementFromValue(dynamic value)
        {
            Type valueType = value.GetType();

            if (valueType == typeof(int))
            {
                return new XElement(NamespaceHelper.GetXName("I")) { Value = XmlConvert.ToString((int)value) };
            }
            else if (valueType == typeof(long))
            {
                return new XElement(NamespaceHelper.GetXName("L")) { Value = XmlConvert.ToString((long)value) };
            }
            else if (valueType == typeof(float))
            {
                return new XElement(NamespaceHelper.GetXName("F")) { Value = XmlConvert.ToString((float)value) };
            }
            else if (valueType == typeof(double))
            {
                return new XElement(NamespaceHelper.GetXName("D")) { Value = XmlConvert.ToString((double)value) };
            }
            else if (valueType == typeof(string))
            {
                return new XElement(NamespaceHelper.GetXName("S")) { Value = (string)value };
            }
            else if (valueType == typeof(bool))
            {
                return new XElement(NamespaceHelper.GetXName("Boolean")) { Value = XmlConvert.ToString((bool)value) };
            }
            else if (valueType == typeof(DateTime))
            {
                return new XElement(NamespaceHelper.GetXName("DateTime")) { Value = XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Utc) };
            }
            else if (valueType == typeof(PngImage))
            {
                return new XElement(NamespaceHelper.GetXName("PNG")) { Value = Convert.ToBase64String(((PngImage)value).ImageBytes) };
            }
            else if (valueType == typeof(EmbeddedXml))
            {
                return new XElement(NamespaceHelper.GetXName("EmbeddedXML")) { Value = ((EmbeddedXml)value).XmlString };
            }
            else if (valueType == typeof(SvgImage))
            {
                return new XElement(NamespaceHelper.GetXName("SVG")) { Value = ((SvgImage)value).SvgString };
            }
            else
            {
                throw new NotImplementedException("Generating an XElement for the supplied value is not implemented.");
            }
        }

        internal static dynamic ImportNumericValue(this XElement numericValueElement)
        {
            XElement valueElement = numericValueElement.Elements().FirstOrDefault();

            if (valueElement != null)
            {
                if (valueElement.Name.LocalName == "I")
                {
                    return XmlConvert.ToInt32(valueElement.Value);
                }
                else if (valueElement.Name.LocalName == "L")
                {
                    return XmlConvert.ToInt64(valueElement.Value);
                }
                else if (valueElement.Name.LocalName == "F")
                {
                    return XmlConvert.ToSingle(valueElement.Value);
                }
                else if (valueElement.Name.LocalName == "D")
                {
                    return XmlConvert.ToDouble(valueElement.Value);
                }

                throw new ArgumentException($"An element with element name '{valueElement.Name}' is not a valid numeric value element.");
            }
            else
            {
                throw new InvalidOperationException("The node does not contain a valid numeric value node.");
            }
        }
    }
}
