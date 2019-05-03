using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{

    [Route("api/[Controller]")]
    public class AnoController : Controller
    {

        private readonly IRepositoryAno _repositoryAno;

        public AnoController(IRepositoryAno repositoryAno)
        {
            _repositoryAno = repositoryAno;
        }

        public IActionResult GetAll() {
            try
            {
                var Ano = _repositoryAno.GetAll();
                return Ok(Ano);
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
                var Ano = _repositoryAno.Get(id);
                return Ok(Ano);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Ano ano) {
            try
            {
                Ano _Ano = new Ano();

                if (ano.Id > 0)
                {
                    _Ano = _repositoryAno.Get(ano.Id);
                }
                else {
                    _Ano = _repositoryAno.Find(x => x.Descricao == ano.Descricao);
                }

                if (_Ano != null && ano.Id > 0)
                {
                    _Ano.Descricao = ano.Descricao;
                    _Ano.Ativo = ano.Ativo;
                    _repositoryAno.Update(_Ano);
                    _repositoryAno.Save();
                }
                else if (_Ano == null && ano.Id == 0 ) {
                    _repositoryAno.Add(ano);
                    _repositoryAno.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + ano.Descricao + " Cadastrado.");
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
                var _Ano = _repositoryAno.Get(id);

                if (_Ano != null)
                {
                    _repositoryAno.Remove(_Ano);
                    _repositoryAno.Save();
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