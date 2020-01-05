namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class ParentDataPointReferenceSetBuilder
    {
        private ParentDataPointReferenceSet parentDataPointReferenceSet;

        public ParentDataPointReferenceSetBuilder()
        {
            this.parentDataPointReferenceSet = new ParentDataPointReferenceSet();
        }

        public ParentDataPointReferenceSet Build() => this.parentDataPointReferenceSet;

        public ParentDataPointReferenceSetBuilder WithParentDataPointReference(ParentDataPointReference parentDataPointReference)
        {
            this.parentDataPointReferenceSet.ParentDataPointReferences.Add(parentDataPointReference);
            return this;
        }

        public ParentDataPointReferenceSetBuilder WithParentDataPointReferences(IEnumerable<ParentDataPointReference> parentDataPointReferences)
        {
            this.parentDataPointReferenceSet.ParentDataPointReferences.AddRange(parentDataPointReferences);
            return this;
        }
    }
}
