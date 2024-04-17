using System;
using System.Diagnostics;

class MainClassVariant2A
{
    public static void RunVariant2A()
    {
        int n = int.Parse(Console.ReadLine());

        long memoryBefore = GC.GetTotalMemory(true);
        int[][] numbers = new int[n][]; //Зубчастий масив

        for (int i = 0; i < n; i++)
        {
            int sum = DigitSum(i);
            if (sum == 0) continue; // Перевірка на нуль
            int count = CountMultiples(n, sum);
            numbers[i] = new int[count];

            int index = 0;
            for (int j = 1; j <= n; j++)
            {
                if (j % sum == 0)
                {
                    numbers[i][index++] = j;
                }
            }
        }

        long memoryAfter = GC.GetTotalMemory(true);
        Console.WriteLine("Memory used: " + (memoryAfter - memoryBefore) + " bytes");
        PrintNumbers(numbers);
        Console.ReadKey();
    }

    static int DigitSum(int num)
    {
        int sum = 0;
        while (num != 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    static int CountMultiples(int n, int divisor)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % divisor == 0)
            {
                count++;
            }
        }
        return count;
    }

    static void PrintNumbers(int[][] numbers)
    {
        foreach (var row in numbers)
        {
            if (row != null)
            {
                foreach (var num in row)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
