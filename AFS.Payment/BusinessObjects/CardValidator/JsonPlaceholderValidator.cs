using System;
using AFS.Payment.Utility;
using Newtonsoft.Json;

namespace AFS.Payment.BusinessObjects.CardValidator
{
    public class JsonPlaceholderValidator : CardValidator
    {
        private string ApiRequest(string number) => $"https://jsonplaceholder.typicode.com/users/{number}";

        public override Option<CreditCard> Validate(string number)
        {
            Response response = null;
            try
            {
                response = JsonConvert.DeserializeObject<Response>(GetResponse(ApiRequest(number)));
            }
            catch (Exception e)
            {
                //TODO: log exception
            }

            return response.AsOption().Map(c => c.CreateCard());
        }

        class Response
        {
            public int? Id { get; set; }
            public string Name { get; set; }
            public string Website { get; set; }
            public string Phone { get; set; }

            public Option<CreditCard> CreateCard() => Id.HasValue
                ? new CreditCard(Phone, Name, Website, Id > 10).AsOption()
                : new None<CreditCard>();
        }
    }
}