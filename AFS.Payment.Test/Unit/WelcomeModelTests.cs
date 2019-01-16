using System;
using AFS.Payment.Models;
using NUnit.Framework;

namespace AFS.Payment.Test.Unit
{
    [TestFixture]
    public class WelcomeModelTests
    {
        [Test]
        public void DateOfBirthFromTicks() =>
            Assert.AreEqual(new DateTime(2019, 1, 29),
                new WelcomeModel { DateOfBirthString = "1548712800000" }.DateOfBirth);

        [Test]
        public void DateOfBirthFromRandomStringThrowsException() =>
            Assert.That(() => new WelcomeModel { DateOfBirthString = "abc" }.DateOfBirth, Throws.Exception);
    }
}