namespace Blobfish.Builders
{
    using System.Collections.Generic;

    public class AuditTrailEntrySetBuilder
    {
        private AuditTrailEntrySet auditTrailEntrySet;

        public AuditTrailEntrySetBuilder()
        {
            this.auditTrailEntrySet = new AuditTrailEntrySet();
        }

        public AuditTrailEntrySet Build() => this.auditTrailEntrySet;

        public AuditTrailEntrySetBuilder WithAuditTrailEntries(IEnumerable<AuditTrailEntry> auditTrailEntries)
        {
            this.auditTrailEntrySet.AuditTrailEntries.AddRange(auditTrailEntries);
            return this;
        }

        public AuditTrailEntrySetBuilder WithAuditTrailEntry(AuditTrailEntry auditTrailEntry)
        {
            this.auditTrailEntrySet.AuditTrailEntries.Add(auditTrailEntry);
            return this;
        }

        public AuditTrailEntrySetBuilder WithId(string id)
        {
            this.auditTrailEntrySet.Id = id;
            return this;
        }
    }
}
