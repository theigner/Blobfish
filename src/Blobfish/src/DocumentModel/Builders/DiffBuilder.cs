namespace Blobfish.Builders
{
    public class DiffBuilder
    {
        private Diff diff;

        public DiffBuilder(Scope scope, string changedItem)
        {
            this.diff = new Diff(scope, changedItem);
        }

        public Diff Build() => this.diff;

        public DiffBuilder WithNewValue(string newValue)
        {
            this.diff.NewValue = newValue;
            return this;
        }

        public DiffBuilder WithOldValue(string oldValue)
        {
            this.diff.OldValue = oldValue;
            return this;
        }
    }
}
