namespace Application.DTOs
{
    public class ClientDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public int LoyaltyPoints { get; set; }
    }
} 