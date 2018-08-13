using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace new_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StranglerController : ControllerBase
    {
        [HttpGet("config")]
        public object GetConfig()
        {
            return new Dictionary<string, string>
            {
                { "legacy::app", "http://localhost:61330/" }
            };
        }
    }
}
