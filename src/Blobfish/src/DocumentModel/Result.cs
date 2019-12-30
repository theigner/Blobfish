namespace Blobfish
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Container for Data derived from Experiment.
    /// </summary>
    public class Result : ISignableItemWithNameBase
    {
        /// <summary>
        /// Creates a new instace of the Result class.
        /// </summary>
        /// <param name="name"></param>
        public Result(string name)
        {
            Guard.AgainstNullOrEmpty(nameof(name), name);

            this.Name = name;
        }

        internal Result()
        {
        }

        /// <summary>
        /// Gets a collection of Categories assigned to the Result.
        /// </summary>
        public List<Category> Categories { get; } = new List<Category>();

        /// <summary>
        /// Gets or sets the ExperimentStepSet asssigned to the Result.
        /// </summary>
        public ExperimentStepSet ExperimentStepSet { get; set; }

        /// <summary>
        /// Gets or sets the SeriesSet assigned to the Result.
        /// </summary>
        public SeriesSet SeriesSet { get; set; }

        internal static Result FromXElement(XElement resultElement)
        {
            Result result = new Result();

            //// Import attributes for the implemented interfaces
            result.ImportISignableItemWithName(resultElement);

            //// Import the child elements of the current object
            XElement seriesSetElement = resultElement.Element(NamespaceHelper.GetXName("SeriesSet"));
            if (seriesSetElement != null)
            {
                result.SeriesSet = SeriesSet.FromXElement(seriesSetElement);
            }

            result.Categories.AddRange(resultElement.Elements(NamespaceHelper.GetXName("Category")).Select(Category.FromXElement));

            XElement experimentStepSetElement = resultElement.Element(NamespaceHelper.GetXName("ExperimentStepSet"));
            if (experimentStepSetElement != null)
            {
                result.ExperimentStepSet = ExperimentStepSet.FromXElement(experimentStepSetElement);
            }

            return result;
        }

        internal XElement ToXElement()
        {
            XElement resultElement = new XElement(NamespaceHelper.GetXName("Result"));

            //// Export attributes of all implemented interfaces
            resultElement.ImportISignableItemWithName(this);

            //// Export the child elements of the current object
            if (this.SeriesSet != null)
            {
                resultElement.Add(this.SeriesSet.ToXElement());
            }

            if (this.Categories?.Count > 0)
            {
                this.Categories.ForEach(c => resultElement.Add(c.ToXElement()));
            }

            if (this.ExperimentStepSet != null)
            {
                resultElement.Add(this.ExperimentStepSet.ToXElement());
            }

            return resultElement;
        }
    }
}
