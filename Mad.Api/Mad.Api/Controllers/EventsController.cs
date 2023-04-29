using Mad.Bl.Services;
using Mad.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mad.Api.Controllers
{
    [ApiController]
    [Route("event")]
    public class EventsController: ControllerBase
    {
        [HttpPut("create")]
        public Event CreateEvent(string name)
        {
            var service = new EventService();

            return service.CreateEvent(name);
        }
    }
}
