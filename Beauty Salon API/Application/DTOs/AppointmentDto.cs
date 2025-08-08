using System;

namespace Application.DTOs
{
    public class AppointmentDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long WorkerId { get; set; }
        public long ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public long? PaymentId { get; set; }
        public string Notes { get; set; }
        public Guid BookingId { get; set; }
    }
} 