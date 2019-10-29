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
        private SessieRepository SessieRepo = new SessieRepository();
        private UitslagenRepository UitslagenRepo = new UitslagenRepository();
        public IEnumerable<speler> GetSpelers()
        {
            return context.spelers.AsEnumerable();
        }

        public void AddNewSpeler(speler speler, int spelID)
        {
            context.spelers.Add(speler);
            SessieEntity sessie = new SessieEntity();
            sessie.speler_ID = speler.speler_ID;
            sessie.spel_ID = spelID;
            SessieRepo.MakeSessie(sessie);
            //uitslagen uitslag = new uitslagen();
            //uitslag.speler_ID = speler.speler_ID;
            //uitslag.spel_ID = spelID;
            //UitslagenRepo.MakeUitslagTabel(uitslag);
            context.SaveChanges();
        }
    }
}
