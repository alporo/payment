using System;
using AFS.Payment.BusinessObjects;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture]
    public class OrdersTests
    {
        [Test]
        public void ParameterlessConstructorGoesToDatabase() =>
            Assert.IsTrue(new Orders().GetBy(new Guid("7BC69EB6-805F-45DB-8B7F-89B3E7580549")).HasValue());
    }
}