namespace Blobfish.Builders
{
    using System;

    public class InfrastructureBuilder
    {
        private Infrastructure infrastructure;

        public InfrastructureBuilder()
        {
            this.infrastructure = new Infrastructure();
        }

        public Infrastructure Build() => this.infrastructure;

        public InfrastructureBuilder WithExperimentDataReferenceSet(ExperimentDataReferenceSet experimentDataReferenceSet)
        {
            this.infrastructure.ExperimentDataReferenceSet = experimentDataReferenceSet;
            return this;
        }

        public InfrastructureBuilder WithId(string id)
        {
            this.infrastructure.Id = id;
            return this;
        }

        public InfrastructureBuilder WithParentDataPointReferenceSet(ParentDataPointReferenceSet parentDataPointReferenceSet)
        {
            this.infrastructure.ParentDataPointReferenceSet = parentDataPointReferenceSet;
            return this;
        }

        public InfrastructureBuilder WithSampleReferenceSet(SampleReferenceSet sampleReferenceSet)
        {
            this.infrastructure.SampleReferencetSet = sampleReferenceSet;
            return this;
        }

        public InfrastructureBuilder WithTimestamp(DateTime timestamp)
        {
            this.infrastructure.Timestamp = timestamp;
            return this;
        }
    }
}
