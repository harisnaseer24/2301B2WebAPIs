using _2301B2WebApi.Data;
using _2301B2WebApi.Models;
using _2301B2WebApi.Models.DTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2301B2WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PharmacyContext _context;
        public UserController(PharmacyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Users()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult Signup(UserDTO userdata)
        {
            var check= _context.Users.FirstOrDefault(u=> u.Email == userdata.Email);
            if (check != null) {
                return BadRequest("User already exists");
            }
            else
            {
                var hasher = new PasswordHasher<string>();
                var hashPass = hasher.HashPassword(userdata.Email,userdata.Password);
                //Object mapping
                // mapping domain model from DTO model
                User newuser = new User()
                {
                    Username = userdata.Username,
                    Email = userdata.Email,
                    Password = hashPass,
                    RoleId = userdata.RoleId,
                };
                var addedUser = _context.Users.Add(newuser);
                _context.SaveChanges();
            return Ok(addedUser.Entity);
            }
        }
    }
}
