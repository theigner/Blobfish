namespace Blobfish.UnitTests
{
    using FluentAssertions;

    using Xunit;

    public class SeriesTests
    {
        [Fact]
        public void SeriesConstructorWorksCorrectly()
        {
            Series series = new Series("TestSeries", "S-TEST", Dependency.Independent, SeriesType.Int32);

            series.Name.Should().Be("TestSeries");
            series.SeriesId.Should().Be("S-TEST");
            series.Dependency.Should().Be(Dependency.Independent);
            series.SeriesType.Should().Be(SeriesType.Int32);
        }
    }
}
