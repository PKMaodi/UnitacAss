using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
namespace UnitacAss
{
    internal class WeatherHandler
    {
        private HttpClient client;
        public WeatherHandler()
        {
            client = new HttpClient();
        }

        public async Task<string> GetForecast()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/forecast.json?q=London&days=3"),
                Headers =
            {
                { "X-RapidAPI-Key", "8d6a83b7a3mshe727e25aa80e7ebp1a6d73jsndbd2866866a7" },
                { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
            },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
