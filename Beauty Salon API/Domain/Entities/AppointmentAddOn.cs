namespace Domain.Entities
{
    public class AppointmentAddOn
    {
        public long AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public long AddOnId { get; set; }
        public virtual AddOn AddOn { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtBooking { get; set; }
    }
} 