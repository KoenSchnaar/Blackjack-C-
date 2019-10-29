using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blackjack.Extensions;
using Blackjack.repository;
using Blackjack.Data;


namespace Blackjack
{
    class Spel
    {
        private Speler dealer = new Speler("Dealer", 0);
        private List<Speler> spelers = new List<Speler>();
        private Stack<Kaart> kaarten;
        public event MessageDelegate OnMessage;
        private SpelerRepository SpelerRepo = new SpelerRepository();
        private UitslagenRepository UitslagenRepo = new UitslagenRepository();
        private SpellenRepository SpellenRepo = new SpellenRepository();
        private SessieRepository SessieRepo = new SessieRepository();

        public void SpelAanmaken()
        {
            OnMessage("Welkom bij BlackJack! Voer je naam in en druk op enter.");
            string inputnaam = Console.ReadLine();
            CheckDataBase(inputnaam);
            bool starten = false;
            do
            {
                OnMessage("Wil je nog een speler toevoegen? Druk dan op 'a'. Zo niet druk dan op 'r'");
                ConsoleKeyInfo gedrukt = Console.ReadKey(true);
                if (gedrukt.KeyChar == 'a')
                {
                    OnMessage("Voer de naam van de volgende speler in en druk op enter");
                    inputnaam = Console.ReadLine();
                    CheckDataBase(inputnaam);
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

        public void CheckDataBase(string naam)
        {
            int blackjackID = SpellenRepo.GetBlackjackID();
            bool SpelerBestaat = false;

            foreach (speler speler in SpelerRepo.GetSpelers())
            {
                if(naam == speler.spelernaam)
                {
                    SpelerBestaat = true;
                    var spelerID = speler.speler_ID;
                    if(SessieRepo.CheckSessie(spelerID, blackjackID) == false)
                    {
                        SessieEntity sessie = new SessieEntity();
                        sessie.speler_ID = spelerID;
                        sessie.spel_ID = blackjackID;
                        SessieRepo.MakeSessie(sessie);
                    }
                    else
                    {
                        OnMessage("Welkom terug " + speler.spelernaam + ".");
                    }
                    SpelerToevoegen(naam, SpelerBestaat, spelerID, blackjackID); // speler toevoegen in het spel
                }
            }
            if(SpelerBestaat == false)
            {
                var newPlayer = new speler();
                newPlayer.spelernaam = naam;
                SpelerRepo.AddNewSpeler(newPlayer, blackjackID); // speler toevoegen in de database
                SpelerToevoegen(naam, SpelerBestaat, newPlayer.speler_ID, blackjackID); // speler toevoegen in het spel
            }
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
                OnMessage(speler.Naam + " is aan de beurt. Druk op 'k' om een kaart te pakken, op 'p' om te passen of op 'd' voor een DubbleDown. Je handwaarde is " + speler.Waarde);
                while (speler.LaatsteKaartGepakt != true)
                {
                    ConsoleKeyInfo result = Console.ReadKey(true);
                    if (result.KeyChar == 'k')
                    {
                        Kaart GepakteKaart = KaartTrekken();
                        string tekstStatus = speler.KaartVerwerken(GepakteKaart);
                        OnMessage(tekstStatus);
                    }
                    else if (result.KeyChar == 'd')
                    {
                        Kaart GepakteKaart = KaartTrekken();
                        string DDTekst = speler.DubbleDown(GepakteKaart);
                        OnMessage(DDTekst);
                        Thread.Sleep(1000);
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
            }
            ResetVoorNieuweRonde();
        }

        private Kaart KaartTrekken()
        {
            return kaarten.Pop();
        }

        private void SpelerToevoegen(string naam, bool BestaatAl, int spelerID, int blackjackID)
        {
            int bankInzet;
            if (BestaatAl && UitslagenRepo.CheckUitslag(spelerID, blackjackID))
            {
                bankInzet = UitslagenRepo.GetBankBySpelerID(spelerID, blackjackID);
                spelers.Add(new Speler(naam, bankInzet));
                UitslagenRepo.SetBankBySpelerID(spelerID, blackjackID, bankInzet);
            }
            else
            {
                uitslagen uitslag = new uitslagen();
                uitslag.spel_ID = blackjackID;
                uitslag.speler_ID = spelerID;
                UitslagenRepo.MakeUitslagRow(uitslag);
                OnMessage("Hoeveel geld zet je op de bank? Voer in en druk op enter.");
                bankInzet = Convert.ToInt32(Console.ReadLine());
                spelers.Add(new Speler(naam, bankInzet));
                UitslagenRepo.SetBankBySpelerID(spelerID, blackjackID, bankInzet);
            }
        }
        
        public int GeldInzetten(string input)
        {
            int inzet = Convert.ToInt32(input);
            return inzet;
        }
        public void ResetVoorNieuweRonde()
        {
            foreach (Speler speler in spelers)
            {
                speler.Hand.Clear();
                speler.Inzet = 0;
                speler.LaatsteKaartGepakt = false;
            }
            dealer.Hand.Clear();
            dealer.LaatsteKaartGepakt = false;
            kaarten = DeckKaarten.KaartspelMaken();
            Console.ReadKey(true);
            InzetRegelen();
            SpelStarten();
        }
    }
}
