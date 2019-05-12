using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Repositories.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class EnderecoController : Controller
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public EnderecoController(IRepositoryEndereco repository)
        {
            _repositoryEndereco = repository;
        }

        //// http://localhost:<port>/api/Endereco/{Id}
        //public IActionResult Get(int EnderecoId)
        //{
        //    var endereco = _repositoryEndereco.Get(EnderecoId);
        //    return Ok(endereco);
        //}

        //// http://localhost:<port>/api/Endereco/?IdCliente={IdCliente}
        
        public IActionResult Get(Endereco queryModel)
        {
            List<Endereco> Endereco = new List<Endereco>();
            if (queryModel.ClienteId != 0 )
            {
                Endereco = _repositoryEndereco.FindAll(x => x.ClienteId == queryModel.ClienteId).ToList();
            }
          
            return Ok(Endereco);
        }
    }
}