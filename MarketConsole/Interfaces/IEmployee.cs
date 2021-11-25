using MarketConsole.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketConsole.Interfaces
{
    public interface IEmployee
    {
        Task GenerateReport(List<Person> persons);
    }
}
