namespace AFS.Payment.BusinessObjects.CardValidation
{
    public class AlwaysValidValidator : CardValidator
    {
        public ValidationResult Validate(string number) => new ValidationResult(number, "VISA", true, string.Empty);
    }
}