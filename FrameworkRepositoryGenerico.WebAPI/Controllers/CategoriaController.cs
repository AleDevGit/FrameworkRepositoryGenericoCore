using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class CategoriaController : Controller
    {
        private readonly IRepositoryCategoria _repositoryCategoria;

        public CategoriaController(IRepositoryCategoria repositoryCategoria)
        {
            _repositoryCategoria = repositoryCategoria;
        }

        public IActionResult GetAll()
        {
            try
            {
                var Categoria = _repositoryCategoria.GetAll();
                return Ok(Categoria);
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
                var Categoria = _repositoryCategoria.Get(id);
                return Ok(Categoria);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Categoria categoria)
        {
            try
            {
                Categoria _Categoria = new Categoria();

                if (categoria.Id > 0)
                {
                    _Categoria = _repositoryCategoria.Get(categoria.Id);
                }
                else
                {
                    _Categoria = _repositoryCategoria.Find(x => x.Descricao == categoria.Descricao);
                }

                if (_Categoria != null && categoria.Id > 0)
                {
                    _Categoria.Descricao = categoria.Descricao;
                    _Categoria.Ativo = categoria.Ativo;
                    _repositoryCategoria.Update(_Categoria);
                    _repositoryCategoria.Save();
                }
                else if (_Categoria == null && categoria.Id == 0)
                {
                    _repositoryCategoria.Add(categoria);
                    _repositoryCategoria.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + categoria.Descricao + " Cadastrado.");
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
                var _Categoria = _repositoryCategoria.Get(id);

                if (_Categoria != null)
                {
                    _repositoryCategoria.Remove(_Categoria);
                    _repositoryCategoria.Save();
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