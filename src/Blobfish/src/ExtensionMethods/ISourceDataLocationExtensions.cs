namespace Blobfish
{
    using System.Xml.Linq;

    internal static class ISourceDataLocationExtensions
    {
        internal static void ImportISourceDataLocation(this XElement sourceDataLocationElement, ISourceDataLocation sourceDataLocation)
        {
            sourceDataLocationElement.AddAttributeIfValueNotNullOrEmpty("sourceDataLocation", sourceDataLocation.SourceDataLocation);
        }

        internal static void ImportISourceDataLocation(this ISourceDataLocation sourceDataLocation, XElement source)
        {
            sourceDataLocation.SourceDataLocation = source.Attribute("sourceDataLocation")?.Value;
        }
    }
}
