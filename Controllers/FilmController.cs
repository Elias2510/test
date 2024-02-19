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
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAllActorsAsync()
        {
            var actori = await _actorRepository.GetAll();
            return Ok(actori);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActorByIdAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActorAsync(Actor actor)
        {
            await _actorRepository.AddAsync(actor);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActorAsync(int id, Actor actor)
        {
            if (id != actor.ActorId)
            {
                return BadRequest();
            }
            await _actorRepository.UpdateAsync(actor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActorAsync(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            await _actorRepository.DeleteAsync(actor);
            return NoContent();
        }
    }
}
