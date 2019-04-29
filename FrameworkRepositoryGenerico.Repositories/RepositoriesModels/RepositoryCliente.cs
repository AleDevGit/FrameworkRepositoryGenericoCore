using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkRepositoryGenerico.Repository.Repositories;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FrameworkRepositoryGenerico.Repository.RepositoriesModels
{
   public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        private readonly MyCadastroContext _myCadastroContext;
        public RepositoryCliente(MyCadastroContext context) : base(context)
        {
            _myCadastroContext = context;

        }

        public Cliente GetCliente(int id)
        {

            var _cliente =  _myCadastroContext.Cliente
                .Include(x => x.TipoCliente)
                .Include(x=> x.Usuarios)
                .ThenInclude(x=> x.Contatos).ThenInclude(x => x.TipoContato);
            return MontaObjeto(_cliente);

        }

        private Cliente MontaObjeto(IIncludableQueryable<Cliente, TipoContato> cliente)
        {
            return cliente.Select(c => new Cliente
            {
                Id = c.Id,
                Cpf_Cnpj = c.Cpf_Cnpj,
                Nome = c.Nome,
                Enderecos = c.Enderecos,
         
                
            }).FirstOrDefault();
        }
        
    }
}
