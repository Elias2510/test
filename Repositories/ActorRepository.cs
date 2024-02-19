
using test.Models;

using Microsoft.EntityFrameworkCore;

namespace test.Repositories
{

    public class ActorRepository : IActorRepository
    {
        private readonly Context _context;

        public ActorRepository(Context Context)
        {
            this._context = Context;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _context.Actori.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actori.FindAsync(id);
        }

        public async Task AddAsync(Actor actor)
        {
            _context.Actori.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Actor actor)
        {
            _context.Actori.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}