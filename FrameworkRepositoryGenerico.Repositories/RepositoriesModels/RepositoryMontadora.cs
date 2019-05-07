using FrameworkRepositoryGenerico.DataBase.Contexto;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryMontadora : Repository<Montadora>, IRepositoryMontadora
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryMontadora(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
