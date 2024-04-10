using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of rows in matrix P: ");
            int rowsP = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns in matrix P: ");
            int colsP = int.Parse(Console.ReadLine());

            int[,] matrixP = new int[rowsP, colsP];

            for (int i = 0; i < rowsP; i++)
            {
                Console.WriteLine($"Enter the elements for row {i + 1}:");
                for (int j = 0; j < colsP; j++)
                {
                    Console.Write($"Element[{i},{j}]: ");
                    matrixP[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[] arrayZ = new int[rowsP];
            for (int i = 0; i < rowsP; i++)
            {
                int zerosCount = 0;
                for (int j = 0; j < colsP; j++)
                {
                    if (matrixP[i, j] == 0)
                        zerosCount++;
                }
                arrayZ[i] = zerosCount;
            }

            int[,] matrixQ = new int[rowsP, colsP];
            Random random = new Random();

            for (int i = 0; i < rowsP; i++)
            {
                for (int j = 0; j < colsP; j++)
                {
                    if (j < arrayZ[i])
                        matrixQ[i, j] = random.Next(100);
                }
            }

            for (int i = 0; i < rowsP; i++)
            {
                for (int j = 0; j < arrayZ[i]; j++)
                {
                    for (int k = j + 1; k < colsP; k++)
                    {
                        if (matrixQ[i, j] < matrixQ[i, k])
                        {
                            int temp = matrixQ[i, j];
                            matrixQ[i, j] = matrixQ[i, k];
                            matrixQ[i, k] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("\nMatrix Q (sorted rows):");
            for (int i = 0; i < rowsP; i++)
            {
                for (int j = 0; j < colsP; j++)
                {
                    if (j < arrayZ[i])
                        Console.Write(matrixQ[i, j] + " ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}