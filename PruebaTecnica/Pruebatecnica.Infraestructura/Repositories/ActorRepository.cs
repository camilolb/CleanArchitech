using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DatabaseContext _dbContext;

        public ActorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteActor(int id)
        {
            var current = await GetActor(id);
            _dbContext.Actor.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Actor> GetActor(int id)
        {
            var result = await _dbContext.Actor.FirstOrDefaultAsync(x => x.ActorId == id);
            return result;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            var result = await _dbContext.Actor.ToListAsync();
            return result;
        }

        public async Task InsertActor(Actor actor)
        {
            _dbContext.Actor.Add(actor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateActor(Actor actor)
        {
            var current = await GetActor(actor.ActorId);

            current.Name = actor.Name;
            current.CountryId = actor.CountryId;
            current.LastName = actor.LastName;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
