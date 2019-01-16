using System.Collections.Generic;
using System.Linq;

namespace AFS.Payment.BusinessObjects.CardValidation
{
    public class ValidationResult
    {
        public static readonly IEnumerable<string> SupportedCards = new[] {"VISA", "MASTERCARD", "AMERICANEXPRESS"};

        public ValidationResult(string cardNumber, string card, bool valid, string error)
        {
            CardNumber = cardNumber;
            Card = card;
            Valid = valid;
            Error = error;
        }

        public string CardNumber { get; }
        public string Card { get; }
        public bool Valid { get; }
        public string Error { get; }
        public bool Supported => SupportedCards.Contains(Card.ToUpper());
        public bool PaymentSuccessful => string.IsNullOrEmpty(Error) && Valid && Supported;

        public static ValidationResult ApiNoResponse(string number) =>
            new ValidationResult(number, string.Empty, false, "API no response");
    }
}