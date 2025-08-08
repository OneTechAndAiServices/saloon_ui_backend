namespace Domain.Entities
{
    public class ServiceAddOn
    {
        public long ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public long AddOnId { get; set; }
        public virtual AddOn AddOn { get; set; }
    }
} 