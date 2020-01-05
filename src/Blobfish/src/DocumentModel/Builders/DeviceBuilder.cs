namespace Blobfish.Builders
{
    public class DeviceBuilder
    {
        private Device device;

        public DeviceBuilder(string name)
        {
            this.device = new Device(name);
        }

        public Device Build() => this.device;

        public DeviceBuilder WithDeviceIdentifier(string deviceIdentifier)
        {
            this.device.DeviceIdentifier = deviceIdentifier;
            return this;
        }

        public DeviceBuilder WithFirmwareVersion(string firmwareVersion)
        {
            this.device.FirmwareVersion = firmwareVersion;
            return this;
        }

        public DeviceBuilder WithManufacturer(string manufacturer)
        {
            this.device.Manufacturer = manufacturer;
            return this;
        }

        public DeviceBuilder WithSerialNumber(string serialNumber)
        {
            this.device.SerialNumber = serialNumber;
            return this;
        }
    }
}
