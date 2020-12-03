using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountrys()
        {
            var service = await _countryService.GetCountrys();
            var response = new ApiResponse<IEnumerable<Country>>(service);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var service = await _countryService.GetCountry(id);
            var response = new ApiResponse<Country>(service);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Country country)
        {
            await _countryService.InsertCountry(country);
            var response = new ApiResponse<Country>(country);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Country country)
        {
            country.ContryId = id;
            var result = await _countryService.UpdateCountry(country);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _countryService.DeleteCountry(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}