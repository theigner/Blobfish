using System.IO;

namespace Blobfish
{
    /// <summary>
    /// Represents XML that is embedded in an AnIML document.
    /// </summary>
    public class EmbeddedXml
    {
        /// <summary>
        /// Creates a new instance of the EmbeddedXml class.
        /// </summary>
        public EmbeddedXml()
        {
        }

        /// <summary>
        /// Creates a new instance of the EmbeddedXml class.
        /// </summary>
        /// <param name="xmlString">The XML string with that the new instance is initialized.</param>
        public EmbeddedXml(string xmlString)
        {
            this.XmlString = xmlString;
        }

        /// <summary>
        /// Gets or sets the XML string embedded in the AnIML document.
        /// </summary>
        public string XmlString { get; set; }

        /// <summary>
        /// Creates a new instance of an EmbeddedXml from a file.
        /// </summary>
        /// <param name="path">The path of the XML file to read.</param>
        /// <returns>Returns a new EmbeddedXml.</returns>
        public static EmbeddedXml FromFile(string path)
        {
            return new EmbeddedXml(File.ReadAllText(path));
        }
    }
}
