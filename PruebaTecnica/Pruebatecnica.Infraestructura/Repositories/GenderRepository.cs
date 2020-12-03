using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly DatabaseContext _dbContext;

        public GenderRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteGender(int id)
        {
            var currentGender = await GetGender(id);
            _dbContext.Gender.Remove(currentGender);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Gender> GetGender(int id)
        {
            var gender = await _dbContext.Gender.FirstOrDefaultAsync(x => x.GenderId == id);
            return gender;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var genders = await _dbContext.Gender.ToListAsync();
            return genders;
        }

        public async Task InsertGender(Gender gender)
        {
            _dbContext.Gender.Add(gender);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateGender(Gender gender)
        {
            var currentGender = await GetGender(gender.GenderId);
            currentGender.Name = gender.Name;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
