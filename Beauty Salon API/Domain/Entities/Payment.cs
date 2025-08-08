using System;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public long BookingId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaidAt { get; set; }
    }
} 