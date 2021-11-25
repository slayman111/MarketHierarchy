using MarketConsole.Enums;
using System;
using System.Collections.Generic;

namespace MarketConsole.Classes
{
    public class Client : Person
    {
        public int Discount { get; set; }
        public List<Order> Orders { get; set; }

        public Client() : base()
        {
            Role = Role.Client;
            Discount = 0;
            Orders = new List<Order>();
        }

        public Client(string name, string surname, string passportData, string adress, string email, Dictionary<Person, List<string>> personalMessages,
            int discount, List<Order> orders) : base(name, surname, passportData, adress, email, personalMessages)
        {
            Role = Role.Client;
            Discount = discount;
            Orders = orders;
        }

        public Order CreateOrder(List<string> items)
        {
            var order = new Order
            {
                DateOfCreating = DateTime.Now,
                Client = new Client(Name, Surname, PassportData, Adress, Email, PersonalMessages, Discount, Orders),
                Status = Status.New,
                Items = items
            };

            Orders.Add(order);

            return order;
        }

        public override string ToString()
        {
            string orders = "\nClient orders:";
            foreach (var order in Orders)
                orders += $"\n{order}";
            return base.ToString() +$"\nDiscount: {Discount} {orders}";
        }
    }
}
