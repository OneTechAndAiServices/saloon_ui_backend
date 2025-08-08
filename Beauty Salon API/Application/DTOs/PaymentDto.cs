using System;

namespace Application.DTOs
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long BookingId { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaidAt { get; set; }
    }
} 