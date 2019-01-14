using System;
using System.Collections.Generic;
using System.Linq;

namespace AFS.Payment.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PaymentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PaymentContext context)
        {
            if (!context.Orders.Any())
                context.Orders.AddRange(DummyOrders());
            context.SaveChanges();
        }
        private static List<Order> DummyOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = new DateTime(1980, 2, 23),
                    FirstName = "John",
                    LastName = "Smith",
                    Total = 12,
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Product = "Toy",
                            Quantity = 1,
                            Price = 10,
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Product = "Candy",
                            Quantity = 2,
                            Price = 1,
                        },
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = new DateTime(1963 , 6, 9),
                    FirstName = "Jack",
                    LastName = "Sparrow",
                    Total = 12075,
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Product = "Ship",
                            Quantity = 1,
                            Price = 12000,
                        },
                        new Item
                        {
                            Id = Guid.NewGuid(),
                            Product = "Black flag",
                            Quantity = 5,
                            Price = 15,
                        },
                    }
                },
            };
        }
    }
}
