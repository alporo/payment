using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using AFS.Payment.DataAccess;
using AFS.Payment.Utility;

namespace AFS.Payment.BusinessObjects
{
    public class Orders
    {
        private readonly PaymentContext _context;

        private DbSet<Order> OrderSet => _context.Set<Order>();

        public Orders(PaymentContext context)
        {
            _context = context;
        }

        public Orders() : this(new PaymentContext())
        {
        }

        public Option<Order> GetBy(Guid orderId) => OrderSet.SingleOrDefault(o => o.Id == orderId).AsOption();
        public Option<Order> View(Guid orderId, DateTime dateOfBirth)
            => OrderSet.Include(o => o.Items).SingleOrDefault(o =>
                    o.Id == orderId && dateOfBirth.Date == DbFunctions.TruncateTime(o.DateOfBirth))
                .AsOption().Map(Viewed);

        private Order Viewed(Order order)
        {
            if (order.Status == OrderStatus.New)
                order.Status = order.Status;
            OrderSet.AddOrUpdate();
            _context.SaveChanges();
            return order;
        }

        public Option<Order> GetRandom() => OrderSet.OrderBy(o => Guid.NewGuid()).FirstOrDefault().AsOption();
    }
}