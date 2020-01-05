namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class MethodBuilder
    {
        private Method method;

        public MethodBuilder()
        {
            this.method = new Method();
        }

        public Method Build() => this.method;

        public MethodBuilder WithAuthor(Author author)
        {
            this.method.Author = author;
            return this;
        }

        public MethodBuilder WithCategory(IEnumerable<Category> categories)
        {
            this.method.Categories.AddRange(categories);
            return this;
        }

        public MethodBuilder WithCategory(Category category)
        {
            this.method.Categories.Add(category);
            return this;
        }

        public MethodBuilder WithDevice(Device device)
        {
            this.method.Device = device;
            return this;
        }

        public MethodBuilder WithId(string id)
        {
            this.method.Id = id;
            return this;
        }

        public MethodBuilder WithName(string name)
        {
            this.method.Name = name;
            return this;
        }

        public MethodBuilder WithSoftware(Software software)
        {
            this.method.Software = software;
            return this;
        }
    }
}
