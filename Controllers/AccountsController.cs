using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cw_8_ko_xDejw.Models.Account.DTOs;
using cw_8_ko_xDejw.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cw_8_ko_xDejw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            
            if(_service.UserExists(request.Login) && _service.CheckPassword(request) == 0)
            {
                return Unauthorized("Password is incorrect");
            }
            
            var refreshToken = "";

            if(!_service.UserExists(request.Login))
            {
                refreshToken = _service.GenerateRefreshToken();
                await _service.AddUser(request, refreshToken);
            } else
                refreshToken = _service.GetRefreshTokenByLogin(request.Login);
            
            await _service.SaveDatabase();
            
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(_service.GenerateJWTToken(request.Login)),
                refreshToken
            });
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RequestRefresh(string refreshToken)
        {
            if(_service.RefreshTokenExists(refreshToken))
            {
                var login = _service.GetLoginByRefreshToken(refreshToken);
                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(_service.GenerateJWTToken(login))
                });
            } else 
                return NotFound("Refresh token not found");
        }
    }
}