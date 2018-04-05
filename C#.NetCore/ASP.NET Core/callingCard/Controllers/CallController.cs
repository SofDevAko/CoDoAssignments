using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingCard.Controllers
{
    public class CallController : Controller
    {
        [HttpGet]
        [Route("{fn}/{ln}/{age}/{favcol}")]
        public JsonResult JsonMaker(string fn, string ln, string age, string favcol)
        {
            var Obj = new {
                First_Name = fn,
                Last_Name = ln,
                Age = age,
                Fav_Color = favcol,
            };
            
            return Json(Obj);

        }
    }
}
