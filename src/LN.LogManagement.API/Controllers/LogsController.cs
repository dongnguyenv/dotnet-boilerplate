using Microsoft.AspNetCore.Mvc;

namespace LN.LogManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "logs")]
        public IEnumerable<Log> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Log
            {
                id = Guid.NewGuid(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}