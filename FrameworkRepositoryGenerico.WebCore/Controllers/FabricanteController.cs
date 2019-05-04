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
    public class FabricanteController : Controller 
    {
        BaseApi _fabricanteApi = new BaseApi();
        private readonly string _UrlFabricante = "api/Fabricante/";

        public async Task<IActionResult> Index() {
            List<Fabricante> _fabricante = new List<Fabricante>();
            HttpClient client = _fabricanteApi.Initial();
            var url = _UrlFabricante;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _fabricante = JsonConvert.DeserializeObject<List<Fabricante>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_fabricante);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Fabricante fabricante)
        {

            var url = _UrlFabricante + "Cadastrar";
            HttpClient client = _fabricanteApi.Initial();
            var serializedFabricante = JsonConvert.SerializeObject(fabricante);
            var content = new StringContent(serializedFabricante, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlFabricante + id;
            Fabricante _fabricante = new Fabricante();
            HttpClient client = _fabricanteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _fabricante = JsonConvert.DeserializeObject<Fabricante>(result);
                
            }
            return View(_fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlFabricante + "Cadastrar";
                HttpClient client = _fabricanteApi.Initial();
                var serializedFabricante = JsonConvert.SerializeObject(fabricante);
                var content = new StringContent(serializedFabricante, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(fabricante);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlFabricante + id;
            Fabricante _fabricante = new Fabricante();
            HttpClient client = _fabricanteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _fabricante = JsonConvert.DeserializeObject<Fabricante>(result);

            }
            return View(_fabricante);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _fabricanteApi.UriApi() + _UrlFabricante + id;

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
