using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class PlaygroundTests
    {
        public int solution(int[] inputArray)
        {
            //return inputArray.Select((i, j) => j > 0 ? i * inputArray[j - 1] : int.MinValue).Max();

            foreach (int i in Power(2, 8))
            {
                 Console.WriteLine(i);
            }

            return 1;
        }

        public IEnumerable<int> Power(int number, int expoent)
        {
            int result = 1;

            for (int i = 0; i < expoent; i++)
            {
                yield return result;
                result = result * number;
            }
        }
    }
}
