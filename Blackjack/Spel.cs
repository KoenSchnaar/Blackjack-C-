using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blackjack.Extensions;

namespace Blackjack
{
    class Spel
    {
        private Speler dealer = new Speler("Dealer");
        private List<Speler> spelers = new List<Speler>();
        private Stack<Kaart> kaarten;
        
        public event MessageDelegate OnMessage;

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
                    InzetRegelen();
                    OnMessage("Het spel begint! Druk op een toets om de dealer de kaarten te laten dealen.");
                    Console.ReadKey(true);
                    starten = true;
                }
            } while (starten == false);
            SpelStarten();
        }

        public void InzetRegelen()
        {
            foreach (Speler speler in spelers)
            {
                Console.WriteLine(speler.Naam + ", voer je inzet in en druk op enter.");
                int input = GeldInzetten(Console.ReadLine());
                speler.Inzet = input;
                speler.Bank -= input;
            }
        }

        public void SpelStarten()
        {
            kaarten = DeckKaarten.KaartspelMaken();
            var EersteKaart = KaartTrekken();
            dealer.EersteKaartDealer(EersteKaart);
            OnMessage("De dealer heeft een " + EersteKaart + " gepakt.");
            Thread.Sleep(1000);
            foreach (Speler speler in spelers)
            {
                Kaart kaart1 = KaartTrekken();
                Kaart kaart2 = KaartTrekken();
                string tekstEersteBeurt = speler.EerstebeurtSpeler(kaart1, kaart2);
                OnMessage(tekstEersteBeurt);
                Thread.Sleep(1000);
            }
            SpelSpelen();
        }

        private void SpelSpelen()
        {
            foreach (Speler speler in spelers)
            {
                OnMessage(speler.Naam + " is aan de beurt. Druk op 'k' om een kaart te pakken of op 'p' om te passen. Je handwaarde is " + speler.Waarde);
                while (speler.LaatsteKaartGepakt != true)
                {
                    ConsoleKeyInfo result = Console.ReadKey(true);
                    if (result.KeyChar == 'k')
                    {
                        Kaart GepakteKaart = KaartTrekken();
                        string tekstStatus = speler.KaartVerwerken(GepakteKaart);
                        OnMessage(tekstStatus);
                    }
                    else if (result.KeyChar == 'p')
                    {
                        speler.LaatsteKaartGepakt = true;
                    }
                }
            }
            do
            {
                Kaart DealerKaart = KaartTrekken();
                string dealerMessage = dealer.DealerKaarten(DealerKaart);
                OnMessage(dealerMessage);
                Console.ReadKey(true);
            } while (dealer.LaatsteKaartGepakt == false);
            
            foreach (Speler speler in spelers)
            {
                string winMessage = speler.GewonnenCheck(dealer.Waarde);
                OnMessage(winMessage);
                Thread.Sleep(500);
                speler.Inzet = 0;
            }
            Console.ReadKey(true);
        }

        private Kaart KaartTrekken()
        {
            return kaarten.Pop();
        }

        private void SpelerToevoegen(string naam)
        {
            spelers.Add(new Speler(naam));
        }
        
        public int GeldInzetten(string input)
        {
            int inzet = Convert.ToInt32(input);
            return inzet;
        }
    }
}
