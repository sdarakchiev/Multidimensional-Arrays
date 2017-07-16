using System;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
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

            int currentSum = 0;
            int maximalSum = int.MinValue;

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < m - 2; j++)
                {
                    currentSum = matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j] +
                                 matrix[i, j + 1] + matrix[i + 1, j + 1] + matrix[i + 2, j + 1] +
                                 matrix[i, j + 2] + matrix[i + 1, j + 2] + matrix[i + 2, j + 2];

                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maximalSum);
        }
    }
}
