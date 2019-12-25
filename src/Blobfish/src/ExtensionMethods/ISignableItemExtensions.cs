namespace Blobfish
{
    using System.Xml.Linq;

    internal static class ISignableItemExtensions
    {
        internal static void ImportISignableItem(this XElement signableItemElement, ISignableItem signableItem)
        {
            signableItemElement.AddAttributeIfValueNotNullOrEmpty("id", signableItem.Id);
        }

        internal static void ImportISignableItem(this ISignableItem signableItem, XElement source)
        {
            XAttribute attribute = source.Attribute("id");
            if (attribute != null)
            {
                signableItem.Id = attribute.Value;
            }
        }
    }
}
