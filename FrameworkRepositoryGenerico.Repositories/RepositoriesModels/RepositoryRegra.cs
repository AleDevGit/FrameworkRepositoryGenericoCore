using FrameworkRepositoryGenerico.DataBase.Contexto;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryRegra : Repository<Regra>, IRepositoryRegra
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryRegra(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
