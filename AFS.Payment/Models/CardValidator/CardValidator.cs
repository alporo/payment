using AFS.Payment.Utility;

namespace AFS.Payment.Models.CardValidator
{
    public interface CardValidator
    {
        Maybe<CreditCard> Validate(string number);
    }
}