using Newtonsoft.Json;

namespace UnitacAss.Service
{
    public class WeatherHandler
    {
        private async void GetWeatherData(object sender, EventArgs e)
        {
            // Make a request to the WeatherAPI.com API.
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=Pretoria"),
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

                // Deserialize the JSON data into a CurrentWeather object.
                var weather = JsonConvert.DeserializeObject<CurrentWeather>(body);

                // Get the minimum and maximum temperatures.
                var condition = weather.pretoriaWeather.condition;
                var minTemp = weather.pretoriaWeather.min_temp;
                var maxTemp = weather.pretoriaWeather.max_temp;
            }
        }
    }
}