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
        public string Naam { get; set; }
        public bool EersteBeurt { get; set; }
        public bool LaatsteKaartGepakt { get; set; }
        private List<Kaart> Hand = new List<Kaart>();

        public Speler(string naam)
        {
            this.Naam = naam;
            this.EersteBeurt = true;
            LaatsteKaartGepakt = false;
        }

        public void EersteKaartDealer(Kaart kaart)
        {
            Hand.Add(kaart);
        }

        public string EerstebeurtSpeler(Kaart kaart1, Kaart kaart2)
        {
            KaartVerwerken(kaart1);
            KaartVerwerken(kaart2);
            EersteBeurt = false;
            return Naam + " heeft een " + kaart1 + " en een " + kaart2 + " gepakt. De waarde van z'n hand is " + Waarde;
        }

        public string KaartVerwerken(Kaart kaart)
        {
            Hand.Add(kaart);
            if (GetStatus() == CheckWaarden.Blackjack)
            {
                LaatsteKaartGepakt = true;
                return "Blackjack! " + Naam + " heeft een " + kaart + " gepakt. De waarde van z'n hand is nu ";
            }
            else if (GetStatus() == CheckWaarden.Af)
            {
                LaatsteKaartGepakt = true;
                return Naam + " is af! Je hebt een " + kaart + " gepakt. De waarde van z'n hand is nu " + Waarde;
            }
            else
            {
                return Naam + " heeft een " + kaart + " gepakt. De waarde van z'n hand is nu " + Waarde;
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
