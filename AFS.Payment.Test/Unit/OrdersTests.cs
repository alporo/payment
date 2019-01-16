using System;
using AFS.Payment.BusinessObjects;
using AFS.Payment.DataAccess;
using Moq;
using NUnit.Framework;

namespace AFS.Payment.Test.Unit
{
    [TestFixture]
    public class OrdersTests
    {
        [Test]
        public void OrderById()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetBy(It.IsAny<Guid>())).Returns(new Order());
            Assert.IsTrue(new Orders(provider.Object).GetBy(Guid.NewGuid()).HasValue());
        }

        [Test]
        public void OrderByIdNotFound()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetBy(It.IsAny<Guid>())).Returns(null as Order);
            Assert.IsFalse(new Orders(provider.Object).GetBy(Guid.NewGuid()).HasValue());
        }

        [Test]
        public void ViewUpdatesStatus()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetBy(It.IsAny<Guid>(), It.IsAny<DateTime>()))
                .Returns(new Order { Status = OrderStatus.New });
            var status = new Orders(provider.Object).View(Guid.NewGuid(), DateTime.Now)
                .Map(o => o.Status as OrderStatus?).OrElse(null);
            Assert.AreEqual(OrderStatus.Viewed, status);
        }

        [Test]
        public void ViewDoesNotUpdatePaidStatus()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetBy(It.IsAny<Guid>(), It.IsAny<DateTime>()))
                .Returns(new Order { Status = OrderStatus.Paid });
            var status = new Orders(provider.Object).View(Guid.NewGuid(), DateTime.Now)
                .Map(o => o.Status as OrderStatus?).OrElse(null);
            Assert.AreEqual(OrderStatus.Paid, status);
        }

        [Test]
        public void ReturnRandom()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetRandom()).Returns(new Order());
            Assert.IsTrue(new Orders(provider.Object).GetRandom().HasValue());
        }

        [Test]
        public void ReturnRandomNothing()
        {
            var provider = new Mock<OrderProvider>();
            provider.Setup(p => p.GetRandom()).Returns(null as Order);
            Assert.IsFalse(new Orders(provider.Object).GetRandom().HasValue());
        }
    }
}