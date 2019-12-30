namespace Blobfish
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Represents a single AnIML document.
    /// </summary>
    public class AnimlDocument
    {
        /// <summary>
        /// Creates a new instance of an AnIML document with Version 0.90.
        /// </summary>
        public AnimlDocument()
        {
            this.Version = "0.90";
        }

        /// <summary>
        /// Container for multiple ExperimentSteps that describe the process and results.
        /// </summary>
        public ExperimentStepSet ExperimentStepSet { get; set; }

        /// <summary>
        /// Container for Samples used in this AnIML document.
        /// </summary>
        public SampleSet SampleSet { get; set; }

        /// <summary>
        /// Version number of the AnIML Core Schema used in this document. Must be "0.90".
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Creates a new AnimlDocument from a XML string.
        /// </summary>
        /// <param name="xmlString">A string containing XML that represents the content of an AnIML file.</param>
        /// <returns>A new AnimlDocument containing the information loaded from the XML string.</returns>
        public static AnimlDocument ReadFromString(string xmlString)
        {
            return ReadFromXDocument(XDocument.Parse(xmlString));
        }

        /// <summary>
        /// Creates a new AnimlDocument from a file.
        /// </summary>
        /// <param name="uri">A URI string that references the file to load.</param>
        /// <returns>A new AnimlDocument containing the information loaded from the specified URI.</returns>
        public static AnimlDocument ReadFromFile(string uri)
        {
            return ReadFromXDocument(XDocument.Load(uri));
        }

        /// <summary>
        /// Creates a new AnimlDocument from a XDocument.
        /// </summary>
        /// <param name="xDoc">A XDocument representing an AnIML file.</param>
        /// <returns>A new AnimlDocument containing the information loaded from the XDocument.</returns>
        public static AnimlDocument ReadFromXDocument(XDocument xDoc)
        {
            if (xDoc is null)
            {
                throw new ArgumentNullException(nameof(xDoc));
            }

            AnimlDocument animlDocument = new AnimlDocument();
            XElement animlElement = xDoc.Root;

            animlDocument.SampleSet = SampleSet.FromXElement(animlElement.Element(NamespaceHelper.GetXName("SampleSet")));
            animlDocument.ExperimentStepSet = ExperimentStepSet.FromXElement(animlElement.Element(NamespaceHelper.GetXName("ExperimentStepSet")));

            return animlDocument;
        }

        /// <summary>
        /// Saves the AnimlDocument as file.
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="indentXml">True if the XML file should be created indented, otherwise false.</param>
        public void SaveAsFile(string path, bool indentXml = true)
        {
            File.WriteAllText(path, this.ToXml(indentXml), new UTF8Encoding(false));
        }

        /// <summary>
        /// Returns the current AnimlDocument as its AnIML-XDocument representation.
        /// </summary>
        /// <returns>A XDocument representing the current AnimlDocument.</returns>
        public XDocument ToXDocument()
        {
            //// Create a new XDocument that follows the definition of the AnIML core schema in terms of declaration, namespace and root element.
            XDeclaration xDecl = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xDoc = new XDocument(xDecl);
            XElement animlElement = new XElement(NamespaceHelper.GetXName("AnIML"));
            animlElement.Add(new XAttribute("version", this.Version));
            xDoc.Add(animlElement);

            //// Add all data elements
            if (this.SampleSet != null)
            {
                animlElement.Add(this.SampleSet.ToXElement());
            }

            if (this.ExperimentStepSet != null)
            {
                animlElement.Add(this.ExperimentStepSet.ToXElement());
            }

            return xDoc;
        }

        /// <summary>
        /// Returns the current AnimlDocument as its AnIML-XML represenation.
        /// </summary>
        /// <param name="indent"></param>
        /// <returns>A string representing the current AnimlDocument.</returns>
        public string ToXml(bool indent = true)
        {
            StringBuilder xmlStringBuilder = new StringBuilder();

            using (TextWriter textWriter = new Utf8StringWriter(xmlStringBuilder))
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings() { Indent = indent }))
            {
                this.ToXDocument().WriteTo(xmlWriter);
            }

            return xmlStringBuilder.ToString();
        }
    }
}
