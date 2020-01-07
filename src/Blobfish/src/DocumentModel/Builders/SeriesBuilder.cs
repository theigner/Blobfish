namespace Blobfish.Builders
{
    using System;
    using System.Collections.Generic;

    public class SeriesBuilder
    {
        private Series series;

        public SeriesBuilder(string name, string seriesId, Dependency dependency, SeriesType seriesType)
        {
            this.series = new Series(name, seriesId, dependency, seriesType);
        }

        public Series Build() => this.series;

        public SeriesBuilder WithId(string id)
        {
            this.series.Id = id;
            return this;
        }

        public SeriesBuilder WithPlotScale(PlotScale plotScale)
        {
            this.series.PlotScale = plotScale;
            return this;
        }

        public SeriesBuilder WithUnit(Unit unit)
        {
            this.series.Unit = unit;
            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(double startValue, double increment)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment).Build());
            
            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(double startValue, double increment, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(dynamic startValue, dynamic increment)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment).Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(dynamic startValue, dynamic increment, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(float startValue, float increment)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment).Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(float startValue, float increment, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(int startValue, int increment)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment).Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(int startValue, int increment, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(long startValue, long increment)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment).Build());

            return this;
        }

        public SeriesBuilder WithAutoIncrementedValueSet(long startValue, long increment, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new AutoIncrementedValueSetBuilder(startValue, increment)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<double> values)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<double> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<float> values)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<float> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<int> values)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<int> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<long> values)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(IEnumerable<long> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(SeriesType seriesType, IEnumerable<dynamic> values)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(seriesType, values).Build());

            return this;
        }

        public SeriesBuilder WithEncodedValueSet(SeriesType seriesType, IEnumerable<dynamic> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new EncodedValueSetBuilder(seriesType, values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<bool> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<bool> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<DateTime> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<DateTime> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<double> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<double> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<EmbeddedXml> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<EmbeddedXml> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<float> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<float> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<int> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<int> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<long> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<long> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<PngImage> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<PngImage> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<string> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<string> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<SvgImage> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(IEnumerable<SvgImage> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(SeriesType seriesType, IEnumerable<dynamic> values)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(seriesType, values).Build());

            return this;
        }

        public SeriesBuilder WithIndividualValueSet(SeriesType seriesType, IEnumerable<dynamic> values, int startIndex, int endIndex)
        {
            this.series.ValueSets.Add(
                new IndividualValueSetBuilder(seriesType, values)
                    .WithStartIndex(startIndex)
                    .WithEndIndex(endIndex)
                    .Build());

            return this;
        }

        public SeriesBuilder WithValueSet(IValueSet valueSet)
        {
            this.series.ValueSets.Add(valueSet);
            return this;
        }

        public SeriesBuilder WithValueSets(IEnumerable<IValueSet> valueSets)
        {
            this.series.ValueSets.AddRange(valueSets);
            return this;
        }

        public SeriesBuilder WithVisible(bool visible)
        {
            this.series.Visible = visible;
            return this;
        }
    }
}
