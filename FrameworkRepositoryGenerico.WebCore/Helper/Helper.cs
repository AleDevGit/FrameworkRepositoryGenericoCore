using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrameworkRepositoryGenerico.WebCore.Helper
{
    public class ClienteApi {
        public HttpClient Initial() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44343/");
            return client;
        }
    }
}
