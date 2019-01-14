using AFS.Payment.Models.CardValidator;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture, Explicit]
    class BinCodesValidatorTests
    {
        [Test]
        public void CardFound()
        {
            bool cardFound = false;
            new BinCodesValidator().Validate("1").Map(c => cardFound = true);
            Assert.IsTrue(cardFound);
        }

        [Test]
        public void CardFoundNotFound()
        {
            bool cardFound = false;
            new BinCodesValidator().Validate("abc").Map(c => cardFound = true);
            Assert.IsFalse(cardFound);
        }
    }
}
