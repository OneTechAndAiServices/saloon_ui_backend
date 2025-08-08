using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto { Success = false, Error = "Passwords do not match." });
            }

            var user = new ApplicationUser {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto { Success = false, Error = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }

            // Assign default role if needed (e.g., "Client")
            // await _userManager.AddToRoleAsync(user, "Client");

            var token = await GenerateJwtTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var fullName = $"{user.FirstName} {user.LastName}".Trim();
            return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto {
                Success = true,
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                Roles = roles.ToList(),
                FullName = fullName
            });
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto { Success = false, Error = "Invalid credentials." });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto { Success = false, Error = "Invalid credentials." });
            }

            var token = await GenerateJwtTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var fullName = $"{user.FirstName} {user.LastName}".Trim();
            return System.Text.Json.JsonSerializer.Serialize(new AuthResponseDto {
                Success = true,
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                Roles = roles.ToList(),
                FullName = fullName
            });
        }

        private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 