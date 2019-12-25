namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class TagTests
    {
        [Fact]
        public void TagConstructorThrowsOnInvalidName()
        {
            Action constructorCall = () => new Tag(null);

            constructorCall.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TagConstructorWorksWithValidParameters()
        {
            Tag tag = new Tag("TagName", "TagValue");

            tag.Name.Should().Be("TagName");
            tag.Value.Should().Be("TagValue");
        }
    }
}
