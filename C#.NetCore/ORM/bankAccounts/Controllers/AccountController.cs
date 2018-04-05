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
    public class AccountController : Controller
    {
        private BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("account")]
        public IActionResult Account()
        {
            int? id = HttpContext.Session.GetInt32("ActiveId");

            if (id != null)
            {
                if(TempData.ContainsKey("err"))
                {
                    ViewBag.Error = TempData["err"];
                }
                    int ActiveId = (int)id;
                    User user = _context.users.Include(u => u.Changes).SingleOrDefault(u => u.UserId == ActiveId);
                    ViewBag.AccInfo = user;
                return View("Account");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        [HttpPost]
        [Route("addtrans")]
        public IActionResult AddTransaction(Transaction newtransaction)
        {
            if (ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("ActiveId");
                int ActiveId = (int)id;
                User user = _context.users.SingleOrDefault(u => u.UserId == ActiveId);

                if (newtransaction.Amount < 0 && Math.Abs(newtransaction.Amount)>user.Balance)
                {
                    TempData["err"] = "Not enough money on your Account!";
                }
                else
                {
                    Transaction newtrans = new Transaction()
                    {
                        Description = newtransaction.Description,
                        Amount = newtransaction.Amount,
                        Date = DateTime.Now,
                        UserId = ActiveId,

                    };
                    user.Balance += newtransaction.Amount;
                    _context.Add(newtrans);
                    _context.SaveChanges();
                    TempData["err"] = "Transaction complete!";
                }
                    
            }
            return RedirectToAction("Account");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
