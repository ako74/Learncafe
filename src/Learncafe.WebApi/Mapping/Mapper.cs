using Learncafe.WebApi.Dtos;
using Learncafe.WebApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Mapping
{
    public class Mapper : IMapper
    {
        public List<WeatherForecastResponse> MapWeatherForecastDtosToWeatherForecastResponses(List<WeatherForecastDto> dtos)
        {
            return dtos.Select(x => new WeatherForecastResponse
            {
                Date = x.Date,
                Summary = x.Summary,
                TemperatureC = x.TemperatureC
            }).ToList();
        }
    }
}
