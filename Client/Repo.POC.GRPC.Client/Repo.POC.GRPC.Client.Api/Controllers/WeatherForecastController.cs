using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repo.POC.GRPC.Client.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Client.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IEmployeeService _employeeService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var reply = _employeeService.
                        InsertEmployee(new Service.Dtos.EmployeeInsertDto { Name = "Adhan Oliveira", Email = "adhan.maldonado@gmail.com" });
                        


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
