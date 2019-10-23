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
        private Speler dealer = new Speler("Dealer");
        private List<Speler> spelers = new List<Speler>();
        private DeckKaarten deck = new DeckKaarten();
        public event MessageDelegate OnMessage;
        int Kaartnummer = 0;

        public void SpelAanmaken()
        {
            OnMessage("Welkom bij BlackJack! Voer je naam in en druk op enter.");
            SpelerToevoegen(Console.ReadLine());
            bool starten = false;
            do
            {
                OnMessage("Wil je nog een speler toevoegen? Druk dan op 'a'. Zo niet druk dan op 'r'");
                ConsoleKeyInfo gedrukt = Console.ReadKey(true);
                if (gedrukt.KeyChar == 'a')
                {
                    OnMessage("Voer de naam van de volgende speler in en druk op enter");
                    SpelerToevoegen(Console.ReadLine());
                }
                else if (gedrukt.KeyChar == 'r')
                {
                    OnMessage("Het spel begint! Druk op een toets om de dealer de eerste kaart te laten pakken.");
                    Console.ReadKey(true);
                    starten = true;
                }
            } while (starten == false);
            SpelStarten();
        }

        public void SpelStarten()
        {
            var kaarten = deck.KaartspelMaken();
            var EersteKaart = KaartTrekken(kaarten, Kaartnummer);
            dealer.EersteKaartDealer(EersteKaart);
            OnMessage("De dealer heeft een " + EersteKaart + " gepakt.");
            foreach (Speler speler in spelers)
            {
                Kaart kaart1 = KaartTrekken(kaarten, Kaartnummer);
                Kaart kaart2 = KaartTrekken(kaarten, Kaartnummer);
                string tekstEersteBeurt = speler.EerstebeurtSpeler(kaart1, kaart2);
                OnMessage(tekstEersteBeurt);
            }
            SpelSpelen(kaarten);
        }

        private void SpelSpelen(List<Kaart> kaarten)
        {
            foreach (Speler speler in spelers)
            {
                OnMessage(speler.Naam + " is aan de beurt. Druk op 'k' om een kaart te pakken of op 'p' om te passen. Je handwaarde is " + speler.Waarde);
                while (speler.LaatsteKaartGepakt != true)
                {
                    ConsoleKeyInfo result = Console.ReadKey(true);
                    if (result.KeyChar == 'k')
                    {
                        var GepakteKaart = KaartTrekken(kaarten, Kaartnummer);
                        string tekstStatus = speler.KaartVerwerken(GepakteKaart);
                        OnMessage(tekstStatus);
                    }
                    else if (result.KeyChar == 'p')
                    {
                        speler.LaatsteKaartGepakt = true;
                    }
                }
            }
        }

        private Kaart KaartTrekken(List<Kaart> kaarten, int kaartnummer)
        {
            Kaartnummer++;
            return kaarten[kaartnummer];
        }

        private void SpelerToevoegen(string naam)
        {
            spelers.Add(new Speler(naam));
        }
    }
}
