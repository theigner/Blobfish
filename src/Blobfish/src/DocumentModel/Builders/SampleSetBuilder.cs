namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class SampleSetBuilder
    {
        private SampleSet sampleSet;

        public SampleSetBuilder()
        {
            this.sampleSet = new SampleSet();
        }

        public SampleSet Build() => this.sampleSet;

        public SampleSetBuilder WithId(string id)
        {
            this.sampleSet.Id = id;
            return this;
        }

        public SampleSetBuilder WithSample(Sample sample)
        {
            this.sampleSet.Samples.Add(sample);
            return this;
        }

        public SampleSetBuilder WithSamples(IEnumerable<Sample> samples)
        {
            this.sampleSet.Samples.AddRange(samples);
            return this;
        }
    }
}
