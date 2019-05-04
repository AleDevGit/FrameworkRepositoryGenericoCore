using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryFabricante : Repository<Fabricante>, IRepositoryFabricante
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryFabricante(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
