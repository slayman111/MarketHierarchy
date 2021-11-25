using MarketConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MarketConsole.Enums;
using System.Text.Json;

namespace MarketConsole.Classes
{
    public class Accountant : Employee, IEmployee
    {
        public List<MoneyReport> Payments { get; set; }

        public Accountant() : base()
        {
            Role = Role.Accountant;
            Payments = new List<MoneyReport>();
        }

        public Accountant(string name, string surname, string passportData, string adress, string email, Dictionary<Person, List<string>> personalMessages,
            string login, string password, decimal salary, List<MoneyReport> payments)
            : base(name, surname, passportData, adress, email, personalMessages, login, password, salary)
        {
            Role = Role.Accountant;
            Payments = payments;
        }

        public void PaySalary(ref Employee employee)
        {
            employee.PrintData();
            Console.Write("Give out a salary? (Y/N): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                Payments.Add(new MoneyReport($"{employee.Name} {employee.Surname}", employee.Salary));
            else Console.Write("\nOperation cancelled.");
            Console.WriteLine();
        }

        public async Task GenerateReport(List<Person> persons = null)
        {
            List<MoneyReport> payments = new List<MoneyReport>();
            foreach (var payment in Payments)
                payments.Add(payment);

            Console.Write("Enter file name: ");
            using (FileStream fs = new FileStream(Console.ReadLine() + ".json", FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                await JsonSerializer.SerializeAsync(fs, payments, options);
            }
        }

        public override string ToString()
        {
            string payments = "Accountant payments:";
            foreach (var payment in Payments)
                payments += $"\n{payment.EmployeeName} - {payment.Calculation}";
            return base.ToString() + $"\n{payments}";
        }
    }
}
