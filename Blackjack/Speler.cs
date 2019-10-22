using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Speler
    {
        public int Waarde { get; set; }
        public int AantalKaarten { get; set; }
        public bool Blackjack { get; set; }
        public bool LaatsteKaartGepakt { get; set; }
    }
}
