using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
        public long WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public long ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public long? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public string Notes { get; set; }
        public Guid BookingId { get; set; }
        public virtual ICollection<AppointmentAddOn> AppointmentAddOns { get; set; }
    }
} 