namespace TaskRira.Core.Common
{
    public interface IAuditedEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
