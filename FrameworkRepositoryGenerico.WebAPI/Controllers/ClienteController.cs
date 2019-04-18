using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using System;
using System.Linq;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente RepositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente)
            => RepositoryCliente = repositoryCliente;


        [HttpGet]
        public IActionResult Get() {
            try
            {

                //var queryProdutos = RepositoryCliente.GetAll().SelectMany(p => p.Itens.Select(i => i.Produto));

                //var queryProdutos = cliente.Pedidos.SelectMany(p => p.Itens.Select(i => i.Produto));

                // var clientes = RepositoryCliente.GetAllIncludes(x=> x.Telefone.SelectMany(p => p.TipoTelefone));
                //return Ok(clientes);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = RepositoryCliente.Get(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [Route("GetPorTelefone/{Telefone}")]
        public IActionResult GetPorTelefone(string Telefone)
        {
            try
            {
                var clientes = RepositoryCliente.GetAll(x => x.Endereco);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}