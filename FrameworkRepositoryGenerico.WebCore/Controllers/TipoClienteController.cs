using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.WebCore.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class TipoClienteController : Controller 
    {
        BaseApi _tipoClienteApi = new BaseApi();
        private readonly string _UrlTipoCliente = "api/TipoCliente/";

        public async Task<IActionResult> Index() {
            List<TipoCliente> _tipoCliente = new List<TipoCliente>();
            HttpClient client = _tipoClienteApi.Initial();
            var url = _UrlTipoCliente;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoCliente = JsonConvert.DeserializeObject<List<TipoCliente>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_tipoCliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] TipoCliente tipoCliente)
        {

            var url = _UrlTipoCliente + "Cadastrar";
            HttpClient client = _tipoClienteApi.Initial();
            var serializedTipoCliente = JsonConvert.SerializeObject(tipoCliente);
            var content = new StringContent(serializedTipoCliente, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlTipoCliente + id;
            TipoCliente _tipoCliente = new TipoCliente();
            HttpClient client = _tipoClienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoCliente = JsonConvert.DeserializeObject<TipoCliente>(result);
                
            }
            return View(_tipoCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] TipoCliente tipoCliente)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlTipoCliente + "Cadastrar";
                HttpClient client = _tipoClienteApi.Initial();
                var serializedTipoCliente = JsonConvert.SerializeObject(tipoCliente);
                var content = new StringContent(serializedTipoCliente, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(tipoCliente);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlTipoCliente + id;
            TipoCliente _tipoCliente = new TipoCliente();
            HttpClient client = _tipoClienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoCliente = JsonConvert.DeserializeObject<TipoCliente>(result);

            }
            return View(_tipoCliente);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _tipoClienteApi.UriApi() + _UrlTipoCliente + id;

            using (var httpClient = new HttpClient())
            {
                var res = await httpClient.DeleteAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }
    }
}
