using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace bankAccounts.Controllers
{
    public class UserController : Controller
    {
        private BankContext _context;
        public UserController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [Route("register/create")]
        public IActionResult Create(RegUser reguser)
        {
            if (ModelState.IsValid)
            {
                User newuser = new User()
                {
                    UserName = reguser.UserName,
                    Email = reguser.Email,
                    Password = reguser.Password,
                };
                _context.Add(newuser);
                _context.SaveChanges();
                User user = _context.users.SingleOrDefault(u => u.Email == reguser.Email);
                HttpContext.Session.SetInt32("ActiveId", user.UserId);
                return RedirectToAction("Account", "Account");
            }
            return View("Register");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser loguser)
        {
            User curuser = _context.users.SingleOrDefault(u => u.Email == loguser.Email);
            if (curuser != null)
            {
                if (ModelState.IsValid)
                {
                    int ActiveId = curuser.UserId;
                    string ActiveUserName = curuser.UserName;
                    HttpContext.Session.SetInt32("ActiveId", ActiveId);
                    HttpContext.Session.SetString("ActiveUserName", ActiveUserName);
                    List<Transaction> AllTransactions = _context.transactions.Where(t => t.UserId == ActiveId).OrderBy(a => a.Date).ToList();
                    ViewBag.AccInfo = AllTransactions;
                    return RedirectToAction("Account", "Account");
                }

            }
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
