using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using weddingPlanner.Models;
using weddingPlanner.Factory;
using weddingPlanner.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace weddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        // ########## ROUTES ##########
        //  /
        //  /(add_routes_guide)
        //  /
        // ########## ROUTES ##########

        // Dapper connections
        // private readonly UserFactory userFactory;
        // private readonly DbConnector _dbConnector;

        // Entity PostGres Code First connection
        private WeddingPlannerContext _context;

        public WeddingController(WeddingPlannerContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        [ImportModelState]
        public IActionResult Dashboard()
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");

            if (id != null)
            {
                    int ActiveId = (int)id;
                    User user = _context.Users.SingleOrDefault(u => u.UserId == ActiveId);
                    List<Wedding> allweddings = _context.Weddings.Include(w => w.GuestList).ToList();
                    List<Guest> guestlist = _context.Guests.ToList();
                    ViewBag.user = user;
                    ViewBag.weddings = allweddings;
                    ViewBag.guests = guestlist;
                return View("Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You must Login first!");
                return View("Index");
            }
            
        }
        [HttpGet]
        [Route("newwedding")]
        [ImportModelState]
        public IActionResult NewWedding()
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");

            if (id != null)
            {
                    int ActiveId = (int)id;
                    User user = _context.Users.SingleOrDefault(u => u.UserId == ActiveId);
                    ViewBag.user = user;
                return View("NewWedding");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You must Login first!");
                return View("Index");
            }
            
        }
        [HttpGet]
        [Route("showwedding/{wedid}")]
        [ImportModelState]
        public IActionResult ShowWedding(int wedid)
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");

            if (id != null)
            {
                    int ActiveId = (int)id;
                    User user = _context.Users.SingleOrDefault(u => u.UserId == ActiveId);
                    Wedding wedding = _context.Weddings.Include(w => w.GuestList).ThenInclude(g=>g.User).SingleOrDefault(w => w.WedId == wedid);
                    ViewBag.user = user;
                    ViewBag.wedding = wedding;
                return View("ShowWedding");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You must Login first!");
                return View("Index");
            }
            
        }
        [HttpPost]
        [Route("addwedding")]
        [ImportModelState]
        public IActionResult CreateWedding(NewWedding wed)
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");

            if (id != null)
            {       
                
                if(ModelState.IsValid)
                {
                    int ActiveId = (int)id;
                    User user = _context.Users.SingleOrDefault(u => u.UserId == ActiveId);

                    Wedding newwed = new Wedding(){
                        WedOne = wed.WedOne,
                        WedTwo = wed.WedTwo,
                        Date = Convert.ToDateTime(wed.Date),
                        Address = wed.Address,
                        User_Id = ActiveId,
                    };
                    _context.Weddings.Add(newwed);
                    _context.SaveChanges();
                    
                    Wedding wedding = _context.Weddings.Include(w => w.GuestList).LastOrDefault();
                    ViewBag.user = user;
                    ViewBag.wedding = wedding;
                    return View("ShowWedding");
                }
                else
                {
                    int ActiveId = (int)id;
                    User user = _context.Users.SingleOrDefault(u => u.UserId == ActiveId);
                    ViewBag.user = user;
                    return View("NewWedding");
                }
                    
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You must Login first!");
                return View("Index");
            }
            
        }
        [HttpGet]
        [Route("deletewedding/{wedid}")]
        public IActionResult DeleteWedding(int wedid)
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");
            int ActiveId = (int)id;
            Wedding wedding = _context.Weddings.SingleOrDefault(w => w.WedId == wedid);
            if (ActiveId == wedding.User_Id)
            {
                _context.Remove(wedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You cannot delete that!");
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet]
        [Route("attendwedding/{wedid}")]
        public IActionResult AttendWedding(int wedid)
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");
            int ActiveId = (int)id;
            Wedding wedding = _context.Weddings.Include(w=>w.GuestList).SingleOrDefault(w => w.WedId == wedid);
            User curuser = _context.Users.Include(u=>u.WedList).SingleOrDefault(u => u.UserId == ActiveId);
            Guest rsvp = new Guest(){
                UserId = ActiveId,
                User = curuser,
                WedId = wedding.WedId,
                Wedding = wedding,    
            };
            _context.Add(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("unattendwedding/{wedid}")]
        public IActionResult UnattendWedding(int wedid)
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");
            int ActiveId = (int)id;
            Wedding wedding = _context.Weddings.Include(w=>w.GuestList).SingleOrDefault(w => w.WedId == wedid);
            User curuser = _context.Users.Include(u=>u.WedList).SingleOrDefault(u => u.UserId == ActiveId);
            Guest rsvp = _context.Guests.Where(g=>g.UserId==ActiveId).Where(g=>g.WedId==wedid).SingleOrDefault();
            _context.Remove(rsvp);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}
