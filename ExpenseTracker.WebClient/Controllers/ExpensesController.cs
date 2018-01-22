using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.WebClient.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses
        public ActionResult Index()
        {
            return View();
        }
    }
}