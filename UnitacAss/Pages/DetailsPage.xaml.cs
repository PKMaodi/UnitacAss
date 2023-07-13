using UnitacAss.Models;
using Microsoft.Maui.Controls;

namespace UnitacAss
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(DayWeather selectedDay)
        {
            InitializeComponent();

            BindingContext = selectedDay;
        }
    }
}
