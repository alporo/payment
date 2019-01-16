using System.Collections.Generic;
using AFS.Payment.DataAccess;

namespace AFS.Payment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                    Id = new Guid("6F2DEBE0-F1DE-441F-9E7C-1CDF7C460AED"),
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
                    Id = new Guid("7BC69EB6-805F-45DB-8B7F-89B3E7580549"),
                    //time is set here for testing purposes
                    DateOfBirth = new DateTime(1963 , 6, 9, 10, 10, 10),
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
