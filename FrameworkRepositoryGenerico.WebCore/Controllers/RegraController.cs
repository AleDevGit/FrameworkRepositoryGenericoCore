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
    public class RegraController : Controller 
    {
        BaseApi _regraApi = new BaseApi();
        private readonly string _UrlRegra = "api/Regra/";

        public async Task<IActionResult> Index() {
            List<Regra> _regra = new List<Regra>();
            HttpClient client = _regraApi.Initial();
            var url = _UrlRegra;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _regra = JsonConvert.DeserializeObject<List<Regra>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_regra);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Regra regra)
        {

            var url = _UrlRegra + "Cadastrar";
            HttpClient client = _regraApi.Initial();
            var serializedRegra = JsonConvert.SerializeObject(regra);
            var content = new StringContent(serializedRegra, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlRegra + id;
            Regra _regra = new Regra();
            HttpClient client = _regraApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _regra = JsonConvert.DeserializeObject<Regra>(result);
                
            }
            return View(_regra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Regra regra)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlRegra + "Cadastrar";
                HttpClient client = _regraApi.Initial();
                var serializedRegra = JsonConvert.SerializeObject(regra);
                var content = new StringContent(serializedRegra, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(regra);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlRegra + id;
            Regra _regra = new Regra();
            HttpClient client = _regraApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _regra = JsonConvert.DeserializeObject<Regra>(result);

            }
            return View(_regra);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _regraApi.UriApi() + _UrlRegra + id;

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
