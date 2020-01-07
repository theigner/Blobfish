namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class ExperimentDataReferenceSetBuilder
    {
        private ExperimentDataReferenceSet experimentDataReferenceSet;

        public ExperimentDataReferenceSetBuilder()
        {
            this.experimentDataReferenceSet = new ExperimentDataReferenceSet();
        }

        public ExperimentDataReferenceSet Build() => this.experimentDataReferenceSet;

        public ExperimentDataReferenceSetBuilder WithExperimentDataBulkReference(ExperimentDataBulkReference experimentDataBulkReference)
        {
            this.experimentDataReferenceSet.ExperimentDataBulkReferences.Add(experimentDataBulkReference);
            return this;
        }

        public ExperimentDataReferenceSetBuilder WithExperimentDataBulkReference(IEnumerable<ExperimentDataBulkReference> experimentDataBulkReferences)
        {
            this.experimentDataReferenceSet.ExperimentDataBulkReferences.AddRange(experimentDataBulkReferences);
            return this;
        }

        public ExperimentDataReferenceSetBuilder WithExperimentDataReference(ExperimentDataReference experimentDataReference)
        {
            this.experimentDataReferenceSet.ExperimentDataReferences.Add(experimentDataReference);
            return this;
        }

        public ExperimentDataReferenceSetBuilder WithExperimentDataReference(IEnumerable<ExperimentDataReference> experimentDataReferences)
        {
            this.experimentDataReferenceSet.ExperimentDataReferences.AddRange(experimentDataReferences);
            return this;
        }

        public ExperimentDataReferenceSetBuilder WithId(string id)
        {
            this.experimentDataReferenceSet.Id = id;
            return this;
        }
    }
}
