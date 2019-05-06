using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ClienteController(IRepositoryCliente repositoryCliente)
            => _repositoryCliente = repositoryCliente;


        public IActionResult GetAll()
        {
            try
            {
                var Cliente = _repositoryCliente.GetAll();
                return Ok(Cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Buscar Cliente por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = _repositoryCliente.GetCliente(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


    }
}