using Blackjack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.repository
{
    public class SessieRepository
    {
        private SpellenEntities2 context = new SpellenEntities2();
        public IEnumerable<SessieEntity> GetSessies()
        {
            return context.SessieEntities;
        }
        public void MakeSessie(SessieEntity sessie)
        {
            context.SessieEntities.Add(sessie);
        }
        public bool CheckSessie(int spelerID, int spelID)
        {
            return context.SessieEntities.Any(s => s.speler_ID == spelerID && s.spel_ID == spelID);
        }
    }
}
