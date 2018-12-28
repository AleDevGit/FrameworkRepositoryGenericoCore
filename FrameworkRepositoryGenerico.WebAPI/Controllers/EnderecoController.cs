using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repository.RepositoriesModels;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Endereco/{Id}")]
    [ApiController]
    public class EnderecoController : Controller
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public EnderecoController(IRepositoryEndereco repositoryEndereco)
            => _repositoryEndereco = repositoryEndereco;

        // http://localhost:<Porta>/api/Endereco/11
        public IActionResult Get(int Id)
        {
            var endereco  = _repositoryEndereco.Get(Id);
            return Ok(endereco);
            // return endereco;
        }

        // http://localhost:<Porta>/api/Endereco/?Id=11
        // http://localhost:<Porta>/api/Endereco/?Id=11&logradouro=dave
        // http://localhost:<Porta>/api/Endereco/?Id=11&logradouro=dave&ClienteId=15
        [HttpGet("/api/Endereco/")]
        public IActionResult Get(Endereco enderecoModel)
        {

            var endereco = _repositoryEndereco.Find(x => x.IdCliente == enderecoModel.IdCliente).ToList();
            return Ok(endereco);

            //return Ok(enderecoModel);
        }

        // http://localhost:27624/api/account/11/manager/22/role/33
        [HttpGet("/api/Endereco/{AccountId}/Manager/{ManagerId}/Role/{RoleId}")]
        public IActionResult Get(int accountId, int managerId, int roleId)
        {
            return Ok($"accountId:{accountId}, managerId:{managerId}, roleId:{roleId}");
        }

    }
}