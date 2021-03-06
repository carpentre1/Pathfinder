﻿using System;

/*
int array, values > 0 == impassable
in the array and value you want indicating impassable
starting position in x,y
destination in x,y
GOAL
    Agent myAgent = newAgent(arrayOfLocales, startingPos, endingPos);
    var solution = newAgent.SolvePath();
where solution == a set of x,y coordinates, for each move,
from the start to the end that doesn't pass through impassable AND is the most efficient path you can resolve
only one unit (grid) move per "turn".
*/

namespace Pathfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent myAgent = new Agent(0, 0, 5, 5);

            Pathfinder pathfinder = new Pathfinder();

            int[,] area = myAgent.CreateArea();

            pathfinder.Pathfind(myAgent, area);

            Print2dArray(area);
        }

        private static void Print2dArray(int[,] board)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    Console.Write("|");
                    Console.Write(board[x, y]);
                }
                Console.WriteLine("|");
            }
        }


    }

    class Agent
    {
        public int startingX;
        public int startingY;
        public int endingX;
        public int endingY;

        public Agent(int startX, int startY, int endX, int endY)
        {
            startingX = startX; startingY = startY;
            endingX = endX; endingY = endY;
        }

        /// <summary>
        /// Creates the area that the agent moves through as a 2D array.
        /// 0 is passable, anything greater than 0 is impassable.
        /// Top left is positions[0,0]. The index to the right of that is positions[0,1].
        /// I'm not sure how to make it so that we can simply plug in variables to dynamically change the size of the array and the values of each index.
        /// The benefit of manually laying it out like this is we can easily test it since we can clearly see and modify the value of each index.
        /// </summary>
        /// <returns></returns>
        public int[,] CreateArea()
        {
            int[,] positions = new int[6, 6]
            {
                {0, 0, 0, 0, 0, 0} ,
                {1, 1, 1, 1, 1, 0} ,
                {0, 0, 0, 0, 0, 0} ,
                {1, 1, 1, 1, 1, 1} ,
                {0, 0, 1, 1, 1, 1} ,
                {0, 0, 0, 0, 0, 0}
            };
            Console.WriteLine("The starting position is [" + startingX + "," + startingY + "] which has a value of " + positions[startingX,startingY]);
            return positions;
        }
    }
}
