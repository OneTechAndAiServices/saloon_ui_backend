namespace Domain.Entities
{
    public class WorkerService
    {
        public long WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public long ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
} 