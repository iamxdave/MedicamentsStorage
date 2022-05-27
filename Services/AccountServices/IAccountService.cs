using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace cw_8_ko_xDejw.Services
{
    public interface IAccountService
    {
        public bool UserExists(string login);
        public PasswordVerificationResult CheckPassword(Models.Account.DTOs.LoginRequest data);
        public Task AddUser(Models.Account.DTOs.LoginRequest data, string refreshToken);
        public bool RefreshTokenExists(string refreshToken);
        public JwtSecurityToken GenerateJWTToken(string login);
        public string GenerateRefreshToken();
        public string GetLoginByRefreshToken(string refreshToken);
        public string GetRefreshTokenByLogin(string login);
        public Task SaveDatabase();
    }
}