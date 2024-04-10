using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Enter the number of elements in row {i + 1}: ");
                int elementsCount = int.Parse(Console.ReadLine());

                jaggedArray[i] = new int[elementsCount];

                Console.WriteLine($"Enter the elements in row {i + 1}:");
                for (int j = 0; j < elementsCount; j++)
                {
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            int maxRow = 0;
            int maxElement = jaggedArray[0][0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > maxElement)
                    {
                        maxElement = jaggedArray[i][j];
                        maxRow = i;
                    }
                }
            }

            int[] newRow = new int[] { 99, 99, 99 };
            Array.Resize(ref jaggedArray, jaggedArray.Length + 1);
            Array.Copy(jaggedArray, maxRow + 1, jaggedArray, maxRow + 2, jaggedArray.Length - maxRow - 2);
            jaggedArray[maxRow + 1] = newRow;

            Console.WriteLine("\nJagged array after adding the row:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}