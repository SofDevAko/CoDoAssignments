using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranter.Controllers
{
    public class RESTController : Controller
    {
        private RESTContext _context;

        public RESTController(RESTContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            List<Review> AllReviews = _context.reviews.OrderByDescending(a => a.VisitDate).ToList();
            ViewBag.allreviews = AllReviews;
            return View("Index");
        }
        [HttpGet]
        [Route("")]
        public IActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        [Route("addreview")]
        public IActionResult AddReview(Review newreview)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newreview);
                _context.SaveChanges();
                List<Review> AllReviews = _context.reviews.OrderByDescending(a => a.VisitDate).ToList();
                ViewBag.allreviews = AllReviews;
                return View("Index");
            }
            return View("New");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
