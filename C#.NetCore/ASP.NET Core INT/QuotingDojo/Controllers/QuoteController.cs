using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;
using Microsoft.AspNetCore.Mvc;
using Quoting_Dojo.Models;

namespace Quoting_Dojo.Controllers
{
    public class QuoteController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes(user, quote, created_at) VALUES ('{name}','{quote}',NOW())");
            return RedirectToAction("Quotes");
        }
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> quotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.quotes = quotes;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
