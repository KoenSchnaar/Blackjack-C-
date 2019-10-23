using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    class Program
    {
        static void Main()
        {
            var spel = new Spel();
            spel.OnMessage += IncomingMessage;
            spel.SpelAanmaken();
        }

        static void IncomingMessage(string message)
        { Console.WriteLine(message); }
    }
}
