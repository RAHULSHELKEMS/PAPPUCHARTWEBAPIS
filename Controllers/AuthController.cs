using Microsoft.AspNetCore.Mvc;
using PAPPUCHARTWEBAPIS.Data;
using PAPPUCHARTWEBAPIS.Models;


namespace PAPPUCHARTWEBAPIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            UserModel model)
        {
            var existingUser =
                _context.Users.FirstOrDefault(x =>
                    x.MobileNumber ==
                    model.MobileNumber);

            if (existingUser != null)
            {
                return BadRequest(
                    "Mobile already exists");
            }

            model.Active = true;

            model.DateJoined = DateTime.Now;

            _context.Users.Add(model);

            await _context.SaveChangesAsync();

            return Ok("Registration Success");
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(
            LoginModel model)
        {
            var user =
                _context.Users.FirstOrDefault(x =>
                    x.MobileNumber ==
                    model.MobileNumber &&
                    x.Password ==
                    model.Password);

            if (user == null)
            {
                return BadRequest(
                    "Invalid Login");
            }

            return Ok(user);
        }
    }

}
