using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.WebCore.Helper;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Newtonsoft.Json;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class ClienteController : Controller
    {
        BaseApi _clienteApi = new BaseApi();

        public async Task<IActionResult> Index()
        {
            List<Cliente> _Cliente = new List<Cliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Clientes");
            if (res.IsSuccessStatusCode)
            {
                res.Content.Headers.ContentLength = 11987;
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
            }
            return View(_Cliente);
        }
    }
}