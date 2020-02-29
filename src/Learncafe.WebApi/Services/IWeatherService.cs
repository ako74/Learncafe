using Learncafe.WebApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecastDto>> GetWeatherForecast();
    }
}
