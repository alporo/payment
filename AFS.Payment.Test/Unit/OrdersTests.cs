using System;
using System.Collections.Generic;
using AFS.Payment.BusinessObjects;
using AFS.Payment.DataAccess;
using AFS.Payment.Models;
using NUnit.Framework;

namespace AFS.Payment.Test.Unit
{
    [TestFixture]
    public class OrdersTests
    {
        [TestCase("{F51555EC-E569-4E2F-A596-6B3433928FDE}", true)]
        [TestCase("{0F874C95-014F-4F37-BD9A-D71E49C9F89F}", false)]
        public void SearchOrderById(string guid, bool expected)
        {
            var ordersDummy = new List<Order> {new Order {Id = new Guid("{F51555EC-E569-4E2F-A596-6B3433928FDE}")}};
            Assert.AreEqual(expected, new Orders(ordersDummy).GetBy(new Guid(guid)).HasValue());
        }

        [TestCase("{F51555EC-E569-4E2F-A596-6B3433928FDE}", true)]
        [TestCase("{0F874C95-014F-4F37-BD9A-D71E49C9F89F}", false)]
        public void SearchOrderByModel(string guid, bool expected)
        {
            var g = new Guid(guid);
            var ordersDummy = new List<Order>
            {
                new Order
                {
                    Id = new Guid("{F51555EC-E569-4E2F-A596-6B3433928FDE}"),
                    DateOfBirth = new DateTime(1980, 2, 23, 10, 14, 2)
                }
            };
            Assert.AreEqual(expected,
                new Orders(ordersDummy).GetBy(g, new DateTime(1980, 2, 23)).HasValue());
        }
    }
}