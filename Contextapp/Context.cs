using Microsoft.EntityFrameworkCore;
using test.Models;
using test.Repositories;

public class Context : DbContext
{

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public DbSet<Actor> Actori { get; set; }
    public DbSet<Film> Filme { get; set; }
    public DbSet<Actor_Film> FilmeActori { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)//pun cheia primara pentru Actor_Film
    {
        modelBuilder.Entity<Actor_Film>()
            .HasKey(mp => new { mp.FilmId, mp.ActorId });
       
    }
}