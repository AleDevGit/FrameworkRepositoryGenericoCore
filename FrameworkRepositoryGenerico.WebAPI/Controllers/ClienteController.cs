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
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositoryCliente RepositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente)
            => RepositoryCliente = repositoryCliente;


        [HttpGet]
        public IEnumerable<Cliente> Get() {
            var clientes = RepositoryCliente.GetAll();
            return clientes;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = RepositoryCliente.Get(id);
            return Ok(cliente);
        }




        //
        //
        //
        //
        //
        //

        ////[HttpGet]
        ////public IActionResult GetClientes()
        ////    => Ok(RepositoryCliente.GetAll());

        //[HttpGet("/getclienteall")]
        //public IActionResult GetClienteAll() 
        //    => Ok(RepositoryCliente.GetAll());


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