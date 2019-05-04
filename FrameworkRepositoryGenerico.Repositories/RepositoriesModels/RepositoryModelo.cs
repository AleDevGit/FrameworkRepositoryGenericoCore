using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryModelo : Repository<Modelo>, IRepositoryModelo
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryModelo(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
