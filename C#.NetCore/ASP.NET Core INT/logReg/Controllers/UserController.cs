using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using logReg.Models;
using DbConnection;
using Microsoft.AspNetCore.Http;

namespace logReg.Controllers
{
    public class userController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser user)
        {
            TryValidateModel(user);
            if (ModelState.IsValid)
            {
                string checkq = $"SELECT * FROM users WHERE (email = '{user.email}')";
                var check = DbConnector.Query(checkq);
                if (check.Count == 0)
                {
                    ViewBag.result = "You have entered a wrong email!";
                    return View("Index");
                }
                else
                {
                    string comppass = check[0]["password"].ToString();
                    if (comppass == user.password)
                    {
                        int id = (int)check[0]["id"];
                        HttpContext.Session.SetInt32("id", id);
                        string name = (check[0]["firstname"]).ToString();
                        HttpContext.Session.SetString("user", name);
                        ViewBag.name = name;
                        return View("About");
                    }
                    else
                    {
                        ViewBag.result = "You have entered a wrong password!";
                        return View("Index");
                    }
                }
            }
            else
            {
                return View("Index");
            }
            
            
        }
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(RegisterUser newuser)
        {
            TryValidateModel(newuser);

            string checkq = $"SELECT * FROM users WHERE (email = '{newuser.email}')";
            var check = DbConnector.Query(checkq);
            if (ModelState.IsValid)
            {
                if (check.Count == 0)
                {
                    string query = $"INSERT INTO users (firstname, lastname, email, password, created_at, updated_at) VALUES ('{newuser.firstname}','{newuser.lastname}','{newuser.email}','{newuser.password}',NOW(),NOW())";
                    DbConnector.Execute(query);
                    ViewBag.result = "You have successfully registered!";
                    return View("Index");
                }
                else
                {
                    ViewBag.result = "This email address is already in use!";
                    return View("Register");
                }
            }
            else
            {
                return View("Register");
            }
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
