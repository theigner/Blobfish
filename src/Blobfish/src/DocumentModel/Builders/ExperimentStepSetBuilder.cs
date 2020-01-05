namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class ExperimentStepSetBuilder
    {
        private ExperimentStepSet experimentStepSet;

        public ExperimentStepSetBuilder()
        {
            this.experimentStepSet = new ExperimentStepSet();
        }

        public ExperimentStepSet Build() => this.experimentStepSet;

        public ExperimentStepSetBuilder WithExperimentStep(ExperimentStep experimentStep)
        {
            this.experimentStepSet.ExperimentSteps.Add(experimentStep);
            return this;
        }

        public ExperimentStepSetBuilder WithExperimentSteps(IEnumerable<ExperimentStep> experimentSteps)
        {
            this.experimentStepSet.ExperimentSteps.AddRange(experimentSteps);
            return this;
        }

        public ExperimentStepSetBuilder WithId(string id)
        {
            this.experimentStepSet.Id = id;
            return this;
        }

        public ExperimentStepSetBuilder WithTemplate(Template template)
        {
            this.experimentStepSet.Templates.Add(template);
            return this;
        }
        public ExperimentStepSetBuilder WithTemplates(IEnumerable<Template> templates)
        {
            this.experimentStepSet.Templates.AddRange(templates);
            return this;
        }
    }
}
