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
        private Speler dealer = new Speler();
        private DeckKaarten deck = new DeckKaarten();

        public void SpelStarten()
        {
            int kaartnummer = 1;
            var kaarten = deck.KaartspelMaken();
            KaartTrekken(kaarten, 0);


            while (speler.LaatsteKaartGepakt != true)
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                if (result.KeyChar == 'k')
                {
                    KaartTrekken(kaarten, kaartnummer);
                    kaartnummer++;
                }
                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        public void KaartTrekken(List<Kaart> kaarten, int kaartnummer)
        {
            speler.Waarde += kaarten[kaartnummer].Nummer;
            Console.WriteLine("Je hebt een " + kaarten[kaartnummer] + " gepakt. De waarde van je hand is nu " + speler.Waarde);
        }
    }
}
