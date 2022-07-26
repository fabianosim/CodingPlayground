using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.CrackingTheCode
{
    public static class HashTableExamples
    {
        /// <summary>
        /// Finds the elements that are common within 2 arrays of integers.
        /// </summary>
        /// <param name="a">First input array</param>
        /// <param name="b">Second input array</param>
        public static int[] ElementsInCommon(int[] a, int[] b)
        {
            var commonElements = new List<int>();
            var bElements = new Hashtable();

            // Let's put all B elements in a hash table
            foreach (int number in b)
            {
                if (!bElements.ContainsKey(number))
                    bElements.Add(number, null);
            }

            foreach (int number in a)
            {
                if (bElements.ContainsKey(number) && !commonElements.Contains(number))
                    commonElements.Add(number);
            }

            return commonElements.ToArray();
        }
    }
}
