using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.IoC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Sample.IoC.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> ListAsync();
        Task<ActionResult<Movie>> GetMovie(int id);

        Task AddAsync(Movie movie);
        public bool MovieExists(int id);
    }
}
