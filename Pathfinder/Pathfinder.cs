using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
    class Pathfinder
    {
        int movesTaken = 0;
        bool mazeIsPossible = true;
        public void Pathfind(Agent a, int[,] board)
        {
            Tuple<int, int> playerPosition = new Tuple<int, int>(a.startingX, a.startingY);
            Tuple<int, int> endingPosition = new Tuple<int, int>(a.endingX, a.endingY);

            int[,] pathfinderBoard = board;

            Console.WriteLine(playerPosition);
            while (!(playerPosition.Item1 == endingPosition.Item1 && playerPosition.Item2 == endingPosition.Item2) && mazeIsPossible)
            {
                pathfinderBoard[playerPosition.Item1, playerPosition.Item2] = 2;

                playerPosition = NextPosition(pathfinderBoard, playerPosition, endingPosition);

                Console.WriteLine(playerPosition);
            }

            if(!mazeIsPossible)
            {
                Console.WriteLine("Maze is impossible!");
            }

            else
            {
                pathfinderBoard[playerPosition.Item1, playerPosition.Item2] = 2;
                Console.WriteLine("Moves taken to reach the end: " + movesTaken);
            }

        }

        private Tuple<int, int> NextPosition(int[,] board, Tuple<int, int> playerPosition, Tuple<int, int> endingPosition)
        {
            List<Tuple<int, int>> validPositions = new List<Tuple<int, int>>();

            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == 0)
                    {
                        validPositions.Add(new Tuple<int, int>(x, y));
                    }
                }
            }

            movesTaken++;

            int horiz;
            int vert;

            if ((endingPosition.Item1 - playerPosition.Item1) == 0)
                horiz = 1;
            else
                horiz = (endingPosition.Item1 - playerPosition.Item1) / Math.Abs(endingPosition.Item1 - playerPosition.Item1);

            if ((endingPosition.Item2 - playerPosition.Item2) == 0)
                vert = 1;
            else
                vert = (endingPosition.Item2 - playerPosition.Item2) / Math.Abs(endingPosition.Item2 - playerPosition.Item2);

            if (Math.Abs(endingPosition.Item1 - playerPosition.Item1) > Math.Abs(endingPosition.Item2 - playerPosition.Item2))
            {
                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 - vert);
            }
            else if (Math.Abs(endingPosition.Item1 - playerPosition.Item1) < Math.Abs(endingPosition.Item2 - playerPosition.Item2))
            {
                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 - vert);
            }
            else
            {
                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 + vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 + vert);

                if (ValidPosition(validPositions, playerPosition.Item1 + horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 + horiz, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2);

                if (ValidPosition(validPositions, playerPosition.Item1, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1, playerPosition.Item2 - vert);

                if (ValidPosition(validPositions, playerPosition.Item1 - horiz, playerPosition.Item2 - vert))
                        return new Tuple<int, int>(playerPosition.Item1 - horiz, playerPosition.Item2 - vert);
            }
            mazeIsPossible = false;
            Console.WriteLine(board[board.GetLength(0) - 1, board.GetLength(1) - 1]);
            return playerPosition;
        }


        private bool ValidPosition(List<Tuple<int, int>> validPositions, int x, int y)
        {
            foreach (Tuple<int, int> tuple in validPositions)
            {
                if (tuple.Item1 == x && tuple.Item2 == y)
                    return true;
            }

            return false;
        }
    }
}
