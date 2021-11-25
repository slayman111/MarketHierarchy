using System;

namespace MarketConsole.Classes
{
    public class MoneyReport
    {
        public string EmployeeName { get; set; }
        public decimal Calculation { get; set; }
        public DateTime Date { get; set; }

        public MoneyReport()
        {
            EmployeeName = "";
            Calculation = 0;
            Date = DateTime.MinValue;
        }

        public MoneyReport(string name, decimal payment)
        {
            EmployeeName = name;
            Calculation = payment;
            Date = DateTime.Now;
        }

        public override string ToString() => $"Employee name: {EmployeeName} - Calculation: {Calculation}";

        public void PrintData() => System.Console.WriteLine(ToString());
    }
}
