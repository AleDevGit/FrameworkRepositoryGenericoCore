using FrameworkRepositoryGenerico.DataBase.Contexto;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryCategoria : Repository<Categoria>, IRepositoryCategoria
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryCategoria(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
