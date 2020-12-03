using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;

namespace PruebaTecnica.Core.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender> GetGender(int id);
        Task InsertGender(Gender gender);
        Task<bool> UpdateGender(Gender gender);
        Task<bool> DeleteGender(int id);
    }
}
