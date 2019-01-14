using System;
using System.Linq;
using AFS.Payment.Data;
using NUnit.Framework;

namespace AFS.Payment.Test.Integration
{
    [TestFixture,Explicit]
    public class OrderTests
    {
        [Test]
        public void CreateLink()
        {
            using (var context = new PaymentContext())
            {
                var order = context.Orders.First();
                Console.WriteLine("http://localhost:61837/payment/welcome/" + order.Id);
                Assert.AreEqual(true, true);
            }
        }
    }
}
