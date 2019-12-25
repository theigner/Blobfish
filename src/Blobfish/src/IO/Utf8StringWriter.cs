namespace Blobfish
{
    using System.IO;
    using System.Text;

    internal class Utf8StringWriter : StringWriter
    {
        internal Utf8StringWriter(StringBuilder sb)
            : base(sb)
        {
        }

        public sealed override Encoding Encoding => Encoding.UTF8;
    }
}
