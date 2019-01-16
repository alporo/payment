using System;
using System.Net.Http;
using AFS.Payment.Properties;
using Newtonsoft.Json;

namespace AFS.Payment.BusinessObjects.CardValidation
{
    public class BinCodesValidator
    {
        private string ApiRequest(string number) =>
            $"https://api.bincodes.com/cc/?format=json&api_key={Settings.Default.BinCodesApiKey}&cc={number}";


        public ValidationResult Validate(string number)
        {
            Response response;
            try
            {
                response = JsonConvert.DeserializeObject<Response>(GetResponse(ApiRequest(number)));
            }
            catch (Exception e)
            {
                //TODO: log exception
                return ValidationResult.ApiNoResponse(number);
            }

            return response.ToValidationResult(number);
        }

        public string GetResponse(string apiRequest)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                return httpClient.GetStringAsync(new Uri(apiRequest)).Result;
            }
        }

        public class Response
        {
            public string Bin { get; set; }
            public string Bank { get; set; }
            public string Card { get; set; }
            public string Type { get; set; }
            public string Level { get; set; }
            public string Country { get; set; }
            public string CountryCode { get; set; }
            public string Website { get; set; }
            public string Phone { get; set; }
            public string Valid { get; set; }
            public string Error { get; set; }
            public string Message { get; set; }

            private bool IsValid => Valid?.ToLower() == "true";
            private string ErrorWithMessage => Error != null ? $"{Error} - {Message}" : string.Empty;

            public ValidationResult ToValidationResult(string number) => new ValidationResult(number, Card, IsValid, ErrorWithMessage);
        }
    }
}