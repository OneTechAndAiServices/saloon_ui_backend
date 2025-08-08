namespace Application.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public string Status { get; set; }
    }
} 