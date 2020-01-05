namespace Blobfish.Builders
{
    public class SIUnitBuilder
    {
        private SIUnit siUnit;

        public SIUnitBuilder(SIBaseUnit siBaseUnit)
        {
            this.siUnit = new SIUnit(siBaseUnit);
        }

        public SIUnitBuilder WithFactor(double factor)
        {
            this.siUnit.Factor = factor;
            return this;
        }

        public SIUnitBuilder WithExponent(double factor)
        {
            this.siUnit.Exponent = factor;
            return this;
        }

        public SIUnitBuilder WithOffset(double factor)
        {
            this.siUnit.Offset = factor;
            return this;
        }

        public SIUnit Build() => this.siUnit;
    }
}
