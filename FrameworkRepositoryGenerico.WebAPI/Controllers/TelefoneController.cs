using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;


namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class TelefoneController : Controller
    {
        private readonly IRepositoryTelefone _repositoryTelefone;

        public TelefoneController(IRepositoryTelefone repository)
        {
            _repositoryTelefone = repository;
        }

        // http://localhost:<port>/api/telefone/{Id}
        [HttpGet("{id:int}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var telefone = _repositoryTelefone.Get(Id);
                return Ok(telefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var telefone = _repositoryTelefone.GetAllAndCliente();
                return Ok(telefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}