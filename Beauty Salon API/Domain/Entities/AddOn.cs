using System.Collections.Generic;

namespace Domain.Entities
{
    public class AddOn : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? DurationMinutes { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ServiceAddOn> ServiceAddOns { get; set; }
    }
} 