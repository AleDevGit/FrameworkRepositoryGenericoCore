using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using FrameworkRepositoryGenerico.Repository.InterfaceRepositoriesModels;
using FrameworkRepositoryGenerico.Repository.RepositoriesModels;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Telefones/{TelefoneId}")]
    public class TelefoneController : Controller
    {
        private readonly IRepositoryTelefone _repositoryTelefone;

        public TelefoneController(IRepositoryTelefone repository)
        {
            _repositoryTelefone = repository;
        }

        // http://localhost:<port>/api/telefone/{Id}
        public IActionResult Get(int TelefoneId)
        {
            var endereco = _repositoryTelefone.Get(TelefoneId);
            return Ok(endereco);
        }

        // http://localhost:<port>/api/telefone/?IdCliente={IdCliente}
        // http://localhost:<port>/api/telefone/?IdTipoTelefone={IdTipoTelefone}
        // http://localhost:<port>/api/telefone/?IdTipoTelefone={IdTipoTelefone}&IdCliente={IdCliente}
        [HttpGet("/api/Telefone/")]
        public IActionResult Get(Telefone queryModel)
        {
            List<Telefone> telefone = new List<Telefone>();
            if (queryModel.IdCliente != 0 && (queryModel.IdTipoTelefone == 0|| queryModel.IdTipoTelefone == null))
            {
                telefone = _repositoryTelefone.Find(x => x.IdCliente == queryModel.IdCliente).ToList();
            }
            else if (queryModel.IdTipoTelefone != 0 && (queryModel.IdCliente == 0 || queryModel.IdCliente == null))
            {
                telefone = _repositoryTelefone.Find(x => x.IdTipoTelefone == queryModel.IdTipoTelefone).ToList();
            }
            else if (queryModel.IdTipoTelefone != 0 && queryModel.IdCliente != 0)
            {
                telefone = _repositoryTelefone.Find(x => x.IdCliente == queryModel.IdCliente && x.IdTipoTelefone == queryModel.IdTipoTelefone).ToList();
            }
            
            return Ok(telefone);
        }


        public class QueryTelefoneModel
        {
            public int ClienteId { get; set; }

        }
    }
}