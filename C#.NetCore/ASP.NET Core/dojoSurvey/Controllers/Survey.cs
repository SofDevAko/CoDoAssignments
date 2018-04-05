using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Main()
        {
            return View("Main");
        }

        [HttpPost]
        [Route ("process")]
        public IActionResult Process(string name, string dojo, string favlang, string comment)
        {
            ViewBag.name = name;
            ViewBag.dojo = dojo;
            ViewBag.favlang = favlang;
            ViewBag.comment = comment;
            return View("Result");
        }
    }
}
