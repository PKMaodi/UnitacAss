using UnitacAss.Models;
using Newtonsoft.Json;

namespace UnitacAss;

public partial class LandingPage : ContentPage
{
    private void goToDetailsPage(object sender, SelectedItemChangedEventArgs e)
    {
        // Get the selected item's data
        var item = e.SelectedItem as DayWeather;

        // Create a new DetailsPage
        var detailsPage = new DetailsPage(item);

        // Set the IsBackButtonEnabled property to true so that the user can navigate back to the LandingPage
        detailsPage.IsBackButtonEnabled = true;

        // Navigate to the DetailsPage
        //MainPage.Current.Navigation.PushAsync(detailsPage);
    }
}

