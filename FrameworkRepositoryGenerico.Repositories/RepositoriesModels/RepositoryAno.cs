using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryAno : Repository<Ano>, IRepositoryAno
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryAno(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
