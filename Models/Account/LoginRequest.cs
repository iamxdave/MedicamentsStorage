using System.ComponentModel.DataAnnotations;

namespace cw_8_ko_xDejw.Models.Account
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
    }
}