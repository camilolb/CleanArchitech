

namespace PruebaTecnica.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PruebaTecnica.Api.Responses;
    using PruebaTecnica.Core.Entities;
    using PruebaTecnica.Core.Interfaces;


    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GenderController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var post = await _genderService.GetGenders();
            var response = new ApiResponse<IEnumerable<Gender>>(post);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGender(int id)
        {
            var post = await _genderService.GetGender(id);
            var response = new ApiResponse<Gender>(post);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Gender gender)
        {
            await _genderService.InsertGender(gender);
            var response = new ApiResponse<Gender>(gender);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Gender gender)
        {
            gender.GenderId = id;

            var result = await _genderService.UpdateGender(gender);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _genderService.DeleteGender(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}