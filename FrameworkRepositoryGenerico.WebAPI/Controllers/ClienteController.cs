using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using System;
using FrameworkRepositoryGenerico.DataBase.Entidades;

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

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Cliente cliente)
        {
            try
            {
                Cliente _Cliente = new Cliente();

                if (cliente.Id > 0)
                {
                    _Cliente = _repositoryCliente.Get(cliente.Id);
                }
                else
                {
                    _Cliente = _repositoryCliente.Find(x => x.Cpf_Cnpj == cliente.Cpf_Cnpj);
                }

                if (_Cliente != null && cliente.Id > 0)
                {
                    _Cliente.Nome = cliente.Nome;
                    _Cliente.Cpf_Cnpj = cliente.Cpf_Cnpj;
                    _Cliente.TipoCliente = cliente.TipoCliente;
                    _Cliente.Ativo = cliente.Ativo;
                    _repositoryCliente.Update(_Cliente);
                    _repositoryCliente.Save();
                }
                else if (_Cliente == null && cliente.Id == 0)
                {
                    _repositoryCliente.Add(cliente);
                    _repositoryCliente.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + cliente.Nome + " Cadastrado.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


    }
}