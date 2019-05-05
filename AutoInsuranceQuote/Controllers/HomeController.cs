using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInsuranceQuote.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutoQuote(string firstName, 
            string lastName, 
            string emailAddress, 
            string dateOfBirth, 
            string carYear, 
            string carMake, 
            string carModel, 
            string DUI, 
            string tickets, 
            string coverage)
        {
            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(emailAddress) ||
                string.IsNullOrEmpty(dateOfBirth) ||
                string.IsNullOrEmpty(carYear) ||
                string.IsNullOrEmpty(carMake) ||
                string.IsNullOrEmpty(carModel) ||
                string.IsNullOrEmpty(DUI) ||
                string.IsNullOrEmpty(tickets) ||
                string.IsNullOrEmpty(coverage))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                return View("Success");
            }

        }
    }
}