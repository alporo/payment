using System;
using AFS.Payment.DataAccess;
using AFS.Payment.Utility;

namespace AFS.Payment.BusinessObjects
{
    public class Orders
    {
        private readonly OrderProvider _provider;

        public Orders(OrderProvider provider)
        {
            _provider = provider;
        }

        public Orders() : this(new OrderProvider())
        {
        }

        public Option<Order> GetBy(Guid orderId) => _provider.GetBy(orderId).AsOption();
        public Option<Order> View(Guid orderId, DateTime dateOfBirth) =>
            _provider.GetBy(orderId, dateOfBirth).AsOption().Map(OrderViewed);

        private void OrderViewed(Order order)
        {
            if (order.Status != OrderStatus.New) return;
            order.Status = OrderStatus.Viewed;
            _provider.SaveStatus(order);
        }

        public Option<Order> GetRandom() => _provider.GetRandom().AsOption();
    }
}