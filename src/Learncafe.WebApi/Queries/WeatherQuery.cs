using Learncafe.WebApi.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Learncafe.WebApi.Queries {
    public class WeatherQuery : IRequest<List<WeatherForecastResponse>>
    {
    }
}
