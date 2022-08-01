using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.CrackingTheCode
{
    /// <summary>
    /// Chapter 8 - Recursion and Dynamic Programming
    /// </summary>
    public class RecursionDynamicProg
    {
        public static int TripleStep(int staircaseSteps)
        {
            if (staircaseSteps < 0)
                return 0;
            if (staircaseSteps == 0)
                return 1;

            return TripleStep(staircaseSteps - 1) + TripleStep(staircaseSteps - 2) + TripleStep(staircaseSteps - 3);
        }

        public static int TripleStepDynamic(int staircaseSteps)
        {
            int[] memo = new int[staircaseSteps + 1];
            Array.Fill(memo, -1);
            return TripleStepDynamic(staircaseSteps, memo);
        }

        public static int TripleStepDynamic(int staircaseSteps, int[] memo)
        {
            if (staircaseSteps < 0)
                return 0;
            if (staircaseSteps == 0)
                return 1;
            if (memo[staircaseSteps] > -1)
                return memo[staircaseSteps];

            memo[staircaseSteps] = TripleStep(staircaseSteps - 1) + TripleStep(staircaseSteps - 2) + TripleStep(staircaseSteps - 3);

            return memo[staircaseSteps];
        }

        public static int TripleStepDynamicIterative(int staircaseSteps)
        {
            int[] memo = new int[staircaseSteps + 1];
            return TripleStepDynamicIterative(staircaseSteps, memo);
        }

        public static int TripleStepDynamicIterative(int staircaseSteps, int[] memo)
        {
            memo[0] = 0;

            for (int i = 1; i < staircaseSteps; i++)
            {
                //for (int j = 3; j < )
                memo[staircaseSteps] = memo[staircaseSteps - 1] + memo[staircaseSteps - 2] + memo[staircaseSteps - 3];
            }

            return memo[staircaseSteps];
        }

        /// <summary>
        /// Exercise 8.2 - Chapter 8
        /// Robot Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static List<Tuple<int, int>> FindRobotPath(int[][] grid)
        {
            var coordinates = new List<Tuple<int, int>>();

            return RobotGridPath(grid, 0, 0, "right", false, coordinates);
        }

        public static List<Tuple<int, int>> RobotGridPath(int[][] grid, int rowIndex, int columnIndex, string direction, bool cameFromOffLimit, List<Tuple<int, int>> coordinates)
        {
            // Treats a off limit scenario.
            if (IsOffLimit(grid[rowIndex][columnIndex]))
            {
                string newDirection;

                if (cameFromOffLimit)
                    throw new Exception("Can’t find a path.Available cells are blocked.");

                // Means I came from the right
                if (direction == "right")
                {
                    //Step a column back and call again with a different direction.
                    columnIndex -= 1;
                    newDirection = "down";
                }
                else // came from top
                {
                    // Step a row back and call again with the "right" direction.
                    rowIndex -= 1;
                    newDirection = "right";
                }

                RobotGridPath(grid, rowIndex, columnIndex, newDirection, true, coordinates);
            }
            else
            {
                coordinates.Add(new Tuple<int, int>(rowIndex, columnIndex));

                if (rowIndex + 1 == grid.Length)
                {
                    // Reached the last row. Go right.
                    //if (direction == "right" && cameFromOffLimit)
                        
                    RobotGridPath(grid, rowIndex, columnIndex + 1, "right", false, coordinates);
                }
                else if (columnIndex + 1 == grid[rowIndex].Length)
                {
                    // Reached the last column. Go down.
                    RobotGridPath(grid, rowIndex + 1, columnIndex, "down", false, coordinates);
                }
                else if ((columnIndex < (grid[rowIndex].Length - 1)) && (rowIndex < (grid.Length - 1)))
                {
                    // Continue to find a path taking a different direction.
                    if (direction == "down")
                        RobotGridPath(grid, rowIndex + 1, columnIndex, "down", false, coordinates);
                    else
                        RobotGridPath(grid, rowIndex, columnIndex + 1, "right", false, coordinates);
                }
            }

            return coordinates;
        }

        /// <summary>
        /// Checks if a coordinate is off limits.
        /// Exercise 8.2 - Chapter 8
        /// </summary>
        /// <param name="coordinateValue"></param>
        /// <returns></returns>
        public static bool IsOffLimit(int coordinateValue)
        {
            return coordinateValue.Equals(1);
        }

    }
}
