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
        public string Naam { get; set; }
        public bool EersteBeurt { get; set; }
        public bool LaatsteKaartGepakt { get; set; }
        public bool Busted { get; set; }
        public int Bank { get; set; }
        public int Inzet { get; set; }
        private List<Kaart> Hand = new List<Kaart>();

        public Speler(string naam)
        {
            this.Naam = naam;
            this.EersteBeurt = true;
            this.LaatsteKaartGepakt = false;
            this.Busted = false;
            this.Bank = 10;
            this.Inzet = 0;
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
            if (Waarde == 21)
            {
                LaatsteKaartGepakt = true;
                return "Blackjack! " + Naam + " heeft een " + kaart + " gepakt. De waarde van z'n hand is nu ";
            }
            else if (Waarde > 21)
            {
                LaatsteKaartGepakt = true;
                Busted = true;
                return Naam + " is af! Je hebt een " + kaart + " gepakt. De waarde van z'n hand is nu " + Waarde;
            }
            else
            {
                return Naam + " heeft een " + kaart + " gepakt. De waarde van z'n hand is nu " + Waarde;
            }
        }

        public string DealerKaarten(Kaart kaart)
        {
            Hand.Add(kaart);
            string displayTekst = "";
            if (Waarde > 16)
            {
                LaatsteKaartGepakt = true;
                displayTekst = "De dealer heeft een " + kaart + " gepakt en heeft totale waarde van " + Waarde;
            }
            if( Waarde > 21 )
            {
                Busted = true;
                displayTekst = "De dealer is busted. Hij heeft een " + kaart + " gepakt en hierdoor is zijn handwaarde " + Waarde + ".";
            }
            return displayTekst;
        }

        public string GewonnenCheck(int dealerWaarde)
        {
            if (Waarde > 16 && Waarde < 22 && Waarde > dealerWaarde || Waarde < 22 && dealerWaarde > 21)
            {
                Bank += ( Inzet * 2 );
                return Naam + " heeft gewonnen en wint " + (Inzet * 2) + ". De hoogte van z'n bank is nu " + Bank;
            }
            else if(Waarde > 16 && Waarde < 22 && Waarde == dealerWaarde)
            {
                Bank += Inzet;
                return Naam + " heeft even hoog als de dealer en krijgt de inzet van " + Inzet + " terug.";
            }
            else
            {
                return Naam + " heeft verloren en verliest de inzet van " + Inzet + ".";
            }
        }
    }
}
