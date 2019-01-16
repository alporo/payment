namespace AFS.Payment.BusinessObjects.CardValidation
{
    public interface CardValidator
    {
        ValidationResult Validate(string number);
    }
}