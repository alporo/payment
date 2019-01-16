using System;
using System.Collections.Generic;
using AFS.Payment.DataAccess;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture]
    public class OrderProviderTests
    {
        [Test]
        public void GetById() =>
            Assert.AreEqual("Sparrow",
                new OrderProvider().GetBy(new Guid("7BC69EB6-805F-45DB-8B7F-89B3E7580549")).LastName);

        [Test]
        public void GetByIdAndDate() =>
            Assert.AreEqual("Sparrow", new OrderProvider().GetBy(new Guid("7BC69EB6-805F-45DB-8B7F-89B3E7580549"),
                new DateTime(1963, 6, 9)).LastName);

        [Test]
        public void GetRandom()
        {
            var set = new HashSet<Guid>();
            for (var i = 0; i < 30; i++)
                set.Add(new OrderProvider().GetRandom().Id);
            Assert.IsTrue(set.Count > 1);
        }

        [Test, Explicit("Can potentially change database state")]
        public void SaveStatus()
        {
            var orderId = new Guid("7BC69EB6-805F-45DB-8B7F-89B3E7580549");
            var provider = new OrderProvider();
            var initialStatus = provider.GetBy(orderId).Status;
            var newStatus = initialStatus != OrderStatus.Paid ? OrderStatus.Paid : OrderStatus.Viewed;
            var order = new Order{Id = orderId, Status = newStatus };
            provider.SaveStatus(order);
            Assert.AreEqual(newStatus, provider.GetBy(orderId).Status);

            // roll back
            order.Status = initialStatus;
            provider.SaveStatus(order);
            Assert.AreEqual(initialStatus, provider.GetBy(orderId).Status);
        }
    }
}