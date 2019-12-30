namespace Blobfish
{
    using System.Xml.Linq;

    internal static class ISampleAttributesExtensions
    {
        internal static void ImportISampleAttributes(this XElement sampleAttributesElement, ISampleAttibutes sampleAttributes)
        {
            sampleAttributesElement.AddAttribute("role", sampleAttributes.Role);
            sampleAttributesElement.AddAttribute("samplePurpose", sampleAttributes.SamplePurpose.GetXmlRepresentation());
        }

        internal static void ImportISampleAttributes(this ISampleAttibutes sampleAttributes, XElement sampleAttributesElement)
        {
            sampleAttributes.Role = sampleAttributesElement.Attribute("role").Value;
            sampleAttributes.SamplePurpose = sampleAttributesElement.Attribute("samplePurpose").ImportSamplePurpose();
        }
    }
}
