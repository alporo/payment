using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AFS.Payment.DataAccess
{
    public class Order
    {
        // and yes, I prefer Guid over int as ID
        public Guid Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Total { get; set; }
        [DefaultValue(OrderStatus.New)]
        public OrderStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Viewed,
        Paid,
    }
}