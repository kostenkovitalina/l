using System;
using System.Collections.Generic;

class MainClassVariant2B
{
    public static void RunVariant2B(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        long memoryBefore = GC.GetTotalMemory(true);
        List<List<int>> numbers = GenerateNumbersB(n);

        Console.WriteLine("Memory used for 2b: " + (GC.GetTotalMemory(true) - memoryBefore) + " bytes");

        Console.WriteLine("Result for 2b:");
        PrintNumbers(numbers);
        Console.ReadKey();
    }

    private static List<List<int>> GenerateNumbersB(int n)
    {
        List<List<int>> numbers = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            int sum = DigitSum(i);
            if (sum == 0) continue; // Перевірка на 0
            int count = CountMultiples(n, sum);
            while (numbers.Count <= sum)
            {
                numbers.Add(new List<int>());
            }

            for (int j = 1; j <= n; j++)
            {
                if (j % sum == 0)
                {
                    numbers[sum].Add(j);
                }
            }
        }

        return numbers;
    }

    private static int DigitSum(int num)
    {
        int sum = 0;
        while (num != 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    private static int CountMultiples(int n, int divisor)
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

    private static void PrintNumbers(List<List<int>> numbers)
    {
        foreach (var list in numbers)
        {
            foreach (var num in list)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
