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

        Task<MovieResponse> GetMovie(int id);

        Task<MovieResponse> SaveAsync(Movie movie);

        Task<MovieResponse> UpdateAsync(int id, Movie movie);

        Task<MovieResponse> DeleteAsync(int id);
    }
}
