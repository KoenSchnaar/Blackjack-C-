using Blackjack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.repository
{
    public class SpelerRepository
    {
        private SpellenEntities2 context = new SpellenEntities2();
        public IEnumerable<speler> GetSpelers()
        {
            return context.spelers.AsEnumerable();
        }

        public void AddNewSpeler(speler speler)
        {
            context.spelers.Add(speler);
            context.SaveChanges();
        }
    }
}
