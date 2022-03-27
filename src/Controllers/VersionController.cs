using Microsoft.AspNetCore.Mvc;

namespace EntityModel.Controllers
{
    [Route("api/")]
    public class VersionController : ControllerBase
    {
        [HttpGet("version")]
        public string GetVersion()
        {
            return "0.1.2.3";
        }
    }
}