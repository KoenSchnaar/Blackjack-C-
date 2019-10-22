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

            while (speler.LaatsteKaartGepakt != true)
            {
                
                ConsoleKeyInfo result = Console.ReadKey(true);
                if (result.KeyChar == 'k')
                {
                    KaartTrekken();
                }

                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        public void KaartTrekken()
        {
            int i = 0;
            var kaarten = deck.KaartspelMaken();

            speler.Waarde += kaarten[i].Nummer;
            Console.WriteLine("Je hebt een " + kaarten[i] + " gepakt. De waarde van je hand is nu " + speler.Waarde);
            i += 1;
        }
    }
}
