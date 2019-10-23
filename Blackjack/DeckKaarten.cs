using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Extensions;

namespace Blackjack
{
    class DeckKaarten
    {
        private List<Kaart> kaarten = new List<Kaart>();
              

        public List<Kaart> KaartspelMaken()
        {
            string[] kleuren = new string[] { "Harten", "Schoppen", "Ruiten", "Klaver" };

            for (int y = 0; y < kleuren.Length; y++)    
            {
                kaarten.Add(new Boer(kleuren[y]));
                kaarten.Add(new Vrouw(kleuren[y]));
                kaarten.Add(new Koning(kleuren[y]));
                kaarten.Add(new Aas(kleuren[y]));
                for (int x = 2; x < 11; x++)
                {
                    kaarten.Add(new Kaart(x, kleuren[y]));
                }
            }

            kaarten = kaarten.Shuffle();

            return kaarten;

        }

    }
}
