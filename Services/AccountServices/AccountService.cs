using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models;
using cw_8_ko_xDejw.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cw_8_ko_xDejw.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly MedDbContext _context;
        public AccountService(IConfiguration configuration, MedDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public bool UserExists(string login)
        {
            return _context.LoginRequests.Any(e => e.Login == login);
        }
        public PasswordVerificationResult CheckPassword(Models.Account.DTOs.LoginRequest data)
        {
            var hasher = new PasswordHasher<Models.Account.DTOs.LoginRequest>();
            var password = _context.LoginRequests.Where(e => e.Login == data.Login).Select(e => e.Password).FirstOrDefault().ToString();
            return hasher.VerifyHashedPassword(data, password, data.Password);

        }
        public async Task AddUser(Models.Account.DTOs.LoginRequest data, string refreshToken)
        {
            var hasher = new PasswordHasher<Models.Account.DTOs.LoginRequest>();
            var hashedPassword = hasher.HashPassword(data, data.Password);

            var user = new LoginRequest
            {
                Login = data.Login,
                Password = hashedPassword,
                RefreshToken = refreshToken
            };

            await _context.AddAsync(user);
        }
        public bool RefreshTokenExists(string refreshToken)
        {
            return _context.LoginRequests.Any(e => e.RefreshToken == refreshToken);
        }

        public JwtSecurityToken GenerateJWTToken(string login)
        {
            var claims = new Claim[]
            {
                new (ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken("https://localhost:5001", "https://localhost:5001",
                    claims, expires: System.DateTime.UtcNow.AddMinutes(5), signingCredentials: creds);
            

        }

        public string GenerateRefreshToken()
        {
            var refreshToken = "";
            using (var genNum = RandomNumberGenerator.Create())
            {
                var r = new byte[512];
                genNum.GetBytes(r);
                refreshToken = Convert.ToBase64String(r);
            }

            return refreshToken;
        }

        public string GetLoginByRefreshToken(string refreshToken)
        {
            return _context.LoginRequests.Where(e => e.RefreshToken == refreshToken).Select(e => e.Login).FirstOrDefault();
        }

        public string GetRefreshTokenByLogin(string login)
        {
            return _context.LoginRequests.Where(e => e.Login == login).Select(e => e.RefreshToken).FirstOrDefault();
        }
         public async Task SaveDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}