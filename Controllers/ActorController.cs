//using test.Contextapp;
using test.Models;
using test.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetAllFilmsAsync()
        {
            var filme = await _filmRepository.GetAll();
            return Ok(filme);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilmByIdAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmAsync(Film film)
        {
            await _filmRepository.AddAsync(film);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilmAsync(int id, Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest();
            }
            await _filmRepository.UpdateAsync(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            await _filmRepository.DeleteAsync(film);
            return NoContent();
        }
    }
}
