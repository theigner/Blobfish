namespace Blobfish.Builders
{
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
