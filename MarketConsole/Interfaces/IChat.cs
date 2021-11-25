using MarketConsole.Classes;

namespace MarketConsole.Interfaces
{
    public interface IChat
    {
        void SendMessage(ref Person person, string message);
    }
}
