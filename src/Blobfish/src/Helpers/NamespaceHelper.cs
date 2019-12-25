using System.Xml.Linq;

namespace Blobfish
{
    internal static class NamespaceHelper
    {
        internal static XNamespace AnimlNamespace = "urn:org:astm:animl:schema:core:draft:0.90";

        internal static XName GetXName(string elementName)
        {
            return AnimlNamespace + elementName;
        }
    }
}
