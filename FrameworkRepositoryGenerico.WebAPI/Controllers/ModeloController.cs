using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class ModeloController : Controller
    {
        private readonly IRepositoryModelo _repositoryModelo;

        public ModeloController(IRepositoryModelo repositoryModelo)
        {
            _repositoryModelo = repositoryModelo;
        }

        public IActionResult GetAll()
        {
            try
            {
                var Modelo = _repositoryModelo.GetAll();
                return Ok(Modelo);
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
                var Modelo = _repositoryModelo.Get(id);
                return Ok(Modelo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Modelo modelo)
        {
            try
            {
                Modelo _Modelo = new Modelo();

                if (modelo.Id > 0)
                {
                    _Modelo = _repositoryModelo.Get(modelo.Id);
                }
                else
                {
                    _Modelo = _repositoryModelo.Find(x => x.Descricao == modelo.Descricao);
                }

                if (_Modelo != null && modelo.Id > 0)
                {
                    _Modelo.Descricao = modelo.Descricao;
                    _Modelo.Ativo = modelo.Ativo;
                    _repositoryModelo.Update(_Modelo);
                    _repositoryModelo.Save();
                }
                else if (_Modelo == null && modelo.Id == 0)
                {
                    _repositoryModelo.Add(modelo);
                    _repositoryModelo.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + modelo.Descricao + " Cadastrado.");
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
                var _Modelo = _repositoryModelo.Get(id);

                if (_Modelo != null)
                {
                    _repositoryModelo.Remove(_Modelo);
                    _repositoryModelo.Save();
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