using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryTipoContato : Repository<TipoContato>, IRepositoryTipoContato
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryTipoContato(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
