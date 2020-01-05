namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class UnitBuilder
    {
        private Unit unit;

        public UnitBuilder(string label)
        {
            this.unit = new Unit(label);
        }

        public Unit Build() => this.unit;

        public UnitBuilder WithQuantity(string quantity)
        {
            this.unit.Quantity = quantity;
            return this;
        }

        public UnitBuilder WithSIUnit(SIUnit siUnit)
        {
            this.unit.SIUnits.Add(siUnit);
            return this;
        }

        public UnitBuilder WithSIUnits(IEnumerable<SIUnit> siUnits)
        {
            this.unit.SIUnits.AddRange(siUnits);
            return this;
        }
    }
}
