namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class SampleBuilder
    {
        private Sample sample;

        public SampleBuilder(string name, string sampleId)
        {
            this.sample = new Sample(name, sampleId);
        }

        public Sample Build() => this.sample;

        public SampleBuilder WithBarcode(string barcode)
        {
            this.sample.Barcode = barcode;
            return this;
        }

        public SampleBuilder WithCategories(IEnumerable<Category> categories)
        {
            this.sample.Categories.AddRange(categories);
            return this;
        }

        public SampleBuilder WithCategory(Category category)
        {
            this.sample.Categories.Add(category);
            return this;
        }

        public SampleBuilder WithComment(string comment)
        {
            this.sample.Comment = comment;
            return this;
        }

        public SampleBuilder WithContainerId(string containerId)
        {
            this.sample.ContainerId = containerId;
            return this;
        }

        public SampleBuilder WithContainerInfo(string containerId, ContainerType containerType, string locationInContainer)
        {
            this.sample.ContainerId = containerId;
            this.sample.ContainerType = containerType;
            this.sample.LocationInContainer = locationInContainer;
            return this;
        }

        public SampleBuilder WithContainerType(ContainerType containerType)
        {
            this.sample.ContainerType = containerType;
            return this;
        }

        public SampleBuilder WithDerived(bool derived)
        {
            this.sample.Derived = derived;
            return this;
        }

        public SampleBuilder WithId(string id)
        {
            this.sample.Id = id;
            return this;
        }

        public SampleBuilder WithLocationInContainer(string locationInContainer)
        {
            this.sample.LocationInContainer = locationInContainer;
            return this;
        }


        public SampleBuilder WithSourceDataLocation(string sourceDataLocation)
        {
            this.sample.SourceDataLocation = sourceDataLocation;
            return this;
        }

        public SampleBuilder WithTagSet(TagSet tagSet)
        {
            this.sample.TagSet = tagSet;
            return this;
        }
    }
}
