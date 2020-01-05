namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class ExperimentStepBuilder
    {
        private ExperimentStep experimentStep;

        public ExperimentStepBuilder(string name, string experimentStepId)
        {
            this.experimentStep = new ExperimentStep(name, experimentStepId);
        }

        public ExperimentStep Build() => this.experimentStep;

        public ExperimentStepBuilder WithComment(string comment)
        {
            this.experimentStep.Comment = comment;
            return this;
        }

        public ExperimentStepBuilder WithId(string id)
        {
            this.experimentStep.Id = id;
            return this;
        }

        public ExperimentStepBuilder WithInfrastructure(Infrastructure infrastructure)
        {
            this.experimentStep.Infrastructure = infrastructure;
            return this;
        }

        public ExperimentStepBuilder WithMethod(Method method)
        {
            this.experimentStep.Method = method;
            return this;
        }

        public ExperimentStepBuilder WithResult(Result result)
        {
            this.experimentStep.Results.Add(result);
            return this;
        }

        public ExperimentStepBuilder WithResults(IEnumerable<Result> result)
        {
            this.experimentStep.Results.AddRange(result);
            return this;
        }

        public ExperimentStepBuilder WithSourceDataLocation(string sourceDataLocation)
        {
            this.experimentStep.SourceDataLocation = sourceDataLocation;
            return this;
        }

        public ExperimentStepBuilder WithTagSet(TagSet tagSet)
        {
            this.experimentStep.TagSet = tagSet;
            return this;
        }

        public ExperimentStepBuilder WithTechnique(Technique technique)
        {
            this.experimentStep.Technique = technique;
            return this;
        }

        public ExperimentStepBuilder WithTemplateUsed(string templateUsed)
        {
            this.experimentStep.TemplateUsed = templateUsed;
            return this;
        }
    }
}
