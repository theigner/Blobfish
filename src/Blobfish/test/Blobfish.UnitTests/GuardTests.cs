namespace Blobfish.UnitTests
{
    using System;

    using FluentAssertions;

    using Xunit;

    public class GuardTests
    {
        [Fact]
        public void GuardAgainstEmptyShouldThrowArgumentExceptionOnEmpty()
        {
            Action actionWithEmptyArgument = () => Guard.AgainstEmpty("TestArgument", string.Empty);

            actionWithEmptyArgument.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GuardAgainstNegativeValueShouldThrowArgumentExceptionOnNegativeValue()
        {
            Action actionWithNegativeArgument = () => Guard.AgainstNegativeValue("TestArgument", -1);

            actionWithNegativeArgument.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GuardAgainstNonNumericSeriesTypeShouldThrowArgumentExceptionOnNonNumericSeriesType()
        {
            Action actionWithInvalidArgument = () => Guard.AgainstNonNumericSeriesType("TestArgument", SeriesType.String);

            actionWithInvalidArgument.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GuardAgainstNullThrowArgumentNullExceptionOnNull()
        {
            Action actionWithNullArgument = () => Guard.AgainstNull("TestArgument", null);

            actionWithNullArgument.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GuardAgainstNullOrEmptyShouldThrowArgumentExceptionOnNullOrEmpty()
        {
            Action actionWithNullArgument = () => Guard.AgainstNullOrEmpty("TestArgument", null);
            Action actionWithEmptyArgument = () => Guard.AgainstNullOrEmpty("TestArgument", string.Empty);

            actionWithNullArgument.Should().Throw<ArgumentException>();
            actionWithEmptyArgument.Should().Throw<ArgumentException>();
        }
    }
}
