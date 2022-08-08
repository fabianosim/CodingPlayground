using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class PlaygroundExercises
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

        public string[][] IngredientsDishes(string[][] dishes)
        {
            SortedDictionary<string, SortedSet<string>> ingredientsByDishes = new SortedDictionary<string, SortedSet<string>>(new AsciiComparable());

            // Traverse the dishes to get the unique ingredients.
            for (int d = 0; d < dishes.Length; d++)
            {
                // Starting from 1 since the ingredients starts from the second cell
                for (int i = 1; i < dishes[d].Length; i++)
                {
                    // If it does not contain the ingredient, then I can already insert the dish
                    if (!ingredientsByDishes.ContainsKey(dishes[d][i]))
                    {
                        SortedSet<string> dishesForIngredient = GetDishesForIngredient(dishes[d][i], dishes);

                        if (dishesForIngredient.Count > 1)
                            ingredientsByDishes.Add(dishes[d][i], dishesForIngredient);
                    }
                }
            }

            List<List<string>> returnValue = new List<List<string>>();

            foreach (KeyValuePair<string, SortedSet<string>> ingredient in ingredientsByDishes)
            {
                List<string> valToAdd = ingredient.Value.ToList();
                valToAdd.Insert(0, ingredient.Key);
                returnValue.Add(valToAdd);
            }

            return returnValue.Select(_ => _.ToArray()).ToArray();
        }

        private SortedSet<string> GetDishesForIngredient(string ingredient, string[][] dishes)
        {
            SortedSet<string> dishesForIngredients = new SortedSet<string>(new AsciiComparable());

            foreach (string[] dish in dishes)
            {
                if (dish.Contains(ingredient))
                    dishesForIngredients.Add(dish[0]);
            }

            return dishesForIngredients;
        }

        private class AsciiComparable : IComparer<string>
        {
            string xExt, yExt;

            public int Compare(string x, string y)
            {
                return string.CompareOrdinal(x, y);
            }
        }

        // Facebook question: print subset. 
        // Got an iterative implementation of it.
        public void PrintSubSet(string[] numArray)
        {
            string[] oldList = { "" };

            for (int i = 0; i < numArray.Length; i++)
            {
                string[] ar = new string[oldList.Length * 2];
                
                for (int j = 0; j < ar.Length; j++)
                {
                    if (j < oldList.Length)
                    {
                        ar[j] = oldList[j];
                    }
                    else
                    {
                        ar[j] = oldList[j - oldList.Length] + numArray[i];
                    }
                }
                oldList = ar;
            }
            Console.WriteLine("Printing subset : " + string.Join(',', oldList));
            Console.WriteLine("Number of subset : " + oldList.Length);
        }

        /// <summary>
        /// Exercise from Google Mock Interview
        /// Piggy Bank Sets
        /// Time complexity:
        ///     - O(N log N) -> for each iteration, I will have N-1 items to traverse.
        ///     - O(1) space complexity
        /// </summary>
        /// <param name="piggyBankSet"></param>
        /// <param name="legoPrice"></param>
        /// <returns></returns>
        public int[] PiggyBankIDs(int[] piggyBankSet, int legoPrice)
        {
            List<int> piggyIds = new List<int>();

            if (piggyBankSet.Length < 2)
                return Array.Empty<int>();

            // Traverse through the set of piggy banks
            for (int i = 0; i < piggyBankSet.Length; i++)
            {
                if (MatchesLegoPrice(piggyBankSet, legoPrice, i, out int matchIndex))
                {
                    piggyIds.Add(i);
                    piggyIds.Add(matchIndex);
                    break;
                }
            }

            return piggyIds.ToArray();
        }

        public bool MatchesLegoPrice(int[] piggyBankSet, int legoPrice, int index, out int matchIndex)
        {
            // Start from the index to search
            matchIndex = 0;

            for (int i = index + 1; i < piggyBankSet.Length; i++)
            {
                if ((piggyBankSet[index] + piggyBankSet[i]).Equals(legoPrice))
                {
                    matchIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Exercise from Google Mock Interview - Piggy Banks
        /// O(N) optimized solution
        /// O(N) space complexity
        /// </summary>
        /// <param name="piggyBankSet"></param>
        /// <param name="legoPrice"></param>
        /// <returns></returns>
        public int[] PiggyBankIDsLinear(int[] piggyBankSet, int legoPrice)
        {
            List<int> piggyIds = new List<int>();
            HashSet<int> seenValues = new HashSet<int>();

            if (piggyBankSet.Length < 2)
                return Array.Empty<int>();

            // Traverse through the set of piggy banks
            for (int i = 0; i < piggyBankSet.Length; i++)
            {
                int valueLeftToTarget = legoPrice - piggyBankSet[i];

                if (seenValues.Contains(valueLeftToTarget))
                {
                    piggyIds.Add(i);
                }

                seenValues.Add(piggyBankSet[i]);
            }

            return piggyIds.ToArray();
        }

    }
}
