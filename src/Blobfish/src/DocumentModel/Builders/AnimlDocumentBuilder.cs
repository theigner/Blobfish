namespace Blobfish.Builders
{
    public class AnimlDocumentBuilder
    {
        private AnimlDocument animlDocument;

        public AnimlDocumentBuilder()
        {
            this.animlDocument = new AnimlDocument();
        }

        public AnimlDocument Build() => this.animlDocument;

        public AnimlDocumentBuilder WithSampleSet(SampleSet sampleSet)
        {
            this.animlDocument.SampleSet = sampleSet;
            return this;
        }

        public AnimlDocumentBuilder WithExperimentStepSet(ExperimentStepSet experimentStepSet)
        {
            this.animlDocument.ExperimentStepSet = experimentStepSet;
            return this;
        }

        public AnimlDocumentBuilder WithAuditTrailEntrySet(AuditTrailEntrySet auditTrailEntrySet)
        {
            this.animlDocument.AuditTrailEntrySet = auditTrailEntrySet;
            return this;
        }       
    }
}
