using AFS.Payment.BusinessObjects.CardValidator;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture]
    class JsonPlaceholderValidatorTests
    {
        [TestCase("1", true)]
        [TestCase("abc", false)]
        public void Validate(string input, bool expected) => Assert.AreEqual(expected,
            new JsonPlaceholderValidator().Validate(input).HasValue());
    }
}