namespace Blobfish.UnitTests
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Xunit;

    public class Base64EncodingExtensionsTests
    {
        [Fact]
        public void ConvertIntBackAndForWorksCorrectly()
        {
            List<int> intValues = new List<int>() { 1, 2, 6, 8, 12 };
            intValues.ToBase64String().ToIntArray().Should().BeEquivalentTo(intValues);

            List<long> longValues = new List<long>() { 1000L, 2000L, 6000L, 8000L, 12000L };
            longValues.ToBase64String().ToLongArray().Should().BeEquivalentTo(longValues);

            List<float> floatValues = new List<float>() { 1.1f, 2.2f, 6.6f, 8.8f, 12.12f };
            floatValues.ToBase64String().ToFloatArray().Should().BeEquivalentTo(floatValues);

            List<double> doubleValues = new List<double>() { 1.12345, 2.23456, 6.67890, 8.89012, 12.12131 };
            doubleValues.ToBase64String().ToDoubleArray().Should().BeEquivalentTo(doubleValues);
        }
    }
}
