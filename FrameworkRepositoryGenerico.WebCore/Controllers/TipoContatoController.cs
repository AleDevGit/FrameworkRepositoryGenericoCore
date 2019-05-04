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
    public class TipoContatoController : Controller 
    {
        BaseApi _tipoContatoApi = new BaseApi();
        private readonly string _UrlTipoContato = "api/TipoContato/";

        public async Task<IActionResult> Index() {
            List<TipoContato> _tipoContato = new List<TipoContato>();
            HttpClient client = _tipoContatoApi.Initial();
            var url = _UrlTipoContato;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoContato = JsonConvert.DeserializeObject<List<TipoContato>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_tipoContato);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] TipoContato tipoContato)
        {

            var url = _UrlTipoContato + "Cadastrar";
            HttpClient client = _tipoContatoApi.Initial();
            var serializedTipoContato = JsonConvert.SerializeObject(tipoContato);
            var content = new StringContent(serializedTipoContato, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlTipoContato + id;
            TipoContato _tipoContato = new TipoContato();
            HttpClient client = _tipoContatoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoContato = JsonConvert.DeserializeObject<TipoContato>(result);
                
            }
            return View(_tipoContato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlTipoContato + "Cadastrar";
                HttpClient client = _tipoContatoApi.Initial();
                var serializedTipoContato = JsonConvert.SerializeObject(tipoContato);
                var content = new StringContent(serializedTipoContato, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(tipoContato);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlTipoContato + id;
            TipoContato _tipoContato = new TipoContato();
            HttpClient client = _tipoContatoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoContato = JsonConvert.DeserializeObject<TipoContato>(result);

            }
            return View(_tipoContato);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _tipoContatoApi.UriApi() + _UrlTipoContato + id;

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
