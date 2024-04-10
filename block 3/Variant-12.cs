using System;

class MainClassVariant12
{
    public static void RunVariant12(string[] args)
    {
        Console.WriteLine("Enter the number of array lines:");
        int rowCount = int.Parse(Console.ReadLine());

        int[][] array = new int[rowCount][];

        for (int i = 0; i < rowCount; i++)
        {
            Console.WriteLine($"Enter string {i + 1} (elements are separated by a space):");
            string[] elements = Console.ReadLine().Split(' ');
            array[i] = new int[elements.Length];
            for (int j = 0; j < elements.Length; j++)
            {
                array[i][j] = int.Parse(elements[j]);
            }
        }

        int maxRowIndex = FindMaxRowIndex(array);
        array = AddRow(array, maxRowIndex);

        Console.WriteLine("Result:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"String {i + 1}: ");
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
            if (i == maxRowIndex)
            {
                Console.WriteLine($"  ^ A new line is added after this line because it contains the maximum value at the end.");
            }
        }
        Console.ReadKey();
    }

    static int FindMaxRowIndex(int[][] array)
    {
        int maxRowIndex = array.Length - 1;
        int maxValue = array[maxRowIndex][array[maxRowIndex].Length - 1];

        for (int i = array.Length - 2; i >= 0; i--)
        {
            if (array[i][array[i].Length - 1] >= maxValue)
            {
                maxRowIndex = i;
                maxValue = array[i][array[i].Length - 1];
            }
        }

        return maxRowIndex;
    }

    static int[][] AddRow(int[][] array, int maxRowIndex)
    {
        int[][] newArray = new int[array.Length + 1][];

        for (int i = 0; i <= maxRowIndex; i++)
        {
            newArray[i] = array[i];
        }

        int[] newRow = new int[array[maxRowIndex].Length];
        Array.Copy(array[maxRowIndex], newRow, newRow.Length);
        newArray[maxRowIndex + 1] = newRow;

        for (int i = maxRowIndex + 1; i < array.Length; i++)
        {
            newArray[i + 1] = array[i];
        }

        return newArray;
    }
}


