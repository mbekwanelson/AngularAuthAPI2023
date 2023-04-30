using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext _authContext;

        
        public UserController(AppDbContext appDbContext) 
        {
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObject) 
        {
            if (userObject == null)
                return BadRequest();

            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObject.UserName);
            if(user == null)
                return NotFound(new {Message = "User Not Found!"});

            var userPassword = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObject.UserName && x.Password == userObject.Password);
            if(userPassword == null)
                 return NotFound(new { Message = "Incorrect Password" });

            return Ok(new
            {
                Message = "Login Successful"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userObject)
        {
            if (userObject == null)
                return BadRequest();

            var existingUser = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObject.UserName && x.Password == userObject.Password);
            if(existingUser != null)
                return NotFound(new { Message = "Pre Existing User" });

            await _authContext.Users.AddAsync(userObject);
            await _authContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Registration Successful"
            });
        }
    }
}
