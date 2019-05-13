using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.WebCore.Helper;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class ClienteController : Controller
    {
        
        private readonly string _UrlCliente = "api/Cliente/";
        private readonly string _UrlTipoCliente = "api/TipoCliente/";


        BaseApi _clienteApi = new BaseApi();

        public async Task<IActionResult> Index()
        {
            List<Cliente> _Cliente = new List<Cliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(_UrlCliente);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
            }
            return View(_Cliente);
        }

        public async Task<IActionResult> IndexCliente(int? id)
        {
            var url = _UrlCliente + id;
            Cliente _Cliente = new Cliente();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<Cliente>(result);
            }
            return View(_Cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<TipoCliente> ListaTipoCliente = await ListarTipoCliente();
            ViewData["TipoClienteId"] = new SelectList(ListaTipoCliente, "Id", "Descricao");
            return View();
        }

        public async Task<List<TipoCliente>> ListarTipoCliente()
        {
            List<TipoCliente> _TipoCliente = new List<TipoCliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(_UrlTipoCliente);
            if (res.IsSuccessStatusCode)
            {
                res.Content.Headers.ContentLength = 11987;
                var result = res.Content.ReadAsStringAsync().Result;
                _TipoCliente = JsonConvert.DeserializeObject<List<TipoCliente>>(result);
            }
            return _TipoCliente.ToList();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf_Cnpj,TipoClienteId,Ativo")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var url = _UrlCliente + "Cadastrar";
                    HttpClient client = _clienteApi.Initial();
                    var serializedCategoria = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
                    var res = await client.PostAsync(url, content);
                    //return Created(_UrlCliente, cliente);

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.ToString()}");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            List<TipoCliente> ListaTipoCliente = await ListarTipoCliente();
            ViewData["TipoClienteId"] = new SelectList(ListaTipoCliente, "Id", "Descricao");

            var url = _UrlCliente + id;
            Cliente _cliente = new Cliente();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync(url);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                _cliente = JsonConvert.DeserializeObject<Cliente>(result);

            }
            return View(_cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var url = _UrlCliente + "Cadastrar";
                HttpClient client = _clienteApi.Initial();
                var serializedCategoria = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index");
                }
            }
            return View(cliente);
        }
    }
}