using System;
using System.Linq;
using AFS.Payment.BusinessObjects;
using AFS.Payment.DataAccess;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CreateLink()
        {
            using (var context = new PaymentContext())
            {
                var order = context.Orders.OrderBy(o => Guid.NewGuid()).First();
                Console.WriteLine("http://localhost:61837/payment/welcome/" + order.Id);
            }
        }

        [Test]
        public void SearchOrderByModel() =>
            Assert.IsTrue(new Orders()
                .GetBy(new Guid("6F2DEBE0-F1DE-441F-9E7C-1CDF7C460AED"), new DateTime(1980, 2, 23)).HasValue());
    }
}