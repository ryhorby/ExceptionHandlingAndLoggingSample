using ExceptionHandlingAndLogging.Api.Models;
using ExceptionHandlingAndLogging.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingAndLogging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherRepository _repository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetWeatherList")]
        public Dto GetWeatherList()
        {
            _logger.LogInformation("GetWeatherListEndpoint: operation started");

            var response = _repository.GetAllWeather();

            _logger.LogInformation("GetWeatherListEndpoint: operation succsesfull");

            return new Dto()
            {
                Data = response,
                IsSuccesfull = true
            };
        }
    }
}