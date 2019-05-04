using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{

    [Route("api/[Controller]")]
    public class TipoContatoController : Controller
    {

        private readonly IRepositoryTipoContato _repositoryTipoContato;

        public TipoContatoController(IRepositoryTipoContato repositoryTipoContato)
        {
            _repositoryTipoContato = repositoryTipoContato;
        }

        public IActionResult GetAll() {
            try
            {
                var TipoContato = _repositoryTipoContato.GetAll();
                return Ok(TipoContato);
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
                var TipoContato = _repositoryTipoContato.Get(id);
                return Ok(TipoContato);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] TipoContato tipoContato) {
            try
            {
                TipoContato _TipoContato = new TipoContato();

                if (tipoContato.Id > 0)
                {
                    _TipoContato = _repositoryTipoContato.Get(tipoContato.Id);
                }
                else {
                    _TipoContato = _repositoryTipoContato.Find(x => x.Descricao == tipoContato.Descricao);
                }

                if (_TipoContato != null && tipoContato.Id > 0)
                {
                    _TipoContato.Descricao = tipoContato.Descricao;
                    _TipoContato.Ativo = tipoContato.Ativo;
                    _repositoryTipoContato.Update(_TipoContato);
                    _repositoryTipoContato.Save();
                }
                else if (_TipoContato == null && tipoContato.Id == 0 ) {
                    _repositoryTipoContato.Add(tipoContato);
                    _repositoryTipoContato.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + tipoContato.Descricao + " Cadastrado.");
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
                var _TipoContato = _repositoryTipoContato.Get(id);

                if (_TipoContato != null)
                {
                    _repositoryTipoContato.Remove(_TipoContato);
                    _repositoryTipoContato.Save();
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