using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public void SearchOrderByModel() =>
            Assert.IsTrue(new Orders()
                .View(new Guid("6F2DEBE0-F1DE-441F-9E7C-1CDF7C460AED"), new DateTime(1980, 2, 23)).HasValue());
        
    }
}