namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class TagSetBuilder
    {
        private TagSet tagSet;

        public TagSetBuilder()
        {
            this.tagSet = new TagSet();
        }

        public TagSet Build() => this.tagSet;

        public TagSetBuilder WithTag(Tag tag)
        {
            this.tagSet.Tags.Add(tag);
            return this;
        }

        public TagSetBuilder WithTags(IEnumerable<Tag> tags)
        {
            this.tagSet.Tags.AddRange(tags);
            return this;
        }
    }
}
