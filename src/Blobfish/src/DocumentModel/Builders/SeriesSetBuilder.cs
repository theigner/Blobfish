namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class SeriesSetBuilder
    {
        private SeriesSet seriesSet;

        public SeriesSetBuilder(string name, int length)
        {
            this.seriesSet = new SeriesSet(name, length);
        }

        public SeriesSet Build() => this.seriesSet;

        public SeriesSetBuilder WithId(string id)
        {
            this.seriesSet.Id = id;
            return this;
        }

        public SeriesSetBuilder WithSeries(IEnumerable<Series> series)
        {
            this.seriesSet.Series.AddRange(series);
            return this;

        }

        public SeriesSetBuilder WithSeries(Series series)
        {
            this.seriesSet.Series.Add(series);
            return this;
        }
    }
}
