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
        int Kaartnummer = 0;

        public void SpelStarten()
        {
            var kaarten = deck.KaartspelMaken();
            //dealer pakt eerste kaart
            var EersteKaart = KaartTrekken(kaarten, Kaartnummer, dealer);
            Console.WriteLine("De dealer heeft een " + EersteKaart + " gepakt. " + dealer.Waarde);


            
            while (speler.LaatsteKaartGepakt != true)
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                if (result.KeyChar == 'k')
                {
                    if (speler.EersteBeurt)
                    {
                        Kaart kaart1 = KaartTrekken(kaarten, Kaartnummer, speler);
                        Kaart kaart2 = KaartTrekken(kaarten, Kaartnummer, speler);
                        Console.WriteLine("je hebt een " + kaart1 + "en een " + kaart2 + " gepakt. De waarde van je hand is " + speler.Waarde);
                        speler.EersteBeurt = false;
                    }
                    else
                    {
                        var GepakteKaart = KaartTrekken(kaarten, Kaartnummer, speler);
                        Console.WriteLine("Je hebt een " + GepakteKaart + " gepakt. De waarde van je hand is nu " + speler.Waarde);
                    }
                }
                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        private Kaart KaartTrekken(List<Kaart> kaarten, int kaartnummer, Speler speler)
        {
            speler.Waarde += kaarten[kaartnummer].Nummer;
            Kaartnummer++;
            return kaarten[kaartnummer];
        }

        private void CheckRegels(int HandWaarde)
        {
            if (HandWaarde < 21)
            {

            }
            else if (HandWaarde == 21)
            {

            }
        }
    }
}
