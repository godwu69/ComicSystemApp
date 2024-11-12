using ComicSystem.Data;
using ComicSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComicSystem.Controllers{
    [ApiController]
    [Route("api/comic")]
    public class ComicController : ControllerBase{
        private readonly ComicContext _context;

        public ComicController(ComicContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetAllComics()
        {
            var comics = _context.ComicBooks.ToList();
            return Ok(new {message = "Successfully", data = comics});
        }

        [HttpGet("{id}")]
        public IActionResult GetComicById(int id)
        {
            var comic = _context.ComicBooks.Find(id);
            if (comic == null)
                return NotFound();
            return Ok(new {message = "Successfully", data = comic});
        }

        [HttpPost("")]
        public IActionResult CreateComic([FromBody] ComicBooks comic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ComicBooks.Add(comic);
            _context.SaveChanges();
            return Ok(new {message = "Created Successfully", data = comic});
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComic(int id, [FromBody] ComicBooks comic)
        {
            if (id != comic.ComicBookId)
                return BadRequest();

            var existingComic = _context.ComicBooks.Find(id);
            if (existingComic == null)
                return NotFound();

            existingComic.Title = comic.Title;
            existingComic.Author = comic.Author;
            existingComic.PricePerDay = comic.PricePerDay;

            _context.ComicBooks.Update(existingComic);
            _context.SaveChanges();
            return Ok(new {message = "Updated Successfully"});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComic(int id)
        {
            var comic = _context.ComicBooks.Find(id);
            if (comic == null)
                return NotFound();

            _context.ComicBooks.Remove(comic);
            _context.SaveChanges();
            return Ok(new {message = "Deleted Successfully"});
        }

    }
}