namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class EncodedValueSetTests
    {
        [Fact]
        public void EncodedValueSetConstructorThrowsOnInvalidSeriesType()
        {
            Action constructorCallWithInvalidSeriesType = () => new EncodedValueSet(SeriesType.String);

            constructorCallWithInvalidSeriesType.Should().Throw<ArgumentException>();
        }
    }
}
