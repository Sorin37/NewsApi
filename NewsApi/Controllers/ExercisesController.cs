using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        [HttpGet]
        public IActionResult ex1([FromQuery] double queryParam1, [FromQuery] double queryParam2)
        {

            return Ok((queryParam2 + queryParam1).ToString());
        }
    }
}
