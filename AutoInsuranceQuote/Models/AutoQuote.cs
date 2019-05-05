using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AutoInsuranceQuote.Models.AutoQuote))]

namespace AutoInsuranceQuote.Models
{
    public class AutoQuote
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool DUI { get; set; }
        public int Tickets { get; set; }
        public bool Coverage { get; set; }
    }
}
