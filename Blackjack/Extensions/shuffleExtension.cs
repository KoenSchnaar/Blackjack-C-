using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack.Extensions
{
    public static class shuffleExtension
    {
        public static Stack<Kaart> Shuffle (this List<Kaart> inputList)
        {
            Stack<Kaart> randomList = new Stack<Kaart>();

            Random rnd = new Random();
          
            while (inputList.Count>0)
            {
                var randomIndex = rnd.Next(0, inputList.Count);
                randomList.Push(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }
            return randomList;

        }

    }
}
