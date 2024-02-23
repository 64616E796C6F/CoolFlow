using AlsetSoft.CoolFlow.BlazorConcept.Models;
using AlsetSoft.CoolFlow.BlazorConcept.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlsetSoft.CoolFlow.BlazorConcept.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly LaserService _deviceService;

        public LogController(ILogger<LogController> logger, LaserService deviceService)
        {
            this._logger = logger;
            this._deviceService = deviceService;
        }

        [HttpGet]
        public IEnumerable<DeviceMultiplexorData> Get()
        {
            return _deviceService.GetMultiplexorsData();
        }

        [HttpPost]
        public void Post([FromBody] DeviceMultiplexorData data)
        {
            _logger.LogInformation(JsonSerializer.Serialize(data));

            _deviceService.SetMultiplexorData(data);
        }
    }
}
