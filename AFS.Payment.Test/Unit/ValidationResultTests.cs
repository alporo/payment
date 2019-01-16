using AFS.Payment.BusinessObjects.CardValidation;
using NUnit.Framework;

namespace AFS.Payment.Test.Unit
{
    [TestFixture]
    public class ValidationResultTests
    {
        [TestCase("VISA", true)]
        [TestCase("AMERICANEXPRESS", true)]
        [TestCase("MASTERCARD", true)]
        [TestCase("visa", true)]
        [TestCase("MASTER CARD", false)]
        [TestCase("abc", false)]
        public void SupportedCards(string card, bool supported) =>
            Assert.AreEqual(supported, new ValidationResult("", card, false, "").Supported);

        [Test]
        public void NoErrorButInvalidCardMessage() => Assert.AreEqual("Credit card is invalid",
            new ValidationResult("", "", false, "").ErrorMessage);

        [Test]
        public void NoErrorValidButNotSupportedCardMessage() => Assert.AreEqual("abc is not supported",
            new ValidationResult("", "abc", true, "").ErrorMessage);

        [Test]
        public void NoErrorValidButNotSupportedCardMessageDoesNotCareAboutNull() => Assert.AreEqual(" is not supported",
            new ValidationResult("", null, true, "").ErrorMessage);

        [Test]
        public void NoApiResponse()
        {
            var result = ValidationResult.ApiNoResponse("123");
            Assert.IsFalse(result.PaymentSuccessful);
            Assert.IsFalse(result.Supported);
            Assert.IsFalse(result.Valid);
            Assert.AreEqual(string.Empty,result.Card);
            Assert.AreEqual("API no response", result.ErrorMessage);
        }
    }
}