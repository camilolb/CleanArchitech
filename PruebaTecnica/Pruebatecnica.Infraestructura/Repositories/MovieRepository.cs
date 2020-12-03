using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DatabaseContext _dbContext;

        public MovieRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var current = await GetMovie(id);
            _dbContext.Movie.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var result = await _dbContext.Movie.FirstOrDefaultAsync(x => x.MovieId == id);
            return result;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var result = await _dbContext.Movie.Include(x => x.Gender).Include(j => j.Actor).Include(i => i.Country).ToListAsync();
            return result;
        }

        public async Task InsertMovie(Movie movie)
        {
            _dbContext.Movie.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var current = await GetMovie(movie.MovieId);

            current.Title = movie.Title;
            current.CountryId = movie.CountryId;
            current.Description = movie.Description;

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
