namespace Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public long? UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string FullName { get; set; }
    }
} 