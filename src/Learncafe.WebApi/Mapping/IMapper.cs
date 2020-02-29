using Learncafe.WebApi.Dtos;
using Learncafe.WebApi.Responses;
using System.Collections.Generic;

namespace Learncafe.WebApi.Mapping
{
    public interface IMapper
    {
        List<WeatherForecastResponse> MapWeatherForecastDtosToWeatherForecastResponses(List<WeatherForecastDto> dtos);
    }
}
