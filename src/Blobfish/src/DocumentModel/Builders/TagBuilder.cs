namespace Blobfish.Builders
{
    public class TagBuilder
    {
        private Tag tag;

        public TagBuilder(string name)
        {
            this.tag = new Tag(name);
        }

        public Tag Build() => this.tag;

        public TagBuilder WithValue(string value)
        {
            this.tag.Value = value;
            return this;
        }
    }
}
