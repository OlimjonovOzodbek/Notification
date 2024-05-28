using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notification.API.Hubs;


namespace Notification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public WeatherForecastController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok();
        }
    }
}
