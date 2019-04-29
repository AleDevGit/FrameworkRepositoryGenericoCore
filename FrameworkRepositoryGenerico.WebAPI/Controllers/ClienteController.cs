using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.DataBase.Entidades;
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



        /// <summary>
        /// Buscar Cliente por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = RepositoryCliente.GetCliente(id);
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
                var clientes = RepositoryCliente.GetAll(x => x.Enderecos);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}