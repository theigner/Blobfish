namespace Blobfish
{
    using System.Xml.Linq;

    internal static class IExperimentDataAttributesExtensions
    {
        internal static void ImportIExperimentDataAttributes(this XElement sampleAttributesElement, IExperimentDataAttributes experimentDataAttributes)
        {
            sampleAttributesElement.AddAttribute("role", experimentDataAttributes.Role);
            sampleAttributesElement.AddAttribute("dataPurpose", experimentDataAttributes.DataPurpose.GetXmlRepresentation());
        }

        internal static void ImportIExperimentDataAttributes(this IExperimentDataAttributes experimentDataAttributes, XElement experimentDataAttributesElement)
        {
            experimentDataAttributes.Role = experimentDataAttributesElement.Attribute("role").Value;
            experimentDataAttributes.DataPurpose = experimentDataAttributesElement.Attribute("dataPurpose").ImportExperimentDataPurpose();
        }
    }
}
