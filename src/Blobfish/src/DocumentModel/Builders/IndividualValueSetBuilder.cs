namespace Blobfish.Builders
{
    using System;
    using System.Collections.Generic;

    public class IndividualValueSetBuilder
    {
        private IndividualValueSet individualValueSet;

        public IndividualValueSetBuilder(SeriesType seriesType)
        {
            this.individualValueSet = new IndividualValueSet(seriesType);
        }

        public IndividualValueSetBuilder(IEnumerable<bool> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<DateTime> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }
        public IndividualValueSetBuilder(IEnumerable<double> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<EmbeddedXml> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<float> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<int> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<long> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<PngImage> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<string> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(IEnumerable<SvgImage> values)
        {
            this.individualValueSet = new IndividualValueSet(values);
        }

        public IndividualValueSetBuilder(SeriesType seriesType, IEnumerable<dynamic> values)
        {
            this.individualValueSet = new IndividualValueSet(seriesType, values);
        }

        public IndividualValueSet Build() => this.individualValueSet;

        public IndividualValueSetBuilder WithEndIndex(int endIndex)
        {
            this.individualValueSet.EndIndex = endIndex;
            return this;
        }

        public IndividualValueSetBuilder WithStartIndex(int startIndex)
        {
            this.individualValueSet.StartIndex = startIndex;
            return this;
        }
    }
}
