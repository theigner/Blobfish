namespace Blobfish.Builders
{
    public class ParentDataPointReferenceBuilder
    {
        private ParentDataPointReference parentDataPointReference;

        public ParentDataPointReferenceBuilder(string seriesId, dynamic startValue)
        {
            this.parentDataPointReference = new ParentDataPointReference(seriesId, startValue);
        }

        public ParentDataPointReference Build() => this.parentDataPointReference;

        public ParentDataPointReferenceBuilder WithEndValue(dynamic endValue)
        {
            this.parentDataPointReference.EndValue = endValue;
            return this;
        }

        public ParentDataPointReferenceBuilder WithId(string id)
        {
            this.parentDataPointReference.Id = id;
            return this;
        }

        public ParentDataPointReferenceBuilder WithStartValue(dynamic startValue)
        {
            this.parentDataPointReference.StartValue = startValue;
            return this;
        }
    }
}
