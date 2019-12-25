namespace Blobfish.UnitTests
{
    using FluentAssertions;

    using Xunit;

    public class SIUnitTests
    {
        [Fact]
        public void SIUnitConstructorWorksCorrectly()
        {
            SIUnit siUnit = new SIUnit(SIBaseUnit.Kilogram, 1e-03, 1, 0);

            siUnit.BaseUnit.Should().Be(SIBaseUnit.Kilogram);
            siUnit.Factor.Should().NotBeNull().And.Be(0.001);
            siUnit.Exponent.Should().NotBeNull().And.Be(1);
            siUnit.Offset.Should().NotBeNull().And.Be(0);
        }
    }
}
