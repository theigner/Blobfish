namespace Blobfish
{
    using System.IO;

    /// <summary>
    /// Represents a SVG image that is embedded in an AnIML document.
    /// </summary>
    public class SvgImage
    {
        /// <summary>
        /// Creates a new instance of class SvgImage.
        /// </summary>
        public SvgImage()
        {
        }

        /// <summary>
        /// Creates a new instance of class SvgImage.
        /// </summary>
        /// <param name="svgString">The defintion of the SVG image.</param>
        public SvgImage(string svgString)
        {
            this.SvgString = svgString;
        }

        /// <summary>
        /// Gets or sets the string representation of the SVG image.
        /// </summary>
        public string SvgString { get; set; }

        /// <summary>
        /// Creates a new instance of a SVG image from a file.
        /// </summary>
        /// <param name="path">The path of the SVG file to read.</param>
        /// <returns>A new SvgImage.</returns>
        public static SvgImage FromFile(string path)
        {
            return new SvgImage(File.ReadAllText(path));
        }
    }
}
