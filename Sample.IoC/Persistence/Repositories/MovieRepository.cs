using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.IoC.Domain.Entities;
using Sample.IoC.Domain.Repositories;
using Sample.IoC.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Sample.IoC.Persistence.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            return await _context.Movie.ToListAsync();
        }

       
        public async Task AddAsync(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            return await _context.Movie.FindAsync(id);
        }

        public void Update(Movie movie)
        {
            _context.Movie.Update(movie);
        }

        public void Remove(Movie movie)
        {
            _context.Movie.Remove(movie);
        }
    }
}
