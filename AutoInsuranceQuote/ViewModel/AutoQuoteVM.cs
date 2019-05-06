using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoInsuranceQuote.ViewModel
{
    public class AutoQuoteVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Quote { get; set; }
    }
}