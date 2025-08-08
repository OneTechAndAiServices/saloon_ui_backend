using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public long? UserId { get; }
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            var user = accessor.HttpContext?.User;
            if (user != null && user.Identity?.IsAuthenticated == true)
            {
                var idStr = user.FindFirstValue(ClaimTypes.NameIdentifier);
                if (long.TryParse(idStr, out var id))
                    UserId = id;
            }
        }
    }
} 