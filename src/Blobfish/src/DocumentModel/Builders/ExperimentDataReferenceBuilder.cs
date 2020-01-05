namespace Blobfish.DocumentModel.Builders
{
    public class ExperimentDataReferenceBuilder
    {
        private ExperimentDataReference experimentDataReference;

        public ExperimentDataReferenceBuilder(string experimentStepId, string role, ExperimentDataPurpose experimentDataPurpose)
        {
            this.experimentDataReference = new ExperimentDataReference(experimentStepId, role, experimentDataPurpose);
        }

        public ExperimentDataReference Build() => this.experimentDataReference;

        public ExperimentDataReferenceBuilder WithId(string id)
        {
            this.experimentDataReference.Id = id;
            return this;
        }
    }
}
