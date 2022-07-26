using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Uber
{
    public static class Exercises
    {
        public static bool CanMakeAllTrips(int[][] trip)
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
                - Qual o limite máximo de viagens? 
                - As viagens podem ser de volta? do Km 10 ao km 4, por exemplo? 
                - Qual o numero maximo de passageiros?
                - Condições para a viagem: 
                    - a intersecção entre os intervalos de KM não pode acontecer, visto que uma viagem precisa terminar para iniciar a outra. Correto? 
                    - O numero de passageiros precisa estar dentro da capacidade máxima.
                
            */

            bool canComplyAllTrips = true;

            return canComplyAllTrips;
        }


    }
}
