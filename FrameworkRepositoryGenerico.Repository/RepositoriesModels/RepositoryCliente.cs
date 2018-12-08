using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkRepositoryGenerico.Repository.Repositories;
using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;

namespace FrameworkRepositoryGenerico.Repository.RepositoriesModels
{
   public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(MyCadastroContext context) : base(context)
        {

        }
    }
}
