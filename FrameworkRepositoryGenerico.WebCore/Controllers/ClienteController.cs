using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.WebCore.Helper;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class ClienteController : Controller
    {
        
        private readonly string _UrlCliente = "api/Cliente/";
        
        BaseApi _clienteApi = new BaseApi();

        public async Task<IActionResult> Index()
        {
            List<Cliente> _Cliente = new List<Cliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(_UrlCliente);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
            }
            return View(_Cliente);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<TipoCliente> ListaTipoCliente = await ListarTipoCliente();
            ViewData["TipoClienteId"] = new SelectList(ListaTipoCliente, "Id", "Descricao");
            return View();
        }

        public async Task<List<TipoCliente>> ListarTipoCliente()
        {
            List<TipoCliente> _TipoCliente = new List<TipoCliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/TipoCliente");
            if (res.IsSuccessStatusCode)
            {
                res.Content.Headers.ContentLength = 11987;
                var result = res.Content.ReadAsStringAsync().Result;
                _TipoCliente = JsonConvert.DeserializeObject<List<TipoCliente>>(result);
            }
            return _TipoCliente.ToList();

            //return Json(new { ok = true, data = _TipoCliente.Select(x => new { id = x.Id, label = x.Descricao }).Distinct(), mensagem = "OK" });

        }



        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf_Cnpj,TipoClienteId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {

                //var urlTipoCliente = _UrlTipoCliente + cliente.TipoClienteId;
                //TipoCliente _tipoCliente = new TipoCliente();
                //HttpClient clienttipoCliente = _clienteApi.Initial();
                //HttpResponseMessage restipoCliente = await clienttipoCliente.GetAsync(urlTipoCliente);
                //if (restipoCliente.IsSuccessStatusCode)
                //{
                //    var result = restipoCliente.Content.ReadAsStringAsync().Result;
                //    _tipoCliente = JsonConvert.DeserializeObject<TipoCliente>(result);
                //    cliente.TipoCliente = _tipoCliente;

                //}


                var url = _UrlCliente + "Cadastrar";
                HttpClient client = _clienteApi.Initial();
                var serializedCategoria = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

    }
}