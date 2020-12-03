

namespace PruebaTecnica.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PruebaTecnica.Core.Entities;
    using PruebaTecnica.Core.Interfaces;

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            return await _countryRepository.DeleteCountry(id);
        }

        public async Task<Country> GetCountry(int id)
        {
            return await _countryRepository.GetCountry(id);
        }

        public async Task<IEnumerable<Country>> GetCountrys()
        {
            return await _countryRepository.GetCountrys();
        }

        public async Task InsertCountry(Country country)
        {
            await _countryRepository.InsertCountry(country);
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            return  await _countryRepository.UpdateCountry(country);
        }
    }
}
