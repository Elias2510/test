using test.Models;
using System.Drawing;

namespace test.Repositories
{
    public interface IActorRepository
    {
        public Task<IEnumerable<Actor>> GetAll();
        public Task<Actor> GetByIdAsync(int id);
        public Task AddAsync(Actor actor);
        public Task UpdateAsync(Actor actor);
        public Task DeleteAsync(Actor actor);

    }
}
