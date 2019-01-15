using System;
using AFS.Payment.DataAccess;

namespace AFS.Payment.Models
{
    public class GenerateLinkModel
    {
        private readonly Order _order;

        public GenerateLinkModel(Order order)
        {
            _order = order;
        }

        public Guid OrderId => _order.Id;
        public DateTime DateOfBirth => _order.DateOfBirth;
    }
}