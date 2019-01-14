using System;
using AFS.Payment.Properties;
using AFS.Payment.Utility;

namespace AFS.Payment.BusinessObjects.CardValidator
{
    public class BinCodesValidator : CardValidator
    {
        private string ApiRequest(string number) =>
            $"https://api.bincodes.com/cc/?format=json&api_key={Settings.Default.BinCodesApiKey}&cc={number}";


        public override Option<CreditCard> Validate(string number)
        {
            throw new NotImplementedException();
        }
    }

    
}