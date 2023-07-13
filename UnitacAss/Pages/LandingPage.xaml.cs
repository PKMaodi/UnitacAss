using Microsoft.Maui.Controls;
using UnitacAss.Models;
using UnitacAss.Service;

namespace UnitacAss
{
    public partial class LandingPage : ContentPage
    {
        private WeatherHandler weatherHandler;

        public LandingPage()
        {
            InitializeComponent();

            weatherHandler = new WeatherHandler();
            weatherHandler.WeatherDataReceived += WeatherHandler_WeatherDataReceived;

            BindingContext = new WeatherForecast();
        }

        private void WeatherHandler_WeatherDataReceived(object sender, WeatherDataEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var forecast = (WeatherForecast)BindingContext;
                forecast.Current = e.WeatherData.Current;
                forecast.Forecast = e.WeatherData.Forecast;

                // Update the bindings
                OnPropertyChanged(nameof(BindingContext));
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            weatherHandler.GetWeatherData();
        }
    }
}
