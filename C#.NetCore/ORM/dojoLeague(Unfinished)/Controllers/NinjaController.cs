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
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        public NinjaController()
        {
            ninjaFactory = new NinjaFactory();
        }
        [HttpGet]
        [Route("ninja")]
        public IActionResult NinjaIndex()
        {
            ViewBag.ninjas = ninjaFactory.FindAll();
            return View("Ninja");
        }
        [HttpPost]
        [Route("addninja")]
        public IActionResult AddNinja(Ninja newninja)
        {
            TryValidateModel(newninja);
            if(ModelState.IsValid)
            {
                ninjaFactory.AddNinja(newninja);
            }
            return Redirect("ninja");
        }
        [HttpGet]
        [Route("ninja/{Id}")]
        public IActionResult ShowNinja(int Id)
        {
            ViewBag.ninja = ninjaFactory.FindByID(Id);
            return View("NinjaShow");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
