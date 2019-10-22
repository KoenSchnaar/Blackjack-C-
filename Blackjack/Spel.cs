using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Extensions;

namespace Blackjack
{
    class Spel
    {
        private Speler speler = new Speler();
        private DeckKaarten deck = new DeckKaarten();

        public void SpelStarten()
        {
            var kaarten = deck.KaartspelMaken();
            
            for (int i = 0; i < 52; i++)
            {
                speler.Waarde += kaarten[i].Nummer;
                Console.WriteLine(speler.Waarde);
                Console.ReadKey(true);

            }
            

        }
    }
}
