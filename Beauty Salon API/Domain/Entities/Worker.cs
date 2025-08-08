using System.Collections.Generic;

namespace Domain.Entities
{
    public class Worker : BaseEntity
    {
        public long UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string Specialties { get; set; }
        public virtual ICollection<WorkerService> WorkerServices { get; set; }
    }
} 