using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using weddingPlanner.Models;
using weddingPlanner.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Controllers
{
    public class UserController : Controller
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

        public UserController(WeddingPlannerContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [ImportModelState]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("createuser")]
        [ImportModelState]
        public IActionResult CreateUser(LogReg reguser)
        {
            if (ModelState.IsValid)
            {
                User newuser = new User()
                {
                    FirstName = reguser.reg.FirstName,
                    LastName = reguser.reg.LastName,
                    Email = reguser.reg.Email,
                    Password = reguser.reg.Password,
                };
                _context.Add(newuser);
                _context.SaveChanges();
                User user = _context.Users.SingleOrDefault(u => u.Email == reguser.reg.Email);
                HttpContext.Session.SetInt32("ActiveId", user.UserId);
                return RedirectToAction("Dashboard", "Wedding");
            }
            
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LogReg loguser)
        {
            User curuser = _context.Users.SingleOrDefault(u => u.Email == loguser.log.Email);
            if (curuser != null)
            {
                if (ModelState.IsValid)
                {
                    int ActiveId = curuser.UserId;
                    string ActiveUserName = curuser.FirstName;
                    HttpContext.Session.SetInt32("ActiveId", ActiveId);
                    HttpContext.Session.SetString("ActiveUserName", ActiveUserName);
                    
                    return RedirectToAction("Dashboard", "Wedding");
                }
                ModelState.AddModelError(string.Empty, "Wrong password!");
            }
            
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

    }
}
