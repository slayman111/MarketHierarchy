using MarketConsole.Enums;
using MarketConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketConsole.Classes
{
    public class Director : Employee, IEmployee
    {
        public List<MoneyReport> Accruals { get; set; }

        public Director() : base()
        {
            Role = Role.Director;
            Accruals = new List<MoneyReport>();
        }

        public Director(string name, string surname, string passportData, string adress, string email, Dictionary<Person, List<string>> personalMessages,
            string login, string password, decimal salary, List<MoneyReport> accruals)
            : base(name, surname, passportData, adress, email, personalMessages, login, password, salary)
        {
            Role = Role.Director;
            Accruals = accruals;
        }

        public void SetWages(ref Employee employee)
        {
            employee.PrintData();
            Console.Write("Enter new employee salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            employee.Salary = salary;
            Accruals.Add(new MoneyReport($"{employee.Name} {employee.Surname}", salary));
        }

        public async Task GenerateReport(List<Person> persons)
        {
            List<MoneyReport> accruals = new List<MoneyReport>();
            foreach (var person in persons)
                if (person is Employee) accruals.Add(new MoneyReport($"{person.Name} {person.Surname}", (person as Employee).Salary));

            Console.Write("Enter file name: ");
            using (FileStream fs = new FileStream(Console.ReadLine() + ".json", FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                await JsonSerializer.SerializeAsync(fs, accruals, options);
            }
        }

        public override string ToString()
        {
            string accruals = "Director accruals:";
            foreach (var payment in Accruals)
                accruals += $"\n{payment.EmployeeName} - {payment.Calculation}";
            return base.ToString() + $"\n{accruals}";
        }
    }
}
