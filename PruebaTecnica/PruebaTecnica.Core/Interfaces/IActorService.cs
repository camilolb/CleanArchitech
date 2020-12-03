

namespace PruebaTecnica.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PruebaTecnica.Core.Entities;

    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetActors();
        Task<Actor> GetActor(int id);
        Task InsertActor(Actor actor);
        Task<bool> UpdateActor(Actor actor);
        Task<bool> DeleteActor(int id);

    }
}
