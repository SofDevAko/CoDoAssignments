using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using formSubmission.Models;
using System.ComponentModel.DataAnnotations;

namespace formSubmission.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("validate")]
        public IActionResult Validate(string firstname, string lastname, int age, string email, string password)
        {
            User tryuser = new User{
                First_Name = firstname,
                Last_Name = lastname,
                Age = age,
                Email = email,
                Password = password
            };
            TryValidateModel(tryuser);
            
            if (ModelState.IsValid)
            {
                return View("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View("fail");
            }
          
         
           
            
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
