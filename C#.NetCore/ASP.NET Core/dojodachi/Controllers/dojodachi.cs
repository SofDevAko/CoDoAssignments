using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojodachi.Controllers
{
    public class dojodachiController : Controller
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            var happy = HttpContext.Session.GetInt32("happiness");
            var full = HttpContext.Session.GetInt32("fullness");
            var energy = HttpContext.Session.GetInt32("energy");
            var meal = HttpContext.Session.GetInt32("meals");
            string text = HttpContext.Session.GetString("text");
            string image = HttpContext.Session.GetString("image");
            
            if (happy == null)
            {
                
                happy = 20;
                full = 20;
                energy = 20;
                meal = 3;
                text = "Welcome to Dojodachi!";
                image = "base";
            }
            if (energy >= 100 && happy >= 100 && full >= 100)
            {
                text = "!!!YOU WON!!!";
                ViewBag.cond = "won";
                ViewBag.text = text;
                ViewBag.happiness = happy;
                ViewBag.fullness = full;
                ViewBag.energy = energy;
                ViewBag.meals = meal;
                ViewBag.image = image;
                return View("index");
            }
            if (happy <= 0 || full <= 0)
            {
                text = "!!!YOU LOST!!!";
                ViewBag.cond = "lost";
                ViewBag.text = text;
                ViewBag.happiness = happy;
                ViewBag.fullness = full;
                ViewBag.energy = energy;
                ViewBag.meals = meal;
                ViewBag.image = image;
                return View("index");
            }

            ViewBag.text = text;
            ViewBag.happiness = happy;
            ViewBag.fullness = full;
            ViewBag.energy = energy;
            ViewBag.meals = meal;
            ViewBag.image = image;

            HttpContext.Session.SetInt32("happiness",(int)happy);
            HttpContext.Session.SetInt32("fullness",(int)full);
            HttpContext.Session.SetInt32("energy",(int)energy);
            HttpContext.Session.SetInt32("meals",(int)meal);
            HttpContext.Session.SetString("text",(string)text);
            HttpContext.Session.SetString("image",(string)image);

            return View("index");
        }

        [HttpGet]
        [Route ("feed")]
        public IActionResult Feed()
        {   
            var full = HttpContext.Session.GetInt32("fullness");
            var meal = HttpContext.Session.GetInt32("meals");
            string text = HttpContext.Session.GetString("text");
            string image = HttpContext.Session.GetString("image");

            var rand = new Random();
            if (meal > 0)
            {
                int chance = rand.Next(1,5);
                if (chance == 1)
                {
                    text = "You fed with your dojodachi, but it did not like it...";
                    image = "base";
                    meal -= 1;
                }
                else
                {
                    int amount = rand.Next(5,11);
                    full += amount;
                    meal -= 1;
                    image = "feed";
                    text = "Your dojodachi has eaten sushi and gained "+amount+" fullness!";
                }
                
            }
            else
            {
                text = "You need to have meals to feed your Dojodachi!";
                image = "base";
            }
            
            HttpContext.Session.SetInt32("fullness",(int)full);
            HttpContext.Session.SetInt32("meals",(int)meal);
            HttpContext.Session.SetString("text",(string)text);
            HttpContext.Session.SetString("image",(string)image);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route ("play")]
        public IActionResult Play()
        {
            var happy = HttpContext.Session.GetInt32("happiness");
            var energy = HttpContext.Session.GetInt32("energy");
            string text = HttpContext.Session.GetString("text");
            string image = HttpContext.Session.GetString("image");

            if (energy > 0)
            {
                var rand = new Random();
                
                int chance = rand.Next(1,5);
                if (chance == 1)
                {
                    text = "You played with your dojodachi, but it did not like it...";
                    image = "base";
                    energy -= 1;
                }
                else
                {
                int amount = rand.Next(5,11);
                happy += amount;
                text = "You played hide and seek with your dojodachi and increased "+amount+" happiness!";
                energy -= 1;
                image = "play";
                }
            }
            else
            {
                text = "Your dojodachi cannot play without energy!";
                image = "base";
            }

            

            HttpContext.Session.SetInt32("happiness",(int)happy);
            HttpContext.Session.SetInt32("energy",(int)energy);
            HttpContext.Session.SetString("text",(string)text);
            HttpContext.Session.SetString("image",(string)image);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route ("work")]
        public IActionResult Work()
        {
            var energy = HttpContext.Session.GetInt32("energy");
            var meal = HttpContext.Session.GetInt32("meals");
            string text = HttpContext.Session.GetString("text");
            string image = HttpContext.Session.GetString("image");
            
            if (energy >= 5)
            {
                energy -= 5;
                var rand = new Random();
                int amount = rand.Next(1,4);
                meal += amount;
                text = "Your dojodachi worked in hospital and earned "+amount+" meals!";
                image = "work";
            }
            else
            {
                text = "Your dojodachi cannot work without energy!";
                image = "base";
            }
            

            HttpContext.Session.SetInt32("energy",(int)energy);
            HttpContext.Session.SetInt32("meals",(int)meal);
            HttpContext.Session.SetString("text",(string)text);
            HttpContext.Session.SetString("image",(string)image);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route ("sleep")]
        public IActionResult Sleep()
        {
            var happy = HttpContext.Session.GetInt32("happiness");
            var full = HttpContext.Session.GetInt32("fullness");
            var energy = HttpContext.Session.GetInt32("energy");
            string text = HttpContext.Session.GetString("text");
            string image = HttpContext.Session.GetString("image");

            energy += 15;
            full -= 5;
            happy -= 5;
            text = "Your dojodachi slept and gained 15 energy, but lost 5 happiness and fullness...";
            image = "sleep";

            HttpContext.Session.SetInt32("happiness",(int)happy);
            HttpContext.Session.SetInt32("fullness",(int)full);
            HttpContext.Session.SetInt32("energy",(int)energy);
            HttpContext.Session.SetString("text",(string)text);
            HttpContext.Session.SetString("image",(string)image);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route ("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
