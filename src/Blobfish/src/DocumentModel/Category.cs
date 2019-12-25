namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Defines a category of Parameters and SeriesSets. Used to model hierarchies.
    /// </summary>
    public class Category : ISignableItemWithNameBase
    {
        /// <summary>
        /// Creates a new instance of the Category class.
        /// </summary>
        /// <param name="name">The name of the Category.</param>
        public Category(string name)
            : this()
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Name = name;
        }

        internal Category()
        {
            this.Categories = new List<Category>();
            this.Parameters = new List<Parameter>();
            this.SeriesSets = new List<SeriesSet>();
        }

        /// <summary>
        /// Contains multiple subcategories of Category.
        /// </summary>
        public List<Category> Categories { get; private set; } = new List<Category>();

        /// <summary>
        /// Gets a collection of Parameters for the Category.
        /// </summary>
        public List<Parameter> Parameters { get; private set; } = new List<Parameter>();

        /// <summary>
        /// Gets a collection of SeriesSets for the Category.
        /// </summary>
        public List<SeriesSet> SeriesSets { get; private set; } = new List<SeriesSet>();

        internal static Category FromXElement(XElement categoryElement)
        {
            Category category = new Category();

            //// Import attributes for the implemented interfaces
            category.ImportISignableItemWithName(categoryElement);

            //// Import the child elements of the current object
            category.Parameters.AddRange(categoryElement.Elements(NamespaceHelper.GetXName("Parameter")).Select(Parameter.FromXElement));
            category.SeriesSets.AddRange(categoryElement.Elements(NamespaceHelper.GetXName("SeriesSet")).Select(SeriesSet.FromXElement));
            category.Categories.AddRange(categoryElement.Elements(NamespaceHelper.GetXName("Category")).Select(Category.FromXElement));

            return category;
        }

        internal XElement ToXElement()
        {
            XElement categoryElement = new XElement(NamespaceHelper.GetXName("Category"));

            //// Export attributes of all implemented interfaces
            categoryElement.ImportISignableItemWithName(this);

            //// Export the child elements of the current object
            if (this.Parameters.Count > 0)
            {
                this.Parameters.ForEach(p => categoryElement.Add(p.ToXElement()));
            }

            if (this.SeriesSets.Count > 0)
            {
                this.SeriesSets.ForEach(s => categoryElement.Add(s.ToXElement()));
            }

            if (this.Categories.Count > 0)
            {
                this.Categories.ForEach(c => categoryElement.Add(c.ToXElement()));
            }

            return categoryElement;
        }
    }
}
