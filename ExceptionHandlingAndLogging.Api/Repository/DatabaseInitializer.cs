using ExceptionHandlingAndLogging.Api;

namespace ExceptionHandlerAndLogging.Api.Repository
{
    public static class DatabaseInitializer
    {
        public static List<WeatherForecast> ListOfWeather { get; set; }

        static DatabaseInitializer()
        {
            ListOfWeather = new List<WeatherForecast>()
            {
                new WeatherForecast()
                    { Date = DateTime.Now.AddDays(1), Summary = "Cold", TemperatureC = -27 },
                new WeatherForecast()
                    { Date = DateTime.Now.AddDays(2), Summary = "Hot", TemperatureC = 22 },
                new WeatherForecast()
                    { Date = DateTime.Now.AddDays(3), Summary = "Chilly", TemperatureC = 17 }
            };
        }
    }
}
