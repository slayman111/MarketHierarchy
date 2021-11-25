using MarketConsole.Enums;
using MarketConsole.Interfaces;
using System.Collections.Generic;

namespace MarketConsole.Classes
{
    public class Person : IChat
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        protected string PassportData { get; set; }
        protected string Adress { get; set; }
        protected string Email { get; set; }
        public Dictionary<Person, List<string>> PersonalMessages { get; set; }
        public Role Role { get; set; }

        public Person()
        {
            Name = "";
            Surname = "";
            PassportData = "";
            Adress = "";
            Email = "";
            PersonalMessages = new Dictionary<Person, List<string>>();
            Role = Role.Visitor;
        }

        public Person(string name, string surname, string passportData, string adress, string email, 
            Dictionary<Person, List<string>> personalMessages)
        {
            Name = name;
            Surname = surname;
            PassportData = passportData;
            Adress = adress;
            Email = email;
            PersonalMessages = personalMessages;
            Role = Role.Visitor;
        }

        public void SendMessage(ref Person person, string message)
        {
            if (!person.PersonalMessages.ContainsKey(this)) 
                person.PersonalMessages.Add(this, new List<string>());
            person.PersonalMessages[this].Add(message);
        }

        public override string ToString() => $"Name: {Name}\nSurname: {Surname}\nPassportData: {PassportData}" +
            $"\nAdress: {Adress}\nEmail: {Email}Role: {Role}";

        public void PrintData() => System.Console.WriteLine(ToString());
    }
}
