namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class TemplateBuilder
    {
        private Template template;

        public TemplateBuilder(string name, string templateId)
        {
            this.template = new Template(name, templateId);
        }

        public Template Build() => this.template;

        public TemplateBuilder WithId(string id)
        {
            this.template.Id = id;
            return this;
        }

        public TemplateBuilder WithInfrastructure(Infrastructure infrastructure)
        {
            this.template.Infrastructure = infrastructure;
            return this;
        }

        public TemplateBuilder WithMethod(Method method)
        {
            this.template.Method = method;
            return this;
        }

        public TemplateBuilder WithResult(Result result)
        {
            this.template.Results.Add(result);
            return this;
        }

        public TemplateBuilder WithResults(IEnumerable<Result> results)
        {
            this.template.Results.AddRange(results);
            return this;
        }

        public TemplateBuilder WithSourceDataLocation(string sourceDataLocation)
        {
            this.template.SourceDataLocation = sourceDataLocation;
            return this;
        }

        public TemplateBuilder WithTagSet(TagSet tagSet)
        {
            this.template.TagSet = tagSet;
            return this;
        }

        public TemplateBuilder WithTechnique(Technique technique)
        {
            this.template.Technique = technique;
            return this;
        }
    }
}
