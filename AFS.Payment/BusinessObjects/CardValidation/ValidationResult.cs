using System.Collections.Generic;
using System.Linq;

namespace AFS.Payment.BusinessObjects.CardValidation
{
    public class ValidationResult
    {
        public static readonly IEnumerable<string> SupportedCards = new[] {"VISA", "MASTERCARD", "AMERICANEXPRESS"};
        private readonly string _apiError;

        public ValidationResult(string cardNumber, string card, bool valid, string error)
        {
            CardNumber = cardNumber;
            Card = card;
            Valid = valid;
            _apiError = error;
        }

        public string CardNumber { get; }
        public string Card { get; }
        public bool Valid { get; }

        public string ErrorMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(_apiError))
                    return _apiError;
                if (!Valid)
                    return "Credit card is invalid";
                if (!Supported)
                    return $"{Card} is not supported";
                return string.Empty;
            }
        }

        public bool Supported => SupportedCards.Contains(Card?.ToUpper());
        public bool PaymentSuccessful => string.IsNullOrEmpty(_apiError) && Valid && Supported;

        public static ValidationResult ApiNoResponse(string number) =>
            new ValidationResult(number, string.Empty, false, "API no response");
    }
}