using FrameworkRepositoryGenerico.Repository.InterfaceRepositories;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels
{
    public interface IRepositoryTelefone : IRepository<Telefone>
    {
        IQueryable<Telefone> GetAllIncludes(params Expression<Func<Telefone, object>>[] includeExpressions);

        IEnumerable<Telefone> GetAllAndCliente();
    }
}
