using System;
using System.Net.Http;
using AFS.Payment.Utility;

namespace AFS.Payment.BusinessObjects.CardValidator
{
    public abstract class CardValidator
    {
        public abstract Option<CreditCard> Validate(string number);

        protected string GetResponse(string apiRequest)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                return httpClient.GetStringAsync(new Uri(apiRequest)).Result;
            }
        }
    }
}