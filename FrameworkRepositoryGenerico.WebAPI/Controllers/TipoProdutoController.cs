using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{

    [Route("api/[Controller]")]
    public class TipoProdutoController : Controller
    {

        private readonly IRepositoryTipoProduto _repositoryTipoProduto;

        public TipoProdutoController(IRepositoryTipoProduto repositoryTipoProduto)
        {
            _repositoryTipoProduto = repositoryTipoProduto;
        }

        public IActionResult GetAll() {
            try
            {
                var TipoProduto = _repositoryTipoProduto.GetAll();
                return Ok(TipoProduto);
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
                var TipoProduto = _repositoryTipoProduto.Get(id);
                return Ok(TipoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] TipoProduto tipoProduto) {
            try
            {
                TipoProduto _TipoProduto = new TipoProduto();

                if (tipoProduto.Id > 0)
                {
                    _TipoProduto = _repositoryTipoProduto.Get(tipoProduto.Id);
                }
                else {
                    _TipoProduto = _repositoryTipoProduto.Find(x => x.Descricao == tipoProduto.Descricao);
                }

                if (_TipoProduto != null && tipoProduto.Id > 0)
                {
                    _TipoProduto.Descricao = tipoProduto.Descricao;
                    _TipoProduto.Ativo = tipoProduto.Ativo;
                    _repositoryTipoProduto.Update(_TipoProduto);
                    _repositoryTipoProduto.Save();
                }
                else if (_TipoProduto == null && tipoProduto.Id == 0 ) {
                    _repositoryTipoProduto.Add(tipoProduto);
                    _repositoryTipoProduto.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + tipoProduto.Descricao + " Cadastrado.");
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
                var _TipoProduto = _repositoryTipoProduto.Get(id);

                if (_TipoProduto != null)
                {
                    _repositoryTipoProduto.Remove(_TipoProduto);
                    _repositoryTipoProduto.Save();
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