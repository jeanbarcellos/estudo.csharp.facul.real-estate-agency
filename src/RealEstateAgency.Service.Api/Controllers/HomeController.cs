using Microsoft.AspNetCore.Mvc;

namespace RealEstateAgency.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Ok("Home");
        }
    }
}
