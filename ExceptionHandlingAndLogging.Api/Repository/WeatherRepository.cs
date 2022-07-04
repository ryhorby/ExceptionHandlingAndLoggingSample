using ExceptionHandlerAndLogging.Api.Repository;
using System.Net;

namespace ExceptionHandlingAndLogging.Api.Repository
{
    public class WeatherRepository
    {

        private readonly ILogger<WeatherRepository> _logger;
        private readonly IEnumerable<WeatherForecast> _context = DatabaseInitializer.ListOfWeather;

        public WeatherRepository(ILogger<WeatherRepository> logger)
        {
            _logger = logger;
        }
        
        public IEnumerable<WeatherForecast> GetAllWeather()
        {
            
            _logger.Log(LogLevel.Information,
              message: $"GetAllWeaher repository: executing....");

            var res = _context;
            //throw new NullReferenceException("Weather data is empty");

            _logger.Log(LogLevel.Information,
               message: $"GetAllWeaher repository: successful finish");

            return res;
        }
    }
}
