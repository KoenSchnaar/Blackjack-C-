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
            var EersteKaart = KaartTrekken(kaarten, 0, dealer);
            Console.WriteLine("De dealer heeft een " + EersteKaart + " gepakt. " + dealer.Waarde);


            while (speler.LaatsteKaartGepakt != true)
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                if (result.KeyChar == 'k')
                {
                    var GepakteKaart = KaartTrekken(kaarten, kaartnummer, speler);
                    Console.WriteLine("Je hebt een " + GepakteKaart + " gepakt. De waarde van je hand is nu " + speler.Waarde);
                    kaartnummer++;
                }
                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        public Kaart KaartTrekken(List<Kaart> kaarten, int kaartnummer, Speler speler)
        {
            speler.Waarde += kaarten[kaartnummer].Nummer;
            return kaarten[kaartnummer];
        }
    }
}
