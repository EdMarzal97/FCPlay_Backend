using Microsoft.AspNetCore.Mvc;
using FCPlay.Models;
using FCPlay.Data;

namespace FCPlay.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase{
        private readonly AppDbContext _context;

        public MatchesController(AppDbContext context){
            _context = context;
        }

        // GET: api/Matches
        [HttpGet]
        public IActionResult GetMatches()
        {
            var matches = _context.Matches.ToList();
            return Ok(matches);
        }

        // GET: api/Matches/{id}
        [HttpGet("{id}")]
        public IActionResult GetMatch(int id)
        {
            var match = _context.Matches.Find(id);
            if (match == null) return NotFound();
            return Ok(match);
        }

        // POST: api/Matches
        [HttpPost]
        public IActionResult CreateMatch([FromBody] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Matches.Add(match);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Matches/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMatch(int id, [FromBody] Match updatedMatch)
        {
            var match = _context.Matches.Find(id);
            if (match == null) return NotFound();

            match.TeamLocal = updatedMatch.TeamLocal;
            match.TeamAway = updatedMatch.TeamAway;
            match.MatchDate = updatedMatch.MatchDate;
            match.ScoreLocal = updatedMatch.ScoreLocal;
            match.ScoreAway = updatedMatch.ScoreAway;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Matches/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMatch(int id)
        {
            var match = _context.Matches.Find(id);
            if (match == null) return NotFound();

            _context.Matches.Remove(match);
            _context.SaveChanges();
            return NoContent();
        }
    }
}