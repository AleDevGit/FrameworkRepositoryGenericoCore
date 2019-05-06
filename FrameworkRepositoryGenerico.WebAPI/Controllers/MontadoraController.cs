using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class MontadoraController : Controller
    {
        private readonly IRepositoryMontadora _repositoryMontadora;

        public MontadoraController(IRepositoryMontadora repositoryMontadora)
        {
            _repositoryMontadora = repositoryMontadora;
        }

        public IActionResult GetAll()
        {
            try
            {
                var Montadora = _repositoryMontadora.GetAll();
                return Ok(Montadora);
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
                var Montadora = _repositoryMontadora.Get(id);
                return Ok(Montadora);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Montadora montadora)
        {
            try
            {
                Montadora _Montadora = new Montadora();

                if (montadora.Id > 0)
                {
                    _Montadora = _repositoryMontadora.Get(montadora.Id);
                }
                else
                {
                    _Montadora = _repositoryMontadora.Find(x => x.Descricao == montadora.Descricao);
                }

                if (_Montadora != null && montadora.Id > 0)
                {
                    _Montadora.Descricao = montadora.Descricao;
                    _Montadora.Ativo = montadora.Ativo;
                    _repositoryMontadora.Update(_Montadora);
                    _repositoryMontadora.Save();
                }
                else if (_Montadora == null && montadora.Id == 0)
                {
                    _repositoryMontadora.Add(montadora);
                    _repositoryMontadora.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + montadora.Descricao + " Cadastrado.");
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
                var _Montadora = _repositoryMontadora.Get(id);

                if (_Montadora != null)
                {
                    _repositoryMontadora.Remove(_Montadora);
                    _repositoryMontadora.Save();
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