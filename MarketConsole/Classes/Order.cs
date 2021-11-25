using MarketConsole.Enums;
using System;
using System.Collections.Generic;

namespace MarketConsole.Classes
{
    public class Order
    {
        public DateTime DateOfCreating { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
        public List<string> Items { get; set; }

        public Order()
        {
            DateOfCreating = DateTime.MinValue;
            Client = new Client();
            Status = Status.Unknown;
            Items = new List<string>();
        }

        public Order(Client client, List<string> items)
        {
            DateOfCreating = DateTime.Now;
            Client = client;
            Status = Status.New;
            Items = items;
        }

        public override string ToString()
        {
            string items = "\nOrder items:";
            foreach (var item in Items)
                items += $"\n{item}";
            return $"Date of creating: {DateOfCreating}\nClient: {Client.Name} {Client.Surname}\nStatus: {Status}" +
                $"{items}";
        }

        public void PrintData() => Console.WriteLine(ToString());
    }
}
