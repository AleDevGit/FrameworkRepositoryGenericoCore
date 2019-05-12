using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.WebCore.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class EnderecoController : Controller
    {

        BaseApi _enderecoApi = new BaseApi();
        private readonly string _UrlEndereco = "api/Endereco/";
        private readonly string _UrlCliente = "api/Cliente/";

        [HttpGet]
        public async Task<IActionResult> Index(int? ClienteId)
        {
            Cliente _cliente = new Cliente();
            HttpClient client = _enderecoApi.Initial();
            var url = _UrlCliente + ClienteId;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _cliente = JsonConvert.DeserializeObject<Cliente>(result);
            }
            return View(_cliente);
        }


        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            Cliente _Cliente = await GetCliente(id);
            ViewBag.Cliente = _Cliente;
            return View();
        }

        public async Task<Cliente> GetCliente(int? id)
        {
            Cliente _Cliente = new Cliente();
            HttpClient client = _enderecoApi.Initial();
            var url = _UrlCliente + id;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<Cliente>(result);
            }
            return _Cliente;

        }
    }
}