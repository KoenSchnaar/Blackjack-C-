using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Spel
    {
        private Speler speler = new Speler();
        private List<Kaart> kaarten = new List<Kaart>();

        public void SpelStarten()
        {
            
        }
        
        
        public void KaartspelMaken()
        {
            int[] nummers = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
            string[] kleuren = new string[] { "Harten", "Schoppen", "Ruiten", "Klaver" };


            for (int x = 0; x < nummers.Length; x++)
            {
                for (int y = 0; y < kleuren.Length; y++)
                {
                    kaarten.Add(new Kaart(nummers[x], kleuren[y]));
                }
            }
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(kaarten[i]);
            }
            
            Console.ReadLine();
        }
    }
}
