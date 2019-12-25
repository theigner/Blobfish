namespace Blobfish.UnitTests
{
    using FluentAssertions;

    using System.Xml.Linq;

    using Xunit;

    public class AnimlDocumentTests
    {
        [Fact]
        public void AnimlDocumentShouldHaveCorrectDeclarationAndNamespace()
        {
            XNamespace xNamespace = "urn:org:astm:animl:schema:core:draft:0.90";

            AnimlDocument animlDocument = new AnimlDocument();

            XDocument xDocument = animlDocument.ToXDocument();

            xDocument.Declaration.Should().NotBeNull("XML declaration must not be null.");
            xDocument.Declaration.Version.Should().NotBeNullOrEmpty().And.BeEquivalentTo("1.0", "XML document should be declated with version 1.0.");
            xDocument.Declaration.Standalone.Should().NotBeNullOrEmpty().And.BeEquivalentTo("yes", "XML document should be declared as standalone.");
            xDocument.Declaration.Encoding.Should().NotBeNullOrEmpty().And.BeEquivalentTo("utf-8", "XML document should be declared with encoding UTF-8.");

            XName animlElementName = xNamespace + "AnIML";
            xDocument.Should().HaveRoot(animlElementName, "AnIML document must have a root element named AnIML.");
            xDocument.Element(animlElementName).Should().HaveAttribute("version", "0.90", "AnIML schema version must be 0.90.");
            xDocument.Element(animlElementName).Name.NamespaceName.Should().Be(xNamespace.NamespaceName, $"Schema namespace of root AnIML must be {xNamespace}.");
        }
    }
}
