namespace Blobfish
{
    using System.Xml.Linq;

    /// <summary>
    /// Device used to perform an Experiment.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Creates a new instance of the Device class.
        /// </summary>
        /// <param name="name">The common name of the Device.</param>
        public Device(string name)
        {
            this.Name = name;
        }

        internal Device()
        {
        }

        /// <summary>
        /// Gets or sets the unique name or identifier of the device.
        /// </summary>
        public string DeviceIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the device manufacturer company name.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the common name of th Device..
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version identifier of firmware release of the device.
        /// </summary>
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the unique serial number of the device.
        /// </summary>
        public string SerialNumber { get; set; }

        internal static Device FromXElement(XElement deviceElement)
        {
            Device device = new Device();

            //// Import the child elements of the current object
            device.DeviceIdentifier = deviceElement.Element(NamespaceHelper.GetXName("DeviceIdentifier"))?.Value;
            device.Manufacturer = deviceElement.Element(NamespaceHelper.GetXName("Manufacturer"))?.Value;
            device.Name = deviceElement.Element(NamespaceHelper.GetXName("Name")).Value;
            device.FirmwareVersion = deviceElement.Element(NamespaceHelper.GetXName("FirmwareVersion"))?.Value;
            device.SerialNumber = deviceElement.Element(NamespaceHelper.GetXName("SerialNumber"))?.Value;

            return device;
        }

        internal XElement ToXElement()
        {
            XElement deviceElement = new XElement(NamespaceHelper.GetXName("Device"));

            //// Export the child elements of the current object
            deviceElement.AddElementIfValueNotNullOrEmpty("DeviceIdentifier", this.DeviceIdentifier);
            deviceElement.AddElementIfValueNotNullOrEmpty("Manufacturer", this.Manufacturer);
            deviceElement.AddElement("Name", this.Name);
            deviceElement.AddElementIfValueNotNullOrEmpty("FirmwareVersion", this.FirmwareVersion);
            deviceElement.AddElementIfValueNotNullOrEmpty("SerialNumber", this.SerialNumber);

            return deviceElement;
        }
    }
}
