namespace Blobfish
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents a PNG image that is embedded in an AnIML document
    /// </summary>
    public class PngImage
    {
        /// <summary>
        /// Creates a new instance of class PngImage.
        /// </summary>
        public PngImage()
        {
        }

        /// <summary>
        /// Creates a new instance of class PngImage.
        /// </summary>
        /// <param name="imageBytes">A byte array containing the binary data of a PNG image.</param>
        public PngImage(byte[] imageBytes)
        {
            this.ImageBytes = imageBytes;
        }

        /// <summary>
        /// Creates a new instance of class PngImage.
        /// </summary>
        /// <param name="base64String">The base64 representation of the binary data of a PNG image.</param>
        public PngImage(string base64String)
        {
            this.ImageBytes = Convert.FromBase64String(base64String);
        }

        /// <summary>
        /// Gets or sets the PNG image in binary form.
        /// </summary>
        public byte[] ImageBytes { get; set; }

        /// <summary>
        /// Creates a new instance of a PNG image from a file.
        /// </summary>
        /// <param name="path">The path of the PNG file to read.</param>
        /// <returns>A new PngImage.</returns>
        public static PngImage FromFile(string path)
        {
            return new PngImage(File.ReadAllBytes(path));
        }
    }
}
