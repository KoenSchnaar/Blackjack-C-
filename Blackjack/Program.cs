using Blackjack.Data;
using Blackjack.repository;
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
            SpelerRepository SpelerRepo = new SpelerRepository();
            UitslagenRepository UitslagRepo = new UitslagenRepository();
            foreach (speler speler in SpelerRepo.GetSpelers())
            {
                Console.WriteLine(speler.spelernaam + " Je speler ID is " + speler.speler_ID);
            }
            foreach (uitslagen uitslag in UitslagRepo.GetUitslagen())
            {
                Console.WriteLine(uitslag.speler_ID + " je banksaldo is " + uitslag.Bank);
            }
            var spel = new Spel();
            spel.OnMessage += IncomingMessage;
            spel.SpelAanmaken();
        }

        static void IncomingMessage(string message)
        { Console.WriteLine(message); }
    }
}
