namespace Blobfish.Builders
{
    using System;

    public class ExtensionBuilder
    {
        private Extension extension;

        public ExtensionBuilder(string uri, string name)
        {
            this.extension = new Extension(uri, name);
        }

        public ExtensionBuilder(Uri uri, string name)
        {
            this.extension = new Extension(uri, name);
        }

        public Extension Build() => this.extension;

        public ExtensionBuilder WithSha256(string sha256)
        {
            this.extension.Sha256 = sha256;
            return this;
        }
    }
}
