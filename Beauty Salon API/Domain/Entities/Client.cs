using System;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public long UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public int LoyaltyPoints { get; set; }
    }
} 