using System;
using System.Collections.Generic;
using System.Linq;
using FrameworkRepositoryGenerico.Repository.Repositories;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrameworkRepositoryGenerico.Repository.RepositoriesModels
{
    public class RepositoryTelefone : Repository<Telefone>, IRepositoryTelefone
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryTelefone(MyCadastroContext context) : base(context)
        {
            _myCadastroContext = context;
        }


        public IQueryable<Telefone> GetAllIncludes(params Expression<Func<Telefone, object>>[] includeExpressions)
        {
            return includeExpressions.Aggregate<Expression<Func<Telefone, object>>, IQueryable<Telefone>>(_myCadastroContext.Telefone, (current, expression) => current.Include(expression));
        }


        public IEnumerable<Telefone> GetAllAndCliente()
        {
            return _myCadastroContext.Telefone
                .Include(x => x.TipoTelefone)
                .Include(x => x.Cliente)
                .Select(a => 
                new Telefone
                {
                    Id = a.Id,
                    Numero = a.Numero,
                    TipoTelefone = a.TipoTelefone,
                    Cliente = a.Cliente
                }).AsParallel().ToList();
        }
    }
}
