using System;
using System.Net.Http;
using AFS.Payment.Utility;
using Newtonsoft.Json;

namespace AFS.Payment.Models.CardValidator
{
    public class BinCodesValidator : CardValidator
    {
        private readonly string _api;

        public BinCodesValidator(string api)
        {
            _api = api;
        }

        public BinCodesValidator() : this("https://jsonplaceholder.typicode.com/todos/")
        {
        }

        public Maybe<CreditCard> Validate(string number)
        {
            Response response = new Response();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                    response = JsonConvert.DeserializeObject<Response>(httpClient.GetStringAsync(new Uri($"{_api}{number}")).Result);
                    
                }
            }
            catch (Exception e)
            {
                //TODO: log exception
            }
            return response.CreateCard();
        }
    }

    class Response
    {
        public int? UserId { get; set; }
        public int? Id { get; set; }
        public string Title { get; set; }
        public bool? Completed { get; set; }

        public Maybe<CreditCard> CreateCard() => UserId.HasValue
            ? new CreditCard(Title).AsMaybe()
            : Maybe<CreditCard>.None();
    }
}