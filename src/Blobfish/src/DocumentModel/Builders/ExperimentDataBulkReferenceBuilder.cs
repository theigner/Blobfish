namespace Blobfish.Builders
{
    public class ExperimentDataBulkReferenceBuilder
    {
        private ExperimentDataBulkReference experimentDataBulkReference;

        public ExperimentDataBulkReferenceBuilder(string experimentStepIdPrefix, string role, ExperimentDataPurpose experimentDataPurpose)
        {
            this.experimentDataBulkReference = new ExperimentDataBulkReference(experimentStepIdPrefix, role, experimentDataPurpose);
        }

        public ExperimentDataBulkReference Build() => this.experimentDataBulkReference;

        public ExperimentDataBulkReferenceBuilder WithId(string id)
        {
            this.experimentDataBulkReference.Id = id;
            return this;
        }

    }
}
