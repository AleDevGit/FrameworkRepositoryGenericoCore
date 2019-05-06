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
    public class CategoriaController : Controller 
    {
        BaseApi _categoriaApi = new BaseApi();
        private readonly string _UrlCategoria = "api/Categoria/";

        public async Task<IActionResult> Index() {
            List<Categoria> _categoria = new List<Categoria>();
            HttpClient client = _categoriaApi.Initial();
            var url = _UrlCategoria;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _categoria = JsonConvert.DeserializeObject<List<Categoria>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_categoria);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Categoria categoria)
        {

            var url = _UrlCategoria + "Cadastrar";
            HttpClient client = _categoriaApi.Initial();
            var serializedCategoria = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlCategoria + id;
            Categoria _categoria = new Categoria();
            HttpClient client = _categoriaApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _categoria = JsonConvert.DeserializeObject<Categoria>(result);
                
            }
            return View(_categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlCategoria + "Cadastrar";
                HttpClient client = _categoriaApi.Initial();
                var serializedCategoria = JsonConvert.SerializeObject(categoria);
                var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(categoria);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlCategoria + id;
            Categoria _categoria = new Categoria();
            HttpClient client = _categoriaApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _categoria = JsonConvert.DeserializeObject<Categoria>(result);

            }
            return View(_categoria);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _categoriaApi.UriApi() + _UrlCategoria + id;

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
