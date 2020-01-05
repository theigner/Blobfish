namespace Blobfish.Builders
{
    public class SoftwareBuilder
    {
        private Software software;

        public SoftwareBuilder(string name)
        {
            this.software = new Software(name);
        }

        public Software Build() => this.software;

        public SoftwareBuilder WithManufacturer(string manufacturer)
        {
            this.software.Manufacturer = manufacturer;
            return this;
        }

        public SoftwareBuilder WithOperatingSystem(string operatingSystem)
        {
            this.software.OperatingSystem = operatingSystem;
            return this;
        }

        public SoftwareBuilder WithVersion(string version)
        {
            this.software.Version = version;
            return this;
        }
    }
}
