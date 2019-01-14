using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AFS.Payment.DataAccess;

namespace AFS.Payment.Models
{
    public class OrderModel
    {
        private readonly Order _order;
        public OrderModel(Order order)
        {
            _order = order;
        }

        [Display(Name = "Full name")] public string Fullname => $"{_order.FirstName} {_order.LastName}";
        public decimal Total => _order.Total;
        public IEnumerable<Item> Items => _order.Items;
    }
}