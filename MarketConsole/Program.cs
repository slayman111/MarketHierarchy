using MarketConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole
{
    class Program
    {
        static void Main()
        {
            Execute();
        }

        private async static void Execute()
        {
            try
            {
                Person person1 = new Person();
                Person person2 = new Person();
                person1.SendMessage(ref person2, "aaa");
                person1.SendMessage(ref person2, "bbb");
                foreach(var item in person2.PersonalMessages.Values)
                    foreach (var item1 in item)
                        Console.WriteLine(item1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
