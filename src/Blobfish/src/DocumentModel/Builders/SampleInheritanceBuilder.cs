namespace Blobfish.Builders
{
    public class SampleInheritanceBuilder
    {
        private SampleInheritance sampleInheritance;

        public SampleInheritanceBuilder(string role, SamplePurpose samplePurpose)
        {
            this.sampleInheritance = new SampleInheritance(role, samplePurpose);
        }

        public SampleInheritance Build() => this.sampleInheritance;

        public SampleInheritanceBuilder WithId(string id)
        {
            this.sampleInheritance.Id = id;
            return this;
        }
    }
}
