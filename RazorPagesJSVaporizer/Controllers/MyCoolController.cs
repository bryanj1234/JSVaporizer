using Microsoft.AspNetCore.Mvc;

namespace RazorPagesJSVaporizer
{

    [ApiController]
    [Route("MyCoolController")]
    public class MyCoolController : Controller
    {

        [HttpPost("MyRequestHandler")]
        public ActionResult<string> MyRequestHandler([FromForm] string dtoJSON)
        {

            MyCoolTransformer xformer = new MyCoolTransformer();
            MyCoolTransformerDto? dto = xformer.JsonToDto(dtoJSON);

            return "You called MyRequestHandler() with dtoJSON = \"" + dtoJSON + "\"";
        }
    }
}
