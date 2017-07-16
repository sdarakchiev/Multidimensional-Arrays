using System;

namespace FillTheMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char character = char.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int currentValue = 1;

            if (character == 'a')
            {
                for (int col = 0; col < n; col++)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = currentValue++;
                    }
                }
            }
            else if (character == 'b')
            {
                for (int col = 0; col < n; col++)
                {
                    if (col % 2 == 0)
                    {
                        for (int row = 0; row < n; row++)
                        {
                            matrix[row, col] = currentValue++;
                        }
                    }
                    else
                    {
                        for (int row = n - 1; row > -1; row--)
                        {
                            matrix[row, col] = currentValue++;
                        }
                    }
                }
            }
            else if (character == 'c')
            {
                int currentRow = 0;
                int currentCol = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    currentRow = i;
                    currentCol = 0;
                    while (currentRow < n && currentCol < n)
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentRow++;
                        currentCol++;
                        currentValue++;

                    }
                }
                for (int i = 1; i < n; i++)
                {
                    currentRow = 0;
                    currentCol = i;
                    while (currentRow < n && currentCol < n)
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentRow++;
                        currentCol++;
                        currentValue++;
                    }
                }
            }
            else if (character == 'd')
            {
                int currentRow = 0;
                int currentCol = 0;
                string direction = "down";

                while (currentValue <= n*n)
                {
                    if (direction == "down")
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentRow++;
                        if (currentRow > matrix.GetLength(0) - 1 || matrix[currentRow, currentCol] != 0)
                        {
                            direction = "right";
                            currentRow--;
                        }
                    }
                    if (direction == "right")
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentCol++;
                        if (currentCol > matrix.GetLength(1) - 1 || matrix[currentRow, currentCol] != 0)
                        {
                            direction = "up";
                            currentCol--;
                        }
                    }
                    if (direction == "up")
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentRow--;
                        if (currentRow < 0 || matrix[currentRow, currentCol] != 0)
                        {
                            direction = "left";
                            currentRow++;
                        }
                    }
                    if (direction == "left")
                    {
                        matrix[currentRow, currentCol] = currentValue;
                        currentCol--;
                        if (currentCol < 0)
                        {
                            direction = "down";
                            currentCol++;
                        }
                        if (matrix[currentRow, currentCol] != 0)
                        {
                            direction = "down";
                            currentCol++;
                            currentRow++;
                        }
                    }
                    currentValue++;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
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
