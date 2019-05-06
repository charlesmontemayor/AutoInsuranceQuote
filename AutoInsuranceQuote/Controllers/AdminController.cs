using AutoInsuranceQuote.Models;
using AutoInsuranceQuote.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoInsuranceQuote.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (AutoInsuranceQuoteEntities db = new AutoInsuranceQuoteEntities())
            {
                var autoquotes = db.AutoQuotes;
                var autoquoteVMs = new List<AutoQuoteVM>();
                foreach (var autoquote in autoquotes)
                {
                    var autoquoteVM = new AutoQuoteVM
                    {
                        Id = autoquote.Id,
                        FirstName = autoquote.FirstName,
                        LastName = autoquote.LastName,
                        EmailAddress = autoquote.EmailAddress,
                        Quote = Convert.ToInt32(autoquote.Quote)
                    };
                    autoquoteVMs.Add(autoquoteVM);
                }
                return View(autoquoteVMs);
            }
        }

        public ActionResult Delete(int Id)
        {
            using (AutoInsuranceQuoteEntities db = new AutoInsuranceQuoteEntities())
            {
                var person = db.AutoQuotes.Find(Id);
                db.AutoQuotes.Remove(person);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}