namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class EncodedValueSetBuilder
    {
        private EncodedValueSet encodedValueSet;

        public EncodedValueSetBuilder(SeriesType seriesType)
        {
            this.encodedValueSet = new EncodedValueSet(seriesType);
        }

        public EncodedValueSetBuilder(SeriesType seriesType, IEnumerable<dynamic> values)
        {
            this.encodedValueSet = new EncodedValueSet(seriesType, values);
        }

        public EncodedValueSetBuilder(IEnumerable<double> values)
        {
            this.encodedValueSet = new EncodedValueSet(values);
        }

        public EncodedValueSetBuilder(IEnumerable<float> values)
        {
            this.encodedValueSet = new EncodedValueSet(values);
        }

        public EncodedValueSetBuilder(IEnumerable<int> values)
        {
            this.encodedValueSet = new EncodedValueSet(values);
        }

        public EncodedValueSetBuilder(IEnumerable<long> values)
        {
            this.encodedValueSet = new EncodedValueSet(values);
        }

        public EncodedValueSet Build() => this.encodedValueSet;

        public EncodedValueSetBuilder WithEndIndex(int endIndex)
        {
            this.encodedValueSet.EndIndex = endIndex;
            return this;
        }

        public EncodedValueSetBuilder WithStartIndex(int startIndex)
        {
            this.encodedValueSet.StartIndex = startIndex;
            return this;
        }
    }
}
