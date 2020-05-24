using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.IoC.Domain.Entities;


namespace Sample.IoC.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> ListAsync();

        Task AddAsync(Movie movie);

        Task<Movie> FindByIdAsync(int id);

        void Update(Movie movie);

        void Remove(Movie movie);

    }
}
