using UnitacAss.Models;

namespace UnitacAss;

public partial class DetailsPage : ContentPage
{
    private DayWeather selectedForecast;


    public DetailsPage(DayWeather selectedForecast){
        InitializeComponent();
        this.selectedForecast = selectedForecast;
        BindingContext = selectedForecast;
    }

    public bool IsBackButtonEnabled { get; internal set; }

    private async void OnGoBackClicked(object sender, EventArgs e){
        await Navigation.PopAsync();
    }
}