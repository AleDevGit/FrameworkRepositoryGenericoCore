using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repository.RepositoriesModels;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/Clientes/")]
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente)
            => _repositoryCliente = repositoryCliente;
        
        [HttpGet]
        public IEnumerable<Cliente> Get() {

            string includes = "Telefone";
            var clientes = _repositoryCliente.GetAll(includes);
            return clientes;
        }

        // http://localhost:<port>/api/Cliente/?Id={Id}
        // http://localhost:<port>/api/Cliente/?Cpf={Cpf}
        [HttpGet("/api/Cliente/")]
        public IActionResult Get(Cliente queryModel)
        {
            List<Cliente> Cliente = new List<Cliente>();
            if (queryModel.Id != 0)
            {
                
                Cliente = _repositoryCliente.Find(x => x.Id == queryModel.Id).ToList();
            }
            else {
                if (!string.IsNullOrEmpty(queryModel.Cpf))
                {
                    Cliente = _repositoryCliente.Find(x => x.Cpf == queryModel.Cpf).ToList();
                }
            }

            return Ok(Cliente);
        }


    

        //[HttpPost]
        //public IActionResult AddCliente()
        //{
        //    var cliente = new Cliente
        //    {
        //        Nome = "Camilla Norberto",
        //        Cpf = "133432555",
        //        Rg = "24242442"
        //    };
        //    RepositoryCliente.Add(cliente);
        //    RepositoryCliente.Save();

        //    return Created("", "Cliente criado com sucesso");
        //}



    }
}