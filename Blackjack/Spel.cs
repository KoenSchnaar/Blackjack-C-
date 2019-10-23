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
            dealer.EersteKaartDealer(EersteKaart);
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
                        speler.EerstebeurtSpeler(kaart1, kaart2, speler);
                    }
                    else
                    {
                        var GepakteKaart = KaartTrekken(kaarten, Kaartnummer, speler);
                        speler.KaartVerwerken(GepakteKaart, speler);
                    }
                }
                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        public Kaart KaartTrekken(List<Kaart> kaarten, int kaartnummer, Speler speler)
        {
            Kaartnummer++;
            return kaarten[kaartnummer];
        }
        private CheckWaarden CheckRegels(int HandWaarde)
        {
            if (HandWaarde > 21)
            {
                return CheckWaarden.Af;
            }
            else if (HandWaarde == 21)
            {
                return CheckWaarden.Blackjack;
            }
            else
            {
                return CheckWaarden.Niks;
            }
        }

    }
}
