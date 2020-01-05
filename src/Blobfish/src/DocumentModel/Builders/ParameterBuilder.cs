namespace Blobfish.Builders
{
    public class ParameterBuilder
    {
        private Parameter parameter;

        public ParameterBuilder(string name, dynamic value)
        {
            this.parameter = new Parameter(name, value);
        }

        public Parameter Build() => this.parameter;

        public ParameterBuilder WithId(string id)
        {
            this.parameter.Id = id;
            return this;
        }

        public ParameterBuilder WithUnit(Unit unit)
        {
            this.parameter.Unit = unit;
            return this;
        }
    }
}
