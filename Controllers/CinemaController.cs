using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using test.Models;


[Route("api/[controller]")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly Context _context;
   

    public CinemaController(Context context)
    {
        _context = context;
    }

    [HttpGet("actori")]
    public async Task<IActionResult> GetActori()
    {
        var profesori = await _context.Actori.ToListAsync();//le fac asincrone ca de ce nu
        return Ok(profesori);
    }

    [HttpGet("filme")]
    public async Task<IActionResult> GetFilme()
    {
        var materii = await _context.Filme.ToListAsync();
        return Ok(materii);
    }

    [HttpGet("actor-filme")]
    public async Task<IActionResult> GetActorFilme()
    {
        var actorFilme = await _context.FilmeActori.ToListAsync();
        return Ok(actorFilme);
    }


    [HttpPost("actor")]
    public async Task<IActionResult> AddActor(string nume)
    {
        var actor = new Actor { Nume = nume};
        _context.Actori.Add(actor);
        await _context.SaveChangesAsync();
        return Ok(actor);
    }

    [HttpPost("filme")]
    public async Task<IActionResult> AddMaterie(string nume, int oscaruri)
    {
        var film = new Film { Denumire = nume, Oscaruri = oscaruri };
        _context.Filme.Add(film);
        await _context.SaveChangesAsync();
        return Ok(film);
    }


    [HttpPost("asignare")]
    public async Task<IActionResult> AsignareMaterieProfesor(Actor_Film filmActor)
    {
        _context.FilmeActori.Add(filmActor);
        await _context.SaveChangesAsync();
        return Ok(filmActor);
    }
}