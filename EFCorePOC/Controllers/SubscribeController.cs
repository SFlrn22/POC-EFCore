using EFCorePOC.Application.Contracts;
using EFCorePOC.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePOC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriberController(ISubscriberService subscriberService) : ControllerBase
    {
        [HttpPost(Name = "GetSubscriber")]
        public IActionResult Post([FromBody] FilterModel request)
        {
            return Ok(subscriberService.GetSubscribers(request));
        }
    }
}
