namespace Blobfish.Builders
{
    public class SampleReferenceBuilder
    {
        private SampleReference sampleReference;

        public SampleReferenceBuilder(string sampleId, string role, SamplePurpose samplePurpose)
        {
            this.sampleReference = new SampleReference(sampleId, role, samplePurpose);
        }

        public SampleReference Build() => this.sampleReference;

        public SampleReferenceBuilder WithId(string id)
        {
            this.sampleReference.Id = id;
            return this;
        }
    }
}
