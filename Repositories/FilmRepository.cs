
using test.Models;

using Microsoft.EntityFrameworkCore;

namespace test.Repositories
{

    public class FilmRepository : IFilmRepository
    {
        private readonly Context _context;

        public FilmRepository(Context Context)
        {
            this._context = Context;
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _context.Filme.ToListAsync();
        }

        public async Task<Film> GetByIdAsync(int id)
        {
            return await _context.Filme.FindAsync(id);
        }

        public async Task AddAsync(Film film)
        {
            _context.Filme.Add(film);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Film film)
        {
            _context.Entry(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Film film)
        {
            _context.Filme.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}