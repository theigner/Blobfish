namespace Blobfish.UnitTests
{
    using Blobfish.Builders;

    using FluentAssertions;

    using Xunit;

    public class SIUnitBuilderTests
    {
        [Fact]
        [Trait("Category", "Builders")]
        public void BuilderAssignsValuesCorrectly()
        {
            SIUnit siUnit =
                new SIUnitBuilder(SIBaseUnit.Meter)
                    .WithExponent(1)
                    .WithFactor(1000)
                    .WithOffset(0)
                    .Build();

            siUnit.BaseUnit.Should().Be(SIBaseUnit.Meter);
            siUnit.Exponent.Should().Be(1);
            siUnit.Factor.Should().Be(1000);
            siUnit.Offset.Should().Be(0);
        }
    }
}
