using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::UnitacAss.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitacAss.Tests
{
    namespace UnitacAss.Tests
    {
        [TestClass]
        public class WeatherHandlerTests
        {
            [TestMethod]
            public void GetWeatherData_ValidResponse_ParsesWeatherForecast()
            {
                // Arrange
                var weatherHandler = new Service.WeatherHandler();
                bool eventReceived = false;

                // Subscribe to the WeatherDataReceived event
                weatherHandler.WeatherDataReceived += (sender, e) =>
                {
                    eventReceived = true;
                };

                // Act
                weatherHandler.GetWeatherData();

                // Assert
                Assert.IsTrue(eventReceived);
            }

            [TestMethod]
            public void WeatherDataEventArgs_Constructor_SetsWeatherData()
            {
                var weatherData = new WeatherForecast();

                var eventArgs = new Service.WeatherDataEventArgs(weatherData);

                Assert.AreEqual(weatherData, eventArgs.WeatherData);
            }

            [TestMethod]
            public void LandingPage_WeatherHandler_WeatherDataReceived_UpdatesWeatherItems()
            {
                var landingPage = new LandingPage();
                var weatherData = new WeatherForecast
                {
                    Forecast = new List<WeekData>
                {
                    new WeekData { Day = "18-July-2023", Min = 10, Max = 20 },
                    new WeekData { Day = "19-July-2023", Min = 15, Max = 25 }
                }
                };
                var eventArgs = new Service.WeatherDataEventArgs(weatherData);

                landingPage.WeatherHandler_WeatherDataReceived(null, eventArgs);

                CollectionAssert.AreEqual(weatherData.Forecast, landingPage.WeatherItems);
            }
        }
    }

}
