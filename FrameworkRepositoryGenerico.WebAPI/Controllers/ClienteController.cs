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
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente RepositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente)
            => RepositoryCliente = repositoryCliente;

        [HttpGet("{id:int}")]
        public IActionResult GetCliente(int id) {
            var cliente = RepositoryCliente.Get(id);
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetClientes() 
            =>Ok(RepositoryCliente.GetAll());

        [HttpPost]
        public IActionResult AddCliente() {
            var cliente = new Cliente
            {
                Nome= "Camilla Norberto",
                Cpf ="133432555",
                Rg ="24242442"
            };
            RepositoryCliente.Add(cliente);
            RepositoryCliente.Save();

            return Created("", "Cliente criado com sucesso");
        }
        
    }
}