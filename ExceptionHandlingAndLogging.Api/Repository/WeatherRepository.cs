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
              message: $"GetAllWeaher Method: try to get all weather");

            var res = _context;
            //throw new NulLReferanceException("Weather data is empty");

            _logger.Log(LogLevel.Information,
               message: $"GetAllWeaher Method: operation succesfull");

            return res;
        }
    }
}
