namespace PruebaTecnica.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PruebaTecnica.Core.Entities;

    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountrys();
        Task<Country> GetCountry(int id);
        Task InsertCountry(Country country);
        Task<bool> UpdateCountry(Country country);
        Task<bool> DeleteCountry(int id);
    }
}
