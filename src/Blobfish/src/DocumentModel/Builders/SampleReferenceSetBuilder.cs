namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class SampleReferenceSetBuilder
    {
        private SampleReferenceSet sampleReferenceSet;

        public SampleReferenceSetBuilder()
        {
            this.sampleReferenceSet = new SampleReferenceSet();
        }

        public SampleReferenceSet Build() => this.sampleReferenceSet;

        public SampleReferenceSetBuilder WithId(string id)
        {
            this.sampleReferenceSet.Id = id;
            return this;
        }

        public SampleReferenceSetBuilder WithSampleInheritance(SampleInheritance sampleInheritance)
        {
            this.sampleReferenceSet.SampleInheritances.Add(sampleInheritance);
            return this;
        }

        public SampleReferenceSetBuilder WithSampleInheritances(IEnumerable<SampleInheritance> sampleInheritances)
        {
            this.sampleReferenceSet.SampleInheritances.AddRange(sampleInheritances);
            return this;
        }

        public SampleReferenceSetBuilder WithSampleReference(SampleReference sampleReference)
        {
            this.sampleReferenceSet.SampleReferences.Add(sampleReference);
            return this;
        }

        public SampleReferenceSetBuilder WithSampleReferences(IEnumerable<SampleReference> sampleReferences)
        {
            this.sampleReferenceSet.SampleReferences.AddRange(sampleReferences);
            return this;
        }
    }
}
