using System.Threading.Tasks;

namespace Sample.IoC.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
