using FrameworkRepositoryGenerico.Repository.Repositories;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;

namespace FrameworkRepositoryGenerico.Repository.RepositoriesModels
{
    public class RepositoryEndereco : Repository<Endereco>, IRepositoryEndereco
    {
        public RepositoryEndereco(MyCadastroContext context) : base(context)
        {

        }
    }
}
