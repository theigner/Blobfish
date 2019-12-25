namespace Blobfish.UnitTests
{
    using System;
    using System.IO;

    using FluentAssertions;

    using Xunit;

    public class ParameterTests
    {
        [Fact]
        public void ParameterConstructorThrowsOnInvalidValueType()
        {
            Action constructorCallWithInvalidValueType = () => new Parameter("ParameterName", 'X');

            constructorCallWithInvalidValueType.Should().Throw<TypeNotAllowedException>();
        }

        [Fact]
        public void ParameterValueSetterAcceptsValidValues()
        {
            Type valueType;
            Parameter parameter = new Parameter("ParameterName", int.MaxValue);

            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(int));
            ((int)parameter.Value).Should().Be(int.MaxValue);
            parameter.ParameterType.Should().Be(ParameterType.Int32);

            parameter.Value = long.MaxValue;
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(long));
            ((long)parameter.Value).Should().Be(long.MaxValue);
            parameter.ParameterType.Should().Be(ParameterType.Int64);

            parameter.Value = float.MaxValue;
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(float));
            ((float)parameter.Value).Should().Be(float.MaxValue);
            parameter.ParameterType.Should().Be(ParameterType.Float32);

            parameter.Value = double.MaxValue;
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(double));
            ((double)parameter.Value).Should().Be(double.MaxValue);
            parameter.ParameterType.Should().Be(ParameterType.Float64);

            parameter.Value = "TestStringValue";
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(string));
            ((string)parameter.Value).Should().Be("TestStringValue");
            parameter.ParameterType.Should().Be(ParameterType.String);

            parameter.Value = true;
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(bool));
            ((bool)parameter.Value).Should().Be(true);
            parameter.ParameterType.Should().Be(ParameterType.Boolean);

            parameter.Value = new DateTime(2000, 03, 01, 11, 11, 11, DateTimeKind.Utc);
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(DateTime));
            ((DateTime)parameter.Value).Should().Be(new DateTime(2000, 03, 01, 11, 11, 11, DateTimeKind.Utc));
            parameter.ParameterType.Should().Be(ParameterType.DateTime);

            parameter.Value = new EmbeddedXml("<xml>Test</xml>");
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(EmbeddedXml));
            ((EmbeddedXml)parameter.Value).XmlString.Should().Be("<xml>Test</xml>");
            parameter.ParameterType.Should().Be(ParameterType.EmbeddedXML);

            byte[] pngBytes = File.ReadAllBytes(@"files\circle.png");
            parameter.Value = new PngImage(pngBytes);
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(PngImage));
            ((PngImage)parameter.Value).ImageBytes.Should().BeEquivalentTo(pngBytes);
            parameter.ParameterType.Should().Be(ParameterType.PNG);

            string svgString = File.ReadAllText(@"files\circle.svg");
            parameter.Value = new SvgImage(svgString);
            valueType = parameter.Value.GetType();
            valueType.Should().Be(typeof(SvgImage));
            ((SvgImage)parameter.Value).SvgString.Should().Be(svgString);
            parameter.ParameterType.Should().Be(ParameterType.SVG);
        }
    }
}
