using Microsoft.AspNetCore.Mvc;
using WeathersApp.Models;

namespace WeathersApp.Controllers
{
    public class WeatherController : Controller
    {
        //Intialize data in the requirement
        private List<CityWeather> cities = new List<CityWeather>() {
            new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TemperatureFahrenheit = 33 },

            new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TemperatureFahrenheit = 60 },

            new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TemperatureFahrenheit = 82 }
        };

        [Route("/")]
        public IActionResult Index()
        {
            return View(cities);
        }

        public IActionResult City(string? citycode)
        {
            if (string.IsNullOrEmpty(cityUniqueCode))
            {
                return View(); //to index
            }
            CityWeather? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
            return View(city);
        }
    }
}
