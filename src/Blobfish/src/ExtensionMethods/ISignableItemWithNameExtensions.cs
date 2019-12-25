namespace Blobfish
{
    using System.Xml.Linq;

    internal static class ISignableItemWithNameExtensions
    {
        internal static void ImportISignableItemWithName(this XElement signableItemWithNameElement, ISignableItemWithNameBase source)
        {
            signableItemWithNameElement.ImportISignableItem(source);
            signableItemWithNameElement.Add(new XAttribute("name", source.Name));
        }

        internal static void ImportISignableItemWithName(this XElement signableItemWithNameAndSourceDataLocationElement, ISignableItemWithNameAndISourceDataLocationBase source)
        {
            signableItemWithNameAndSourceDataLocationElement.ImportISignableItem(source);
            signableItemWithNameAndSourceDataLocationElement.Add(new XAttribute("name", source.Name));
        }

        internal static void ImportISignableItemWithName(this ISignableItemWithNameBase signableItemWithName, XElement source)
        {
            signableItemWithName.ImportISignableItem(source);
            signableItemWithName.Name = source.Attribute("name").Value;
        }

        internal static void ImportISignableItemWithName(this ISignableItemWithNameAndISourceDataLocationBase signableItemWithNameAndSourceDataLocationBase, XElement source)
        {
            signableItemWithNameAndSourceDataLocationBase.ImportISignableItem(source);
            signableItemWithNameAndSourceDataLocationBase.Name = source.Attribute("name").Value;
        }
    }
}
