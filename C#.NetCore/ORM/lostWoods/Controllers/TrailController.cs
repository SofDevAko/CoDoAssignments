using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lostWoods.Models;
using lostWoods.Factory;

namespace lostWoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = trailFactory.FindAll();
            return View();
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Create");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Trail trail)
        {
            TryValidateModel(trail);
            if(ModelState.IsValid)
            {
                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        [HttpGet]
        [Route("trail/{id}")]
        public IActionResult Show(long id)
        {
            ViewBag.trail = trailFactory.FindByID(id);
            return View();
        }
    }
}
