using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AFS.Payment.DataAccess;
using AFS.Payment.Utility;

namespace AFS.Payment.BusinessObjects
{
    public class Orders
    {
        private readonly IEnumerable<Order> _orders;

        public Orders(IEnumerable<Order> orders)
        {
            _orders = orders;
        }

        public Orders() : this(AllOrders())
        {
        }

        private static IEnumerable<Order> AllOrders()
        {
            using (var context = new PaymentContext())
            {
                return context.Set<Order>().Include(o => o.Items).ToList();
            }
        }

        public Option<Order> GetBy(Guid orderId) => _orders.SingleOrDefault(o => o.Id == orderId).AsOption();

        // DbFunctions work well with LINQ to SQL but throw exception on LINQ to Entities
        //public Option<Order> GetBy(WelcomeModel welcomeModel) => _orders
        //    .SingleOrDefault(o => o.Id == welcomeModel.Id &&
        //                          DbFunctions.TruncateTime(o.DateOfBirth) == welcomeModel.GetDateOfBirth()).AsOption();

        // this date check is a disaster, but works both with LINQ to SQL and Entities, thanks Microsoft
        public Option<Order> GetBy(Guid orderId, DateTime dateOfBirth) => _orders
            .SingleOrDefault(o => o.Id == orderId && dateOfBirth.Date <= o.DateOfBirth &&
                                  dateOfBirth.AddDays(1).Date > o.DateOfBirth).AsOption();
    }
}