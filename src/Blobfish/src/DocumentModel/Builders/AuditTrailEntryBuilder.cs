namespace Blobfish.Builders
{
    using System;
    using System.Collections.Generic;

    public class AuditTrailEntryBuilder
    {
        private AuditTrailEntry auditTrailEntry;

        public AuditTrailEntryBuilder(DateTime timestamp, Author author, Blobfish.Action action)
        {
            this.auditTrailEntry = new AuditTrailEntry(timestamp, author, action);
        }

        public AuditTrailEntry Build() => this.auditTrailEntry;

        public AuditTrailEntryBuilder WithComment(string comment)
        {
            this.auditTrailEntry.Comment = comment;
            return this;
        }

        public AuditTrailEntryBuilder WithDiff(Diff diff)
        {
            this.auditTrailEntry.Diffs.Add(diff);
            return this;
        }

        public AuditTrailEntryBuilder WithDiffs(IEnumerable<Diff> diffs)
        {
            this.auditTrailEntry.Diffs.AddRange(diffs);
            return this;
        }

        public AuditTrailEntryBuilder WithId(string id)
        {
            this.auditTrailEntry.Id = id;
            return this;
        }

        public AuditTrailEntryBuilder WithReason(string reason)
        {
            this.auditTrailEntry.Reason = reason;
            return this;
        }

        public AuditTrailEntryBuilder WithReference(string reference)
        {
            this.auditTrailEntry.References.Add(reference);
            return this;
        }

        public AuditTrailEntryBuilder WithReferences(IEnumerable<string> references)
        {
            this.auditTrailEntry.References.AddRange(references);
            return this;
        }

        public AuditTrailEntryBuilder WihtSoftware(Software software)
        {
            this.auditTrailEntry.Software = software;
            return this;
        }
    }
}
