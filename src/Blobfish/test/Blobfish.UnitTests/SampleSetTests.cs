namespace Blobfish.UnitTests
{
    using FluentAssertions;

    using Xunit;


    public class SampleSetTests
    {
        [Fact]
        public void SampleSetSampleCollectionShouldBeInitialized()
        {
            SampleSet sampleSet = new SampleSet();
            sampleSet.Samples.Should().NotBeNull();
        }
    }
}
