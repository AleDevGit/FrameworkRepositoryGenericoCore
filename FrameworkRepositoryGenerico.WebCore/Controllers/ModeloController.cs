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
    public class ModeloController : Controller 
    {
        BaseApi _modeloApi = new BaseApi();
        private readonly string _UrlModelo = "api/Modelo/";

        public async Task<IActionResult> Index() {
            List<Modelo> _modelo = new List<Modelo>();
            HttpClient client = _modeloApi.Initial();
            var url = _UrlModelo;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _modelo = JsonConvert.DeserializeObject<List<Modelo>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_modelo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Modelo modelo)
        {

            var url = _UrlModelo + "Cadastrar";
            HttpClient client = _modeloApi.Initial();
            var serializedModelo = JsonConvert.SerializeObject(modelo);
            var content = new StringContent(serializedModelo, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlModelo + id;
            Modelo _modelo = new Modelo();
            HttpClient client = _modeloApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _modelo = JsonConvert.DeserializeObject<Modelo>(result);
                
            }
            return View(_modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlModelo + "Cadastrar";
                HttpClient client = _modeloApi.Initial();
                var serializedModelo = JsonConvert.SerializeObject(modelo);
                var content = new StringContent(serializedModelo, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(modelo);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlModelo + id;
            Modelo _modelo = new Modelo();
            HttpClient client = _modeloApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _modelo = JsonConvert.DeserializeObject<Modelo>(result);

            }
            return View(_modelo);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _modeloApi.UriApi() + _UrlModelo + id;

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
