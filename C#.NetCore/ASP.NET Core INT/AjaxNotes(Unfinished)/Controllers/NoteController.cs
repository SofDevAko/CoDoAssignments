using System;
using System.Collections.Generic;
using DbConnection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxNotes.Models;

namespace AjaxNotes.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var notes = DbConnector.Query("SELECT * FROM notes");
            ViewBag.notes = notes;
            return View("Index");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(string title)
        {
            DbConnector.Execute($"INSERT INTO notes (title, content, created_at) VALUES ('{title}','', NOW())");
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            DbConnector.Execute($"DELETE FROM notes WHERE id = '{id}'");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult update(int id, string content)
        {  
            System.Console.WriteLine(content);
            var query = $"UPDATE notes SET content = '{content}' WHERE id = {id}";
            DbConnector.Execute(query);
            System.Console.WriteLine("UPDATED!!");
            return RedirectToAction("Index");
        
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
