using System.Net.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.WebCore.Models;
using FrameworkRepositoryGenerico.WebCore.Helper;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Newtonsoft.Json;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class HomeController : Controller
    {
        BaseApi _clienteApi = new BaseApi();
        public async Task<IActionResult> Index()
        {
            List<Cliente> _Cliente = new List<Cliente>();
            HttpClient client = _clienteApi.Initial();
            var url = "api/Cliente";

            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode) {
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
            }
            return View(_Cliente);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
