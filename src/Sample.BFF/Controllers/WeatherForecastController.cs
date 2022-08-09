using MassTransit;
using MassTransit.Scheduling;
using Microsoft.AspNetCore.Mvc;
using Sample.Worker;

namespace Sample.BFF.Controllers
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
        private readonly IMessageScheduler _requestClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageScheduler requestClient)
        {
            _logger = logger;
            _requestClient = requestClient;
        }

        [HttpPost(Name = "Post")]
        public async Task Post()
        {
            await _requestClient.SchedulePublish(DateTime.Now.AddSeconds(30), new AScheduledMessage { });
        } 
    }
}