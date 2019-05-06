using AutoInsuranceQuote.Models;
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
                int plusAge = 0;
                {
                    int age = CalculateAge(Convert.ToDateTime(dateOfBirth));
                    if (age < 25)
                        plusAge = plusAge + 25;
                    else if (age < 18)
                        plusAge = plusAge + 100;
                    else if (age > 100)
                        plusAge = plusAge + 25;
                }

                int plusCarYear = 0;
                {
                    if (Convert.ToInt32(carYear) < 2000)
                        plusCarYear = plusCarYear + 25;
                    else if (Convert.ToInt32(carYear) > 2015)
                        plusCarYear = plusCarYear + 25;
                }

                int plusCarMake = 0;
                {
                    string carmake = carMake.ToLower();
                    if (carmake == "porsche")
                        plusCarMake = plusCarMake + 25;
                }

                int plusCarModel = 0;
                {
                    string carmodel = carModel.ToLower();
                    if (carmodel == "911 carrera" || carmodel == "carrera" || carmodel == "911")
                        plusCarModel = plusCarModel + 25;
                }

                int plusTickets = 0;
                int ticket = Convert.ToInt32(tickets);
                {
                    if (ticket > 0)
                        plusTickets = ticket * 10;
                }

                int total = plusAge + plusCarYear + plusCarMake + plusCarModel + plusTickets;
                double num1 = Convert.ToDouble(total);
                {
                    if (Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), DUI)) == true)
                        num1 = (num1 * 0.25) + num1;
                }
                double num2 = Convert.ToDouble(total);
                {
                    if (Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), coverage)) == true)
                        num2 = (num2 * 0.5) + num2;
                }
                double totalQuote = 50 + total + num1 + num2;

                using (AutoInsuranceQuoteEntities db = new AutoInsuranceQuoteEntities())
                {
                    var autoquote = new AutoQuote
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress = emailAddress,
                        DateOfBirth = Convert.ToDateTime(dateOfBirth),
                        CarYear = Convert.ToInt32(carYear),
                        CarMake = carMake,
                        CarModel = carModel,
                        DUI = Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), DUI)),
                        Tickets = Convert.ToByte(tickets),
                        Coverage = Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), coverage)),
                        Quote = Convert.ToInt32(totalQuote)
                    };

                    db.AutoQuotes.Add(autoquote);
                    db.SaveChanges();
                }

                ViewBag.Message = "$ " + totalQuote + " / month";
                return View("Success");
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            return age;
        }

        public enum BooleanAliases
        {
            Yes = 1,
            No = 0
        }
    }
}