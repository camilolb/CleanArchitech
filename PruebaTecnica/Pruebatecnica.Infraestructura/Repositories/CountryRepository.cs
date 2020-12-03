using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class CountryRepository : ICountryRepository
    {

        private readonly DatabaseContext _dbContext;

        public CountryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var current = await GetCountry(id);
            _dbContext.Country.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Country> GetCountry(int id)
        {
            var country = await _dbContext.Country.FirstOrDefaultAsync(x => x.ContryId == id);
            return country;
        }

        public async Task<IEnumerable<Country>> GetCountrys()
        {
            var countries = await _dbContext.Country.ToListAsync();
            return countries;
        }

        public async Task InsertCountry(Country country)
        {
            _dbContext.Country.Add(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            var current = await GetCountry(country.ContryId);
            current.Name = country.Name;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
