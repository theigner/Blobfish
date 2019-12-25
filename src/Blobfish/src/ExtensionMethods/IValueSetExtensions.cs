namespace Blobfish
{
    using System.Xml;
    using System.Xml.Linq;

    internal static class IValueSetExtensions
    {
        internal static void ImportIValueSet(this XElement valueSetElement, IValueSet valueSet)
        {
            if (valueSet.StartIndex.HasValue)
            {
                valueSetElement.AddAttribute("startIndex", XmlConvert.ToString(valueSet.StartIndex.Value));
            }

            if (valueSet.EndIndex.HasValue)
            {
                valueSetElement.AddAttribute("endIndex", XmlConvert.ToString(valueSet.EndIndex.Value));
            }
        }

        internal static void ImportIValueSet(this IValueSet valueSet, XElement valueSetElement)
        {
            XAttribute startIndexAttribute = valueSetElement.Attribute("startIndex");
            if (startIndexAttribute != null)
            {
                valueSet.StartIndex = XmlConvert.ToInt32(startIndexAttribute.Value);
            }

            XAttribute endIndexAttribute = valueSetElement.Attribute("endIndex");
            if (endIndexAttribute != null)
            {
                valueSet.EndIndex = XmlConvert.ToInt32(endIndexAttribute.Value);
            }
        }
    }
}
