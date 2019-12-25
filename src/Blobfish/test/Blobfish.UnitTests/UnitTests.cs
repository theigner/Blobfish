namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class UnitTests
    {
        [Fact]
        public void UnitConstructorThrowsOnInvalidLabel()
        {
            Action constructorCallWithLabelNull = () => new Unit(null);
            Action constructorCallWithLabelEmpty = () => new Unit(string.Empty);

            constructorCallWithLabelNull.Should().Throw<ArgumentException>();
            constructorCallWithLabelEmpty.Should().Throw<ArgumentException>();
        }
    }
}
