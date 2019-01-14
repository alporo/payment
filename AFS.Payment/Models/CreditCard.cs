using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using AFS.Payment.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AFS.Payment.Models
{
    public class CreditCard
    {
        private readonly string _number;

        public CreditCard(string number)
        {
            _number = number;
        }
    }
}