namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class SampleTests
    {
        [Fact]
        public void SampleConstructorThrowsOnInvalidNameOrSampleId()
        {
            Action constructorCallWithInvalidName = () => new Sample(null, "SampleId");
            Action constructorCallWithInvalidSampleId = () => new Sample("Name", null);
            Action constructorCallWithTwoInvalidArguments = () => new Sample(null, null);

            constructorCallWithInvalidName.Should().Throw<ArgumentException>();
            constructorCallWithInvalidSampleId.Should().Throw<ArgumentException>();
            constructorCallWithTwoInvalidArguments.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void SampleConstructorWorksCorrectlyWithValidParameters()
        {
            Sample sample = new Sample("SampleName", "SampleId");
            sample.Name.Should().Be("SampleName");
            sample.SampleId.Should().Be("SampleId");
            sample.Categories.Should().NotBeNull();
        }
    }
}
