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
    public class ActorController : ControllerBase
    {

        private readonly IActorService _actorService;

        public ActorController(IActorService actorService) {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActors()
        {
            var service = await _actorService.GetActors();
            var response = new ApiResponse<IEnumerable<Actor>>(service);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            var service = await _actorService.GetActor(id);
            var response = new ApiResponse<Actor>(service);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Actor actor)
        {
            await _actorService.InsertActor(actor);
            var response = new ApiResponse<Actor>(actor);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Actor actor)
        {
            actor.ActorId = id;
            var result = await _actorService.UpdateActor(actor);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _actorService.DeleteActor(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}