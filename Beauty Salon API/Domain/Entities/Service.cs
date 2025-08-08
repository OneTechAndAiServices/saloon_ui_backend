using System.Collections.Generic;

namespace Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
        public string Tags { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<WorkerService> WorkerServices { get; set; }
        public virtual ICollection<ServiceAddOn> ServiceAddOns { get; set; }
    }
} 