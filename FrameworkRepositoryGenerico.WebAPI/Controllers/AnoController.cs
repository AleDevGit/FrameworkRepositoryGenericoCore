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
                var _Ano = _repositoryAno.Find(x => x.Descricao == ano.Descricao);
                var Msg = "";
                if (_Ano != null)
                {
                    _Ano.Descricao = ano.Descricao;
                    _Ano.Ativo = ano.Ativo;
                    _repositoryAno.Update(_Ano);
                    Msg = "Cadastro atualizado com sucesso.";
                }
                else {
                    _repositoryAno.Add(ano);
                    Msg = "Cadastro realizado com sucesso.";
                }
                _repositoryAno.Save();
                return Ok(Msg);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var _Ano = _repositoryAno.Get(id);

                if (_Ano != null)
                {
                    _repositoryAno.Remove(_Ano);
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