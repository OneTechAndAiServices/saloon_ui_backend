namespace Application.DTOs
{
    public class AppointmentAddOnDto
    {
        public long AppointmentId { get; set; }
        public long AddOnId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtBooking { get; set; }
    }
} 