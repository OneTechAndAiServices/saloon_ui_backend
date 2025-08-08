using System;

namespace Application.DTOs
{
    public class SlotDto
    {
        public long Id { get; set; }
        public long WorkerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsBooked { get; set; }
        public long? AppointmentId { get; set; }
    }
} 