namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class CategoryBuilder
    {
        private Category category;

        public CategoryBuilder(string name)
        {
            this.category = new Category(name);
        }

        public Category Build() => this.category;

        public CategoryBuilder WithCategories(IEnumerable<Category> categories)
        {
            this.category.Categories.AddRange(categories);
            return this;
        }

        public CategoryBuilder WithCategory(Category category)
        {
            this.category.Categories.Add(category);
            return this;
        }

        public CategoryBuilder WithId(string id)
        {
            this.category.Id = id;
            return this;
        }

        public CategoryBuilder WithParameter(Parameter parameter)
        {
            this.category.Parameters.Add(parameter);
            return this;
        }

        public CategoryBuilder WithParameters(IEnumerable<Parameter> parameters)
        {
            this.category.Parameters.AddRange(parameters);
            return this;
        }

        public CategoryBuilder WithSeriesSet(SeriesSet seriesSet)
        {
            this.category.SeriesSets.Add(seriesSet);
            return this;
        }

        public CategoryBuilder WithSeriesSets(IEnumerable<SeriesSet> seriesSets)
        {
            this.category.SeriesSets.AddRange(seriesSets);
            return this;
        }
    }
}
