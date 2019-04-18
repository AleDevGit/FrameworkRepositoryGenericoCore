using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.DataBase.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repository.RepositoriesModels;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Enderecos/{EnderecoId}")]
    public class EnderecoController : Controller
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public EnderecoController(IRepositoryEndereco repository)
        {
            _repositoryEndereco = repository;
        }

        // http://localhost:<port>/api/Endereco/{Id}
        //public IActionResult Get(int EnderecoId)
        //{
        //    //var endereco = _repositoryEndereco.Get(EnderecoId);
        //    //return Ok(endereco);
        //}

        // http://localhost:<port>/api/Endereco/?IdCliente={IdCliente}
        // http://localhost:<port>/api/Endereco/?IdTipoEndereco={IdTipoEndereco}
        // http://localhost:<port>/api/Endereco/?IdTipoEndereco={IdTipoEndereco}&IdCliente={IdCliente}
        //[HttpGet("/api/Endereco/")]
        //public IActionResult Get(Endereco queryModel)
        //{
        //    List<Endereco> Endereco = new List<Endereco>();
        //    if (queryModel.Id!= 0 )
        //    {
        //        Endereco = _repositoryEndereco.Find(x => x.IdCliente == queryModel.IdCliente).ToList();
        //    }
            
        //    return Ok(Endereco);
        //}
    }
}