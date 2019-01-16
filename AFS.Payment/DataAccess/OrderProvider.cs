using System;
using System.Data.Entity;
using System.Linq;

namespace AFS.Payment.DataAccess
{
    public class OrderProvider
    {
        public virtual Order GetBy(Guid orderId)
        {
            using (var context = new PaymentContext())
                return context.Set<Order>().SingleOrDefault(o => o.Id == orderId);
        }

        public virtual Order GetBy(Guid orderId, DateTime dateOfBirth)
        {
            using (var context = new PaymentContext())
                return context.Set<Order>().Include(o => o.Items).SingleOrDefault(o =>
                    o.Id == orderId && dateOfBirth.Date == DbFunctions.TruncateTime(o.DateOfBirth));
        }

        public virtual void SaveStatus(Order order)
        {
            using (var context = new PaymentContext())
            {
                context.Set<Order>().Single(o => o.Id == order.Id).Status = order.Status;
                context.SaveChanges();
            }
        }

        public virtual Order GetRandom()
        {
            using (var context = new PaymentContext())
                return context.Set<Order>().OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }
    }
}