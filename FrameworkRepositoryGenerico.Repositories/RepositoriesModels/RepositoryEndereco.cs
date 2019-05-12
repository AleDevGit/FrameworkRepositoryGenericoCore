using System.Linq;
using FrameworkRepositoryGenerico.DataBase.Contexto;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryEndereco : Repository<Endereco>, IRepositoryEndereco
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryEndereco(MyCadastroContext context) : base(context)
        {
            _myCadastroContext = context;

        }


       
    }
}
