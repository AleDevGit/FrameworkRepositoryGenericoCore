using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{

    [Route("api/[Controller]")]
    public class FabricanteController : Controller
    {

        private readonly IRepositoryFabricante _repositoryFabricante;

        public FabricanteController(IRepositoryFabricante repositoryFabricante)
        {
            _repositoryFabricante = repositoryFabricante;
        }

        public IActionResult GetAll() {
            try
            {
                var Fabricante = _repositoryFabricante.GetAll();
                return Ok(Fabricante);
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
                var Fabricante = _repositoryFabricante.Get(id);
                return Ok(Fabricante);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult PostCadastro([FromBody] Fabricante fabricante) {
            try
            {
                Fabricante _Fabricante = new Fabricante();

                if (fabricante.Id > 0)
                {
                    _Fabricante = _repositoryFabricante.Get(fabricante.Id);
                }
                else {
                    _Fabricante = _repositoryFabricante.Find(x => x.Descricao == fabricante.Descricao);
                }

                if (_Fabricante != null && fabricante.Id > 0)
                {
                    _Fabricante.Descricao = fabricante.Descricao;
                    _Fabricante.Ativo = fabricante.Ativo;
                    _repositoryFabricante.Update(_Fabricante);
                    _repositoryFabricante.Save();
                }
                else if (_Fabricante == null && fabricante.Id == 0 ) {
                    _repositoryFabricante.Add(fabricante);
                    _repositoryFabricante.Save();
                }
                else
                {
                    return BadRequest("Já existe o " + fabricante.Descricao + " Cadastrado.");
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
                var _Fabricante = _repositoryFabricante.Get(id);

                if (_Fabricante != null)
                {
                    _repositoryFabricante.Remove(_Fabricante);
                    _repositoryFabricante.Save();
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