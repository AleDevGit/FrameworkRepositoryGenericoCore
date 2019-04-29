using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositories;
using FrameworkRepositoryGenerico.DataBase.Entidades;

namespace FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Cliente GetCliente(int id);
    }
}
