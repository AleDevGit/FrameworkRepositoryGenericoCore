﻿using System.Net.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrameworkRepositoryGenerico.WebCore.Models;
using FrameworkRepositoryGenerico.WebCore.Helper;
using FrameworkRepositoryGenerico.Data.ModelsCadastro;
using Newtonsoft.Json;

namespace FrameworkRepositoryGenerico.WebCore.Controllers
{
    public class ClienteController : Controller
    {
        ClienteApi _clienteApi = new ClienteApi();

        public async Task<IActionResult> Index()
        {
            List<Cliente> _Cliente = new List<Cliente>();
            HttpClient client = _clienteApi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Clientes");
            if (res.IsSuccessStatusCode)
            {
                res.Content.Headers.ContentLength = 11987;
                var result = res.Content.ReadAsStringAsync().Result;
                _Cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
            }
            return View(_Cliente);
        }
    }
}