namespace Blobfish.Builders
{
    public class AutoIncrementedValueSetBuilder
    {
        private AutoIncrementedValueSet autoIncrementedValueSet;

        public AutoIncrementedValueSetBuilder(double startValue, double increment)
        {
            this.autoIncrementedValueSet = new AutoIncrementedValueSet(startValue, increment);
        }

        public AutoIncrementedValueSetBuilder(dynamic startValue, dynamic increment)
        {
            this.autoIncrementedValueSet = new AutoIncrementedValueSet(startValue, increment);
        }

        public AutoIncrementedValueSetBuilder(float startValue, float increment)
        {
            this.autoIncrementedValueSet = new AutoIncrementedValueSet(startValue, increment);
        }

        public AutoIncrementedValueSetBuilder(int startValue, int increment)
        {
            this.autoIncrementedValueSet = new AutoIncrementedValueSet(startValue, increment);
        }

        public AutoIncrementedValueSetBuilder(long startValue, long increment)
        {
            this.autoIncrementedValueSet = new AutoIncrementedValueSet(startValue, increment);
        }

        public AutoIncrementedValueSet Build() => this.autoIncrementedValueSet;

        public AutoIncrementedValueSetBuilder WithEndIndex(int endIndex)
        {
            this.autoIncrementedValueSet.EndIndex = endIndex;
            return this;
        }

        public AutoIncrementedValueSetBuilder WithStartIndex(int startIndex)
        {
            this.autoIncrementedValueSet.StartIndex = startIndex;
            return this;
        }
    }
}
