using UnitacAss.Models;
using Newtonsoft.Json;

namespace UnitacAss;

public partial class LandingPage : ContentPage
{
	List<DayWeather> dayWeathers;
	List<DayWeather> WeatherForcast
	{
		get { return dayWeathers; }
		set {
            dayWeathers = value;
			OnPropertyChanged(nameof(WeatherForcast));
		}
	}
	public LandingPage()
	{
		InitializeComponent();
		DisplayForecast();

    }

    private async void DisplayForecast()
    {
        WeatherHandler weatherHandler = new WeatherHandler();
		string weatherData = await weatherHandler.GetForecast();

        
        List<DayWeather> forecastItems = ParseForcastData(weatherData);

       
        WeatherForcast = forecastItems;
    }

    private List<DayWeather> ParseForcastData(string weatherData)
    {
        dynamic forecastJson = JsonConvert.DeserializeObject(weatherData);

        List<DayWeather> forecastItems = new List<DayWeather>();

        foreach (dynamic dailyForecast in forecastJson.forecast.forecastday)
        {
            string day = dailyForecast.date.ToString("dddd");
            double minTemperature = Convert.ToDouble(dailyForecast.day.mintemp_c);
            double maxTemperature = Convert.ToDouble(dailyForecast.day.maxtemp_c);

            DayWeather forecastItem = new DayWeather { Day = day, MinTemp = minTemperature, MaxTemp = maxTemperature };

            forecastItems.Add(forecastItem);
        }

        return forecastItems;
    }

    private void GotoDetailsPage(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is DayWeather selectedForecast)
        {
            
            Navigation.PushAsync(new DetailsPage(selectedForecast));
        }
    }
}

