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
        public event EventHandler<WeatherDataEventArgs> WeatherDataReceived;

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
                var forecastData = JsonConvert.DeserializeObject<WeatherForecast>((string)body);

                // Raise the WeatherDataReceived event
                OnWeatherDataReceived(new WeatherDataEventArgs(forecastData));
            }
        }

        protected virtual void OnWeatherDataReceived(WeatherDataEventArgs e)
        {
            WeatherDataReceived?.Invoke(this, e);
        }
    }

    public class WeatherDataEventArgs : EventArgs
    {
        public WeatherForecast WeatherData { get; }

        public WeatherDataEventArgs(WeatherForecast weatherData)
        {
            WeatherData = weatherData;
        }
    }
}
