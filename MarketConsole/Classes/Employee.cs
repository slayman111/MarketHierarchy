using System.Collections.Generic;

namespace MarketConsole.Classes
{
    public class Employee : Person
    {
        protected string Login { get; set; }
        protected string Password { get; set; }
        public decimal Salary { get; set; }

        public Employee() : base()
        {
            Login = "";
            Password = "";
            Salary = 0;
        }

        public Employee(string name, string surname, string passportData, string adress, string email, Dictionary<Person, List<string>> personalMessages,
            string login, string password, decimal salary) : base(name, surname, passportData, adress, email, personalMessages)
        {
            Login = login;
            Password = password;
            Salary = salary;
        }

        public override string ToString() => base.ToString() + $"\nLogin: {Login}\nPassword: {Password}\nSalary: {Salary}";
    }
}
