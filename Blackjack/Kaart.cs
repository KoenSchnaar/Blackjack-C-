using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Kaart
    {
        public int Nummer {get; set;}
        public string Kleur {get; set;}
        public bool Gepakt {get; set;}
        
        public Kaart (int nummer, string kleur)
	    {
            this.Nummer = nummer;
            this.Kleur = kleur;
            this.Gepakt = false;
	    }

        public override string ToString()
        {
            return $"{Nummer}{Kleur}";
        }
    }
}
