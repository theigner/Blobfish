namespace Blobfish
{
    using System.Xml.Linq;

    internal static class XElementExtensions
    {
        internal static void AddAttribute(this XElement element, string name, string value)
        {
            element.Add(new XAttribute(name, value));
        }

        internal static void AddAttributeIfNotNull(this XElement element, string name, bool? optionalBoolValue)
        {
            if (optionalBoolValue.HasValue)
            {
                element.Add(new XAttribute(name, optionalBoolValue.Value));
            }
        }

        internal static void AddAttributeIfNotNull(this XElement element, string name, ContainerType? containerType)
        {
            if (containerType.HasValue)
            {
                element.Add(new XAttribute(name, containerType.Value.GetXmlRepresentation()));
            }
        }

        internal static void AddAttributeIfValueNotNullOrEmpty(this XElement element, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                element.Add(new XAttribute(name, value));
            }
        }
    }
}
