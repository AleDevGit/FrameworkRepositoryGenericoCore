using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class RegraController : Controller
    {
        private readonly IRepositoryRegra _repositoryRegra;

        public RegraController(IRepositoryRegra repositoryRegra)
        {
            _repositoryRegra = repositoryRegra;
        }

        public IActionResult GetAll()
        {
            try
            {
                var Regra = _repositoryRegra.GetAll();
                return Ok(Regra);
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
                var Regra = _repositoryRegra.Get(id);
                return Ok(Regra);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Regra regra)
        {
            try
            {
                Regra _Regra = new Regra();

                if (regra.Id > 0)
                {
                    _Regra = _repositoryRegra.Get(regra.Id);
                }
                else
                {
                    _Regra = _repositoryRegra.Find(x => x.Descricao == regra.Descricao);
                }

                if (_Regra != null && regra.Id > 0)
                {
                    _Regra.Descricao = regra.Descricao;
                    _Regra.Ativo = regra.Ativo;
                    _repositoryRegra.Update(_Regra);
                    _repositoryRegra.Save();
                }
                else if (_Regra == null && regra.Id == 0)
                {
                    _repositoryRegra.Add(regra);
                    _repositoryRegra.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + regra.Descricao + " Cadastrado.");
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
                var _Regra = _repositoryRegra.Get(id);

                if (_Regra != null)
                {
                    _repositoryRegra.Remove(_Regra);
                    _repositoryRegra.Save();
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