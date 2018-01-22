using ExpenseTracker.DTO;
using ExpenseTracker.WebClient.Helpers;
using ExpenseTracker.WebClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.WebClient.Controllers
{
    public class ExpenseGroupController : Controller
    {
        // GET: ExpenseGroup

        public async Task<ActionResult> Index()
        {
            var client = ExpenseTrackerHttpClient.GetClient();

            var model = new ExpenseGroupsViewModel();

            var egsResponse = await client.GetAsync("api/expensegroupstatusses");

            if (egsResponse.IsSuccessStatusCode)
            {
                string egsContent = await egsResponse.Content.ReadAsStringAsync();
                var lstExpenseGroupStatusses = JsonConvert
                    .DeserializeObject<IEnumerable<ExpenseGroupStatus>>(egsContent);

                model.ExpenseGroupStatusses = lstExpenseGroupStatusses;
            }
            else
            {
                return Content("An error occurred.");
            }


            HttpResponseMessage response = await client.GetAsync("api/expensegroups");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var lstExpenseGroups = JsonConvert.DeserializeObject<IEnumerable<ExpenseGroup>>(content);

                model.ExpenseGroups = lstExpenseGroups;

            }
            else
            {
                return Content("An error occurred.");
            }


            return View(model);

        }
    }
}