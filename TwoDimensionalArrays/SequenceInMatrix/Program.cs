using System;

namespace SequenceInMatrix
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            int currentSequence = 1;
            int longestSequence = 1;

            //sequence in a row

            for (int row = 0; row < n; row++)
            {
                currentSequence = 1;
                for (int col = 0; col < m - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        currentSequence++;
                        if (currentSequence > longestSequence)
                        {
                            longestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                }
            }

            // sequence in a column

            for (int col = 0; col < m; col++)
            {
                currentSequence = 1;
                for (int row = 0; row < n - 1; row++)
                {
                    if (matrix[row, col] == matrix[row + 1, col])
                    {
                        currentSequence++;
                        if (currentSequence > longestSequence)
                        {
                            longestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                }
            }

            // sequence in a left-to-right diagonal

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < m - 1; col++)
                {
                    int currentRow = row;
                    int currentCol = col;
                    while (currentRow < n - 1 && currentCol < m - 1)
                    {
                        if (matrix[currentRow, currentCol] == matrix[currentRow + 1, currentCol + 1])
                        {
                            currentSequence++;
                            if (currentSequence > longestSequence)
                            {
                                longestSequence = currentSequence;
                            }
                        }
                        else
                        {
                            currentSequence = 1;
                        }

                        currentRow++;
                        currentCol++;
                    }
                }
            }

            // sequence in a right-to-left diagonal

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 1; col < m; col++)
                {
                    int currentRow = row;
                    int currentCol = col;
                    while (currentRow < n - 1 && currentCol > 0)
                    {
                        if (matrix[currentRow, currentCol] == matrix[currentRow + 1, currentCol - 1])
                        {
                            currentSequence++;
                            if (currentSequence > longestSequence)
                            {
                                longestSequence = currentSequence;
                            }
                        }
                        else
                        {
                            currentSequence = 1;
                        }
                        currentRow++;
                        currentCol--;
                    }
                }
            }
            Console.WriteLine(longestSequence);
        }
    }
}
