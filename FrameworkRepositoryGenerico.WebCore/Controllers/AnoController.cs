using FrameworkRepositoryGenerico.DataBase.Entidades;
using FrameworkRepositoryGenerico.WebCore.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class AnoController : Controller 
    {
        BaseApi _anoApi = new BaseApi();
        private readonly string _UrlAno = "api/Ano/";

        public async Task<IActionResult> Index() {
            List<Ano> _ano = new List<Ano>();
            HttpClient client = _anoApi.Initial();
            var url = _UrlAno;
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _ano = JsonConvert.DeserializeObject<List<Ano>>(result);
            }

            TempData["mensagem"] = "Mensagem de sucesso";

            return View(_ano);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Ano ano)
        {

            var url = _UrlAno + "Cadastrar";
            HttpClient client = _anoApi.Initial();
            var serializedAno = JsonConvert.SerializeObject(ano);
            var content = new StringContent(serializedAno, Encoding.UTF8, "application/json");
            var res = await client.PostAsync(url,content);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var url = _UrlAno + id;
            Ano _ano = new Ano();
            HttpClient client = _anoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _ano = JsonConvert.DeserializeObject<Ano>(result);
                
            }
            return View(_ano);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Ano ano)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlAno + "Cadastrar";
                HttpClient client = _anoApi.Initial();
                var serializedAno = JsonConvert.SerializeObject(ano);
                var content = new StringContent(serializedAno, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(ano);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _UrlAno + id;
            Ano _ano = new Ano();
            HttpClient client = _anoApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _ano = JsonConvert.DeserializeObject<Ano>(result);

            }
            return View(_ano);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string url = _anoApi.UriApi() + _UrlAno + id;

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
