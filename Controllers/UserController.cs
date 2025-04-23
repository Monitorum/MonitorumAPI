using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitorumAPI.DTO;
using MonitorumAPI.Models;

namespace MonitorumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        private readonly AppDbContext _context;





        [HttpGet]
        public async Task<IActionResult> Index()
        {
            User user = new User { Id = 3, Name = "Brujah", Role = Roles.Admin };

            var canConnect = await _context.Database.CanConnectAsync();

            var users = await _context.Users.ToListAsync();



            if (canConnect)
            {
                return Ok(users);
            }
            
            string jsonString = JsonSerializer.Serialize(user);
            return Content(jsonString);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            User user = new User { Id = 2, Name = userDto.Name, Role = Roles.Admin };
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);
        }
    }
}
