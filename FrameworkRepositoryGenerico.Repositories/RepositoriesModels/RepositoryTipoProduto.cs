using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repositories.Repositories;

namespace FrameworkRepositoryGenerico.Repositories.RepositoriesModels
{
    public class RepositoryTipoProduto : Repository<TipoProduto>, IRepositoryTipoProduto
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryTipoProduto(MyCadastroContext context) : base(context) =>
            _myCadastroContext = context;


        
    }
}
