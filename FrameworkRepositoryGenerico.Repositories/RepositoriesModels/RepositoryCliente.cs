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
   public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryCliente(MyCadastroContext context) : base(context)
        {
            _myCadastroContext = context;

        }

        public IEnumerable<Cliente> GetClientes()
        {

            //var queryProdutos = cliente.Pedidos.SelectMany(p => p.Itens.Select(i => i.Produto));



            return _myCadastroContext.Cliente.SelectMany(p => p.Telefone.Select(i => i.Cliente)).ToList();


        }
    }
}
