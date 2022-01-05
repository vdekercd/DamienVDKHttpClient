using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamienVDKHttpClient.Services
{
    public class NamedHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NamedHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetResultAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.HttpClientName);
            var response = await httpClient.GetAsync("V1/Todo");
            Console.WriteLine(response.StatusCode);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
