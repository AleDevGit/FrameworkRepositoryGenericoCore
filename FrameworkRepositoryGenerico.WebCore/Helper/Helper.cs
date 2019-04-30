using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrameworkRepositoryGenerico.WebCore.Helper
{
    public class BaseApi {
        public HttpClient Initial() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2131/");
            return client;
        }
    }
}
