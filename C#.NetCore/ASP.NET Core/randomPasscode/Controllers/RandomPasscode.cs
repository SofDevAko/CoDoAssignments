using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace randomPasscode.Controllers
{
    public class RandomPasscodeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult RandomPasscode()
        {
            
            if (HttpContext.Session.GetInt32("times")==null)
            {
                int times = 0;
                HttpContext.Session.SetInt32("times", times);
            }
            
            ViewBag.times = HttpContext.Session.GetInt32("times");
            if (TempData["code"]!=null)
            {
                ViewBag.code = TempData["code"];
            }
            return View("random");
        }
        [HttpPost]
        [Route("generate")]
        public IActionResult Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var passcode = new char[14];
            var random = new Random();

            for (int i = 0; i < passcode.Length; i++)
            {
                passcode[i] = chars[random.Next(chars.Length)];
            }
            int? count = HttpContext.Session.GetInt32("times");
            int times = (int)count + 1;
            HttpContext.Session.SetInt32("times", times);

            var randpasscode = new String(passcode);
            TempData["code"] = randpasscode;
            return Redirect("/");
        }
        [HttpPost]
        [Route("generate/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
