namespace Blobfish.Builders
{
    using System;
    using System.Collections.Generic;

    public class TechniqueBuilder
    {
        private Technique technique;

        public TechniqueBuilder(string uri, string name)
        {
            this.technique = new Technique(uri, name);
        }

        public TechniqueBuilder(Uri uri, string name)
        {
            this.technique = new Technique(uri, name);
        }

        public Technique Build() => this.technique;

        public TechniqueBuilder WithExtension(Extension extension)
        {
            this.technique.Extensions.Add(extension);
            return this;
        }

        public TechniqueBuilder WithExtensions(IEnumerable<Extension> extensions)
        {
            this.technique.Extensions.AddRange(extensions);
            return this;
        }

        public TechniqueBuilder WithId(string id)
        {
            this.technique.Id = id;
            return this;
        }

        public TechniqueBuilder WithSha256(string sha256)
        {
            this.technique.Sha256 = sha256;
            return this;
        }
    }
}
