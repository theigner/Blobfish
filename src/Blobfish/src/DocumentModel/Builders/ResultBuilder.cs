namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class ResultBuilder
    {
        private Result result;

        public ResultBuilder(string name)
        {
            this.result = new Result(name);
        }

        public Result Build() => this.result;

        public ResultBuilder WithCategories(IEnumerable<Category> categories)
        {
            this.result.Categories.AddRange(categories);
            return this;
        }

        public ResultBuilder WithCategory(Category category)
        {
            this.result.Categories.Add(category);
            return this;
        }

        public ResultBuilder WithExperimentStepSet(ExperimentStepSet experimentStepSet)
        {
            this.result.ExperimentStepSet = experimentStepSet;
            return this;
        }

        public ResultBuilder WithId(string id)
        {
            this.result.Id = id;
            return this;
        }

        public ResultBuilder WithSeriesSet(SeriesSet seriesSet)
        {
            this.result.SeriesSet = seriesSet;
            return this;
        }
    }
}
