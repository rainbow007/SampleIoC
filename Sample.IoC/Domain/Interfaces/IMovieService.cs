using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.IoC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Sample.IoC.Domain.Services.Communication;

namespace Sample.IoC.Domain.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> ListAsync();

        Task<ActionResult<Movie>> GetMovie(int id);

        Task<SaveMovieResponse> SaveAsync(Movie movie);

        public bool MovieExists(int id);
    }
}
