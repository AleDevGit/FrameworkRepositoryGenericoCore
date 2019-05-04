using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{

    [Route("api/[Controller]")]
    public class TipoClienteController : Controller
    {

        private readonly IRepositoryTipoCliente _repositoryTipoCliente;

        public TipoClienteController(IRepositoryTipoCliente repositoryTipoCliente)
        {
            _repositoryTipoCliente = repositoryTipoCliente;
        }

        public IActionResult GetAll() {
            try
            {
                var TipoCliente = _repositoryTipoCliente.GetAll();
                return Ok(TipoCliente);
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
                var TipoCliente = _repositoryTipoCliente.Get(id);
                return Ok(TipoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] TipoCliente tipoCliente) {
            try
            {
                TipoCliente _TipoCliente = new TipoCliente();

                if (tipoCliente.Id > 0)
                {
                    _TipoCliente = _repositoryTipoCliente.Get(tipoCliente.Id);
                }
                else {
                    _TipoCliente = _repositoryTipoCliente.Find(x => x.Descricao == tipoCliente.Descricao);
                }

                if (_TipoCliente != null && tipoCliente.Id > 0)
                {
                    _TipoCliente.Descricao = tipoCliente.Descricao;
                    _TipoCliente.Ativo = tipoCliente.Ativo;
                    _repositoryTipoCliente.Update(_TipoCliente);
                    _repositoryTipoCliente.Save();
                }
                else if (_TipoCliente == null && tipoCliente.Id == 0 ) {
                    _repositoryTipoCliente.Add(tipoCliente);
                    _repositoryTipoCliente.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + tipoCliente.Descricao + " Cadastrado.");
                }
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var _TipoCliente = _repositoryTipoCliente.Get(id);

                if (_TipoCliente != null)
                {
                    _repositoryTipoCliente.Remove(_TipoCliente);
                    _repositoryTipoCliente.Save();
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