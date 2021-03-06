﻿using Learncafe.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherService()
        {

        }

        public Task<IEnumerable<WeatherForecastDto>> GetWeatherForecast()
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return Task.FromResult<IEnumerable<WeatherForecastDto>>(result);
        }

    }

    public interface ITodoService
    {
        Task<IEnumerable<TodoTaskDto>> GetTodos();
    }

    public class SimpleTodoService : ITodoService
    {
        private static readonly string[] TodoNames = new[] {"posprzątać", "pozmywać", "poruchać"};
        public SimpleTodoService()
        {
        }

        public Task<IEnumerable<TodoTaskDto>> GetTodos()
        {
            var result = new List<TodoTaskDto>();
            foreach(var name in TodoNames)
            {
                result.Add(new TodoTaskDto(name));
            }
            return Task.FromResult<IEnumerable<TodoTaskDto>>(result);
        }
    }
}
