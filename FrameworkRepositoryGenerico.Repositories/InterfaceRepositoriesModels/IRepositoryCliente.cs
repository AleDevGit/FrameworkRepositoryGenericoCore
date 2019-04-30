using FrameworkRepositoryGenerico.Repositories.InterfaceRepositories;
using FrameworkRepositoryGenerico.DataBase.Entidades;

namespace FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Cliente GetCliente(int id);
    }
}
