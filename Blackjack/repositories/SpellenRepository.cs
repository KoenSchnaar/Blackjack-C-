using Blackjack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.repository
{
    public class SpellenRepository
    {
        private SpellenEntities2 context = new SpellenEntities2();
        public int GetBlackjackID()
        {
            var blackjack = context.spellens.Single(s => s.spelnaam == "Blackjack");
            var spelID = blackjack.spel_ID;
            return spelID;
        }
    }
}
