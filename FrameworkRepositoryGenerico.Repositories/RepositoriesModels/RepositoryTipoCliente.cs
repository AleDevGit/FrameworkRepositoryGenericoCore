using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryTipoCliente : Repository<TipoCliente>, IRepositoryTipoCliente
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryTipoCliente(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
