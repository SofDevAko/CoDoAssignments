using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojoLeague.Models;
using dojoLeague.Factory;

namespace dojoLeague.Controllers
{
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;
        public DojoController()
        {
            dojoFactory = new DojoFactory();
        }
        [HttpGet]
        [Route("dojo")]
        public IActionResult DojoIndex()
        {
            ViewBag.dojos = dojoFactory.FindAll();
            return View("Dojo");
        }
        [HttpPost]
        [Route("adddojo")]
        public IActionResult AddDojo(Dojo newdojo)
        {
            TryValidateModel(newdojo);
            if(ModelState.IsValid)
            {
                dojoFactory.AddDojo(newdojo);
            }
            return Redirect("dojo");
        }

        public IActionResult ShowDojo()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
