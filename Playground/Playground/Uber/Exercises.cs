using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Uber
{
    public static class Exercises
    {
        public static bool CanMakeAllTrips(int[][] trip, int capacity)
        {
            /**
             * There is a car with a certain number of seats that only drives forward in a single road 1000km long.
            You are given the capacity of the car and an array of trips in which each trip has:
            - The number of passengers
            - The pick-up location
            - The drop-off location

            Example: given the trip[2, 1, 5], it means that 2 passengers will be picked up at 1st km and dropped off at 5th.

                Write a function that answers whether this car is able to comply with all the given trips.

            [
                [2, 1, 5],
                [3, 4, 10],
                [1, 5, 2]
            ]

            Perguntas: 
                - será um array contendo viagens, sendo que cada viagem é um outro array?
                - É possível mudar a ordem das viagens para acomodar no tempo? 
                    - Não. o array já vem ordenado.
                - Qual o limite máximo de viagens? 
                    - QUanta couberem em 1000 km.
                - As viagens podem ser de volta? do Km 10 ao km 4, por exemplo? 
                    - Não, o carro só anda pra frente.
                - Qual o numero maximo de passageiros?
                    - Capacity pode ser 4.
                - Condições para a viagem: 
                    - a intersecção entre os intervalos de KM não pode acontecer, visto que uma viagem precisa terminar para iniciar a outra. Correto? 
                    - O numero de passageiros precisa estar dentro da capacidade máxima.
            
            Examples:
                - [[2,1,5], [3,4,10], [1,5,2]], 4 -> false, já que no km 4 ainda terão 2 passageiros
                - [[1,10,12], [3,5,15], [3,30,40], [2,8,18]], 4 => false

            Strategy:
                - loop dentro de loop para comparar cada item com todos da lista
                - se achar uma interseção, somo o numero de passageiros
                - se for maior que a capacidade, falso. se for menor, verdadeiro.


            Time Complexity: O(N^2)
            Space Complexity: O(1)
            */

            //trip[0][0] => passengers
            //trip[0][1] => pickup
            //trip[0][2] => drop off

            for (int i = 0; i < trip.Length; i++)
            {
                if (trip[i][0] > capacity)
                    return false;
                    
                for (int j = i + 1; j < trip.Length; j++)
                {
                    if (trip[i][2] > trip[j][1] && ((trip[i][0] + trip[j][0]) > capacity))
                        return false; // intersection: first drop off is greater than last pickup
                }
            }

            return true;
        }
        /// <summary>
        /// Uber Mock Interview - 2020
        /// </summary>
        /// <remarks>
        ///     Dado um array, encontre o elemento que mais se repete.
        ///     Se múltiplos elementos aparecerem igualmente, retorne qualquer um deles.
        ///
        ///     If I have this example: new int[] {1,2,2,3,4,4,4,4,4,5,5,5}
        ///     Return value for the function should be 4, that appears 4 times.
        ///
        ///     For empty array, we can set -1 as return value.
        ///     For the same number, we can return any number. new int[] {1,2,2,3,3,4,4} can return 2, 3 or 4.
        ///
        ///     Strategy:
        ///         - Traverse through the int array and put each element in a HashMap (Dictionary in C#), which has an update and lookup of cost O(1).
        ///         - Increment the count for each value in the hashmap.
        ///         - Traverse through the HashMap again and check which number is the highest.
        ///
        ///     Questions:
        ///         - do we have negative numbers?
        ///         - what is the maximum size? using long or int? 
        /// 
        /// </remarks>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static int FindElementWithHighestFrequency(int[] elements)
        {
            Dictionary<int, int> elementsMap = new Dictionary<int, int>();
            int highestFreqElem = 0;
            int returnElement = 0;

            if (elements.Length == 0)
                return -1;

            foreach (int element in elements)
            {
                if (elementsMap.ContainsKey(element))
                    elementsMap[element]++;
                else
                    elementsMap.Add(element, 1);
            }

            foreach (KeyValuePair<int, int> pair in elementsMap)
            {
                if (pair.Value > highestFreqElem)
                {
                    highestFreqElem = pair.Value;
                    returnElement = pair.Key;
                }
                    
            }

            return returnElement;
        }
    }
}
