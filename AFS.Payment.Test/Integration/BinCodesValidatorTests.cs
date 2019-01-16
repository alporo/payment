using AFS.Payment.BusinessObjects.CardValidation;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture]
    class BinCodesValidatorTests
    {
        [TestCase("5157359818590564", "Invalid API Key.")]
        [TestCase("abc", "Invalid Credit Card or Debit Card Number")]
        public void Validate(string input, string expected) => Assert.AreEqual(expected,
            new BinCodesValidator().Validate(input).ErrorMessage);
    }
}