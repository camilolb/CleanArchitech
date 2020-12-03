using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Core.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<bool> DeleteGender(int id)
        {
            return await _genderRepository.DeleteGender(id);
        }

        public async Task<Gender> GetGender(int id)
        {
            return await _genderRepository.GetGender(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await _genderRepository.GetGenders();
        }

        public async Task InsertGender(Gender gender)
        {
            await _genderRepository.InsertGender(gender);
        }

        public async Task<bool> UpdateGender(Gender gender)
        {
            return await _genderRepository.UpdateGender(gender);
        }
    }
}
