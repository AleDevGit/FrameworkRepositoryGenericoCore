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
    public class TipoProdutoController : Controller 
    {
        BaseApi _tipoProdutoApi = new BaseApi();
        private readonly string _UrlTipoProduto = "api/TipoProduto/";

        public async Task<IActionResult> Index() {
            List<TipoProduto> _tipoProduto = new List<TipoProduto>();
            HttpClient client = _tipoProdutoApi.Initial();
            var url = _UrlTipoProduto;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoProduto = JsonConvert.DeserializeObject<List<TipoProduto>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_tipoProduto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] TipoProduto tipoProduto)
        {

            var url = _UrlTipoProduto + "Cadastrar";
            HttpClient client = _tipoProdutoApi.Initial();
            var serializedTipoProduto = JsonConvert.SerializeObject(tipoProduto);
            var content = new StringContent(serializedTipoProduto, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlTipoProduto + id;
            TipoProduto _tipoProduto = new TipoProduto();
            HttpClient client = _tipoProdutoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoProduto = JsonConvert.DeserializeObject<TipoProduto>(result);
                
            }
            return View(_tipoProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlTipoProduto + "Cadastrar";
                HttpClient client = _tipoProdutoApi.Initial();
                var serializedTipoProduto = JsonConvert.SerializeObject(tipoProduto);
                var content = new StringContent(serializedTipoProduto, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(tipoProduto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlTipoProduto + id;
            TipoProduto _tipoProduto = new TipoProduto();
            HttpClient client = _tipoProdutoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _tipoProduto = JsonConvert.DeserializeObject<TipoProduto>(result);

            }
            return View(_tipoProduto);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _tipoProdutoApi.UriApi() + _UrlTipoProduto + id;

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
