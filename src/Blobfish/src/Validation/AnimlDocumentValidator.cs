namespace Blobfish
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// Validates AnIML documents against the AnIML core schema.
    /// </summary>
    public class AnimlDocumentValidator
    {
        private readonly string animlDocumentXml;

        private AnimlDocumentValidator(string animlDocumentXml)
        {
            this.animlDocumentXml = animlDocumentXml;
        }

        /// <summary>
        /// Gets the validation messages that were generated when validating the AnIML document against the core schema. This list is empty if validation was successful.
        /// </summary>
        public List<string> ValidationMessages { get; } = new List<string>();

        /// <summary>
        /// Creates a new AnimlDocumentValidator from an AnimlDocument
        /// </summary>
        /// <param name="animlDocument">The AnimlDocument to validate against the AnIML core schema.</param>
        /// <returns>A new instance of the AnimlDocumentValidator class for validating AnIML data.</returns>
        public static AnimlDocumentValidator CreateValidatorForAnimlDocument(AnimlDocument animlDocument)
        {
            return new AnimlDocumentValidator(animlDocument.ToXml());
        }

        /// <summary>
        /// Creates a new AnimlDocumentValidator from an existing AnIML file (usually with a file extension .animl).
        /// </summary>
        /// <param name="animlDocumentPath">The path of the AniML file that should be validated against the AnIML core schema.</param>
        /// <returns>A new instance of the AnimlDocumentValidator class for validating AnIML data.</returns>
        public static AnimlDocumentValidator CreateValidatorForAnimlDocumentFile(string animlDocumentPath)
        {
            return new AnimlDocumentValidator(File.ReadAllText(animlDocumentPath, Encoding.UTF8));
        }

        /// <summary>
        /// Creates a new AnimlDocumentValidator from a string variable that contains an AnimlDocument or AnIML file.
        /// </summary>
        /// <param name="animlDocumentString">The XML content of an AnIML file. This XML content is validated against the AnIML core schema.</param>
        /// <returns>A new instance of the AnimlDocumentValidator class for validating AnIML data.</returns>
        public static AnimlDocumentValidator CreateValidatorForAnimlDocumentString(string animlDocumentString)
        {
            return new AnimlDocumentValidator(animlDocumentString);
        }

        /// <summary>
        /// Performs the validation of the AnIML content against the AnIML core schema.
        /// </summary>
        /// <returns>True if the document is valid, otherwise false.</returns>
        /// <remarks>If the return value is false the <see cref="Blobfish.AnimlDocumentValidator.ValidationMessages"/> property contains all validation warnings and errors.</remarks>
        public bool Validate()
        {
            this.ValidationMessages.Clear();

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add(LoadXmlSchema("Blobfish.Schemas.animl-core-0_90.xsd"));
            xmlReaderSettings.Schemas.Add(LoadXmlSchema("Blobfish.Schemas.xmldsig-core-schema.xsd"));
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            xmlReaderSettings.ValidationEventHandler += this.AnimlDocumentValidationEventHandler;

            using (TextReader xmlTextReader = new StringReader(this.animlDocumentXml))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlTextReader, xmlReaderSettings))
                {
                    while (xmlReader.Read())
                    {
                    }
                }
            }

            return this.ValidationMessages.Count == 0;
        }

        private void AnimlDocumentValidationEventHandler(object sender, ValidationEventArgs e)
        {
            this.ValidationMessages.Add($"{e.Severity}: {e.Message}");
        }

        private static XmlSchema LoadXmlSchema(string xmlSchemaName)
        {
            using (StreamReader schemaReader = new StreamReader(typeof(AnimlDocument).GetTypeInfo().Assembly.GetManifestResourceStream(xmlSchemaName), Encoding.UTF8))
            using (XmlReader xmlReader = XmlReader.Create(schemaReader, new XmlReaderSettings() { DtdProcessing = DtdProcessing.Parse }))
            {
                XmlSchema xmlSchema = XmlSchema.Read(xmlReader, LoadXmlSchemaValidationEventHandler);
                return xmlSchema;
            }
        }

        private static void LoadXmlSchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            //// Throw an exception when a warning or an error occurs while loading the XML schema.
            //// In case the schema is not loaded correctly the validation against the schema might be incorrect.
            throw new InvalidOperationException("Error while loading XML schema. Validation can not be performed.");
        }
    }
}
