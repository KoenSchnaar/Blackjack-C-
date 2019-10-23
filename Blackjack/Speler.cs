using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Speler
    {
        public int Waarde { get {
                var totaalWaarde = 0;
                foreach (var kaart in Hand)
                    totaalWaarde += kaart.Nummer;
                return totaalWaarde;
            } }
        public int AantalKaarten { get; set; }
        public bool EersteBeurt { get; set; }
        public bool LaatsteKaartGepakt { get; set; }
        private List<Kaart> Hand = new List<Kaart>();

        public Speler()
        {
            this.EersteBeurt = true;
            LaatsteKaartGepakt = false;
        }

        public void EersteKaartDealer(Kaart kaart)
        {
            Hand.Add(kaart);
        }

        public void EerstebeurtSpeler(Kaart kaart1, Kaart kaart2, Speler speler)
        {
            Hand.Add(kaart1);
            Hand.Add(kaart2);
            if (GetStatus() == CheckWaarden.Blackjack)
            {
                Console.WriteLine("BLACKJACK EASY MONEY!");
                speler.LaatsteKaartGepakt = true;
            }
            else
            {
                Console.WriteLine("je hebt een " + kaart1 + " en een " + kaart2 + " gepakt. De waarde van je hand is " + speler.Waarde);
            }
            speler.EersteBeurt = false;
        }

        public void KaartVerwerken(Kaart kaart, Speler speler)
        {
            Hand.Add(kaart);
            if (GetStatus() == CheckWaarden.Blackjack)
            {
                Console.WriteLine("Blackjack!");
                speler.LaatsteKaartGepakt = true;
            }
            else if (GetStatus() == CheckWaarden.Af)
            {
                Console.WriteLine("Je bent af! Je hebt een " + kaart + " gepakt. De waarde van je hand is nu " + speler.Waarde);
                speler.LaatsteKaartGepakt = true;
            }
            else
            {
                Console.WriteLine("Je hebt een " + kaart + " gepakt. De waarde van je hand is nu " + speler.Waarde);
            }
        }

        public CheckWaarden GetStatus()
        {
            if (Waarde > 21)
            {
                return CheckWaarden.Af;
            }
            else if (Waarde == 21)
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
