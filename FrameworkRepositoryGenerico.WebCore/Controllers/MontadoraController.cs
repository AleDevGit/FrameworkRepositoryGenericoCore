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
    public class MontadoraController : Controller 
    {
        BaseApi _montadoraApi = new BaseApi();
        private readonly string _UrlMontadora = "api/Montadora/";

        public async Task<IActionResult> Index() {
            List<Montadora> _montadora = new List<Montadora>();
            HttpClient client = _montadoraApi.Initial();
            var url = _UrlMontadora;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _montadora = JsonConvert.DeserializeObject<List<Montadora>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_montadora);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Montadora montadora)
        {

            var url = _UrlMontadora + "Cadastrar";
            HttpClient client = _montadoraApi.Initial();
            var serializedMontadora = JsonConvert.SerializeObject(montadora);
            var content = new StringContent(serializedMontadora, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlMontadora + id;
            Montadora _montadora = new Montadora();
            HttpClient client = _montadoraApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _montadora = JsonConvert.DeserializeObject<Montadora>(result);
                
            }
            return View(_montadora);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Montadora montadora)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlMontadora + "Cadastrar";
                HttpClient client = _montadoraApi.Initial();
                var serializedMontadora = JsonConvert.SerializeObject(montadora);
                var content = new StringContent(serializedMontadora, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(montadora);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlMontadora + id;
            Montadora _montadora = new Montadora();
            HttpClient client = _montadoraApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _montadora = JsonConvert.DeserializeObject<Montadora>(result);

            }
            return View(_montadora);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _montadoraApi.UriApi() + _UrlMontadora + id;

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
