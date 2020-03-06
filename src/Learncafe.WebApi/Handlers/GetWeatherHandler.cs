using Learncafe.WebApi.Mapping;
using Learncafe.WebApi.Queries;
using Learncafe.WebApi.Responses;
using Learncafe.WebApi.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Handlers
{
    public class GetWeatherHandler : IRequestHandler<WeatherQuery, List<WeatherForecastResponse>>
    {
        private readonly IWeatherService _weatherService;
        private readonly IMapper _mapper;

        public GetWeatherHandler(IWeatherService weatherService, IMapper mapper)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<WeatherForecastResponse>> Handle(WeatherQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await _weatherService.GetWeatherForecast();
            return _mapper.MapWeatherForecastDtosToWeatherForecastResponses(forecasts.ToList());
        }
    }
}
