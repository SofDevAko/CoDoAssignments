using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace renderingViews.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
