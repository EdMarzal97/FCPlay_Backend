using Microsoft.AspNetCore.Mvc;
using FCPlay.Models;
using FCPlay.Data;

namespace FCPlay.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context){
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers() {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}