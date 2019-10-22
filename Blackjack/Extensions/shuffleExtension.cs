using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack.Extensions
{
    public static class shuffleExtension
    {
        public static List<Kaart> Shuffle (this List<Kaart> inputList)
        {
            List<Kaart> randomList = new List<Kaart>();

            Random rnd = new Random();
          
            while (inputList.Count>0)
            {
                var randomIndex = rnd.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }
            return randomList;

        }

    }
}
