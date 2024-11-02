using _2301B2WebApi.Data;
using _2301B2WebApi.Models.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2301B2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PharmacyContext _context;
        public LoginController(PharmacyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO userdata)
        {
            if (userdata == null)
            {
                return BadRequest();
            }
            else
            {
                var check = _context.Users.FirstOrDefault(u => u.Email == userdata.Email);
                if (check != null)
                {
                    var hasher = new PasswordHasher<string>();
                    var result = hasher.VerifyHashedPassword(userdata.Email, check.Password, userdata.Password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        return Ok("Login Success");
                    }
                    else
                    {
                        return Unauthorized("Invalid Credentials");
                    }
                }
                else
                {
                    return BadRequest("User not found");
                }
            }
        }
    }
}
