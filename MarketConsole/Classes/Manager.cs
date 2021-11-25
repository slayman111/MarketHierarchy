using MarketConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using MarketConsole.Enums;

namespace MarketConsole.Classes
{
    public class Manager : Employee, IEmployee
    {
        public Manager() => Role = Role.Manager;

        public void ProcessOrder(ref Order order)
        {
            order.PrintData();
            Console.WriteLine("1 - Processing");
            Console.WriteLine("2 - Denied");
            Console.WriteLine("3 - Finished");
            Console.Write("Enter key to change order status: ");

            switch (Convert.ToByte(Console.ReadLine()))
            {
                case 1:
                    {
                        order.Status = Status.Processing;
                        Console.WriteLine("Order processing.");
                    }
                    break;
                case 2:
                    {
                        order.Status = Status.Denied;
                        Console.WriteLine("Order denied.");
                    }
                    break;
                case 3:
                    {
                        order.Status = Status.Finished;
                        Console.WriteLine("Order finished.");
                    }
                    break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        public async Task GenerateReport(List<Person> persons)
        {
            List<Order> orders = new List<Order>();
            foreach (var person in persons)
                if (person is Client)
                    foreach (var order in (person as Client).Orders)
                        orders.Add(order);

            Console.Write("Enter file name: ");
            using (FileStream fs = new FileStream(Console.ReadLine() + ".json", FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync(fs, orders, options);
            }
        }
    }
}
