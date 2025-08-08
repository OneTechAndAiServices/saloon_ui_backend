using System;

namespace Domain.Entities
{
    public class Slot : BaseEntity
    {
        public long WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsBooked { get; set; }
        public long? AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
} 