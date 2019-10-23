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
        public event MessageDelegate OnMessage;
        int Kaartnummer = 0;

        public void SpelStarten()
        {
            var kaarten = deck.KaartspelMaken();
            //dealer pakt eerste kaart
            var EersteKaart = KaartTrekken(kaarten, Kaartnummer);
            dealer.EersteKaartDealer(EersteKaart);
            OnMessage("De dealer heeft een " + EersteKaart + " gepakt. " + dealer.Waarde);


            
            while (speler.LaatsteKaartGepakt != true)
            {
                ConsoleKeyInfo result = Console.ReadKey(true);
                if (result.KeyChar == 'k')
                {
                    if (speler.EersteBeurt)
                    {
                        Kaart kaart1 = KaartTrekken(kaarten, Kaartnummer);
                        Kaart kaart2 = KaartTrekken(kaarten, Kaartnummer);
                        string tekstEersteBeurt = speler.EerstebeurtSpeler(kaart1, kaart2);
                        OnMessage(tekstEersteBeurt);
                    }
                    else
                    {
                        var GepakteKaart = KaartTrekken(kaarten, Kaartnummer);
                        string tekstStatus = speler.KaartVerwerken(GepakteKaart);
                        OnMessage(tekstStatus);
                    }
                }
                else if(result.KeyChar == 'p')
                {
                    speler.LaatsteKaartGepakt = true;
                }

            }
        }

        public Kaart KaartTrekken(List<Kaart> kaarten, int kaartnummer)
        {
            Kaartnummer++;
            return kaarten[kaartnummer];
        }
    }
}
