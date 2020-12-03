using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Responses;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var post = await _movieService.GetMovies();
            var response = new ApiResponse<IEnumerable<Movie>>(post);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var post = await _movieService.GetMovie(id);
            var response = new ApiResponse<Movie>(post);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            await _movieService.InsertMovie(movie);
            var response = new ApiResponse<Movie>(movie);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Movie movie)
        {
            movie.MovieId = id;

            var result = await _movieService.UpdateMovie(movie);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.DeleteMovie(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
