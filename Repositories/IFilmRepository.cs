using test.Models;
using System.Drawing;

namespace test.Repositories
{
    public interface IFilmRepository
    {
        public Task<IEnumerable<Film>> GetAll();
        public Task<Film> GetByIdAsync(int id);
        public Task AddAsync(Film film);
        public Task UpdateAsync(Film film);
        public Task DeleteAsync(Film film);

    }
}

