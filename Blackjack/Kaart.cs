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
        public string Naam { get; set; }
        public string Kleur {get; set;}
        public bool Gepakt {get; set;}
        
        public Kaart (int nummer, string kleur)
	    {
            this.Nummer = nummer;
            this.Naam = nummer.ToString();
            this.Kleur = kleur;
            this.Gepakt = false;
            
	    }

        public override string ToString()
        {
            return $"{Kleur} {Naam}";
        }
    }

    public class Boer : Kaart
    {
        public Boer(string kleur) : base(10, kleur)
        {
            Naam = "Boer";
        }
    }

    public class Vrouw : Kaart
    {
        public Vrouw(string kleur) : base(10, kleur)
        {
            Naam = "Vrouw";
        }
    }

    public class Koning : Kaart
    {
        public Koning(string kleur) : base(10, kleur)
        {
            Naam = "Koning";
        }
    }

    public class Aas : Kaart
    {
        public Aas(string kleur) : base(11, kleur)
        {
            Naam = "Aas";
        }
    }
}
