using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using UnitacAss.Models;

namespace UnitacAss.Service
{
    public class WeatherHandler
    {
        public async void GetWeatherData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/forecast.json?q=Pretoria&days=7"),
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
                // Parse the JSON string
                parseJSONData(body);
            }

        }

        private void parseJSONData(object body)
        {
            //Parse the data
            var forecastData = JsonConvert.DeserializeObject<WeatherForecast>((string)body);

            // ListView to display the forecast for the week
            var ItemsSource = forecastData.Forecast;
        }
    }
}