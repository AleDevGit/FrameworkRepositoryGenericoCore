using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkRepositoryGenerico.Repository.Repositories;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;

namespace FrameworkRepositoryGenerico.Repository.RepositoriesModels
{
   public class RepositoryTipoTelefone : Repository<TipoTelefone>, IRepositoryTipoTelefone
    {
        public RepositoryTipoTelefone(MyCadastroContext context) : base(context)
        {

        }
    }
}
