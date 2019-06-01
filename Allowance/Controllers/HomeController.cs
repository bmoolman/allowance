using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allowance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Allowance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILedgerRespository _ledgerRepository;
        private readonly IDateTime _dateTime;

        public HomeController(ILedgerRespository ledgerRepository, IDateTime dateTime)
        {
            _ledgerRepository = ledgerRepository;
            _dateTime = dateTime;
        }

        [HttpPost]
        public IActionResult NewTransAjax(IFormCollection fc)
        {
            return Json("OK");
        }

       


        // GET: /<controller>/
        public IActionResult Index()
        {

            var serverTime = _dateTime.Now;
            if (serverTime.Hour < 12)
            {
                ViewData["Message"] = "It's morning here - Good Morning!";
            }
            else if (serverTime.Hour < 17)
            {
                ViewData["Message"] = "It's afternoon here - Good Afternoon!";
            }
            else
            {
                ViewData["Message"] = "It's evening here - Good Evening!";
            }

            ViewData["Message"] += $" {_dateTime.Now.ToString()}";
            return View();
        }

        public IActionResult Details(int Id)
        {
            var ledgerTransactions = _ledgerRepository.GetAllLedgerTransactions(Id);
            if (ledgerTransactions==null)
            {
                return NotFound();
            }
            return View(ledgerTransactions);
        }
    }
}
