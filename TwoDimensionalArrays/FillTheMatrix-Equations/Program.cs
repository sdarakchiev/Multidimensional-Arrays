using System;

namespace FillTheMatrix
{
    class Program
    {

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char character = char.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            if (character == 'a')
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = col * n + row + 1;
                    }
                }
            }

            else if (character == 'b')
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        if (col % 2 == 0)
                        {
                            matrix[row, col] = col * n + row + 1;
                        }
                        else
                        {
                            matrix[row, col] = (col + 1) * n - row;
                        }
                    }
                }
            }

            else if (character == 'c')
            {
                matrix[n - 1, 0] = 1;
                for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
                {

                    matrix[row, 0] = matrix[row + 1, 0] + n - row - 1;
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 1; col < matrix.GetLength(1); col++)
                    {
                        if (col > row)
                        {
                            matrix[row, col] = matrix[row, col - 1] + n - (col - 1) + row;
                        }
                        else
                        {
                            matrix[row, col] = matrix[row, col - 1] + n - row + col;
                        }
                    }
                }
            }

            else if (character == 'd')
            {
                int currentNumber = 0;
                int sideLength = n;
                for (int i = 0; i < n / 2; i++)
                {
                    int j;

                    for (j = 0; j < sideLength; j++)
                    {
                        matrix[i + j, i] = ++currentNumber;
                    }
                    for (j = 1; j < sideLength - 1; j++)
                    {
                        matrix[n - 1 - i, i + j] = ++currentNumber;
                    }
                    for (j = sideLength - 1; j > 0; j--)
                    {
                        matrix[i + j, n - 1 - i] = ++currentNumber;
                    }
                    for (j = sideLength - 1; j > 0; j--)
                    {
                        matrix[i, i + j] = ++currentNumber;
                    }
                    sideLength -= 2;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}", matrix[i, j]);
                    if (j < matrix.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
