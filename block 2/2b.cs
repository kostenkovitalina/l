using System;

class MainClassVariant2B
{
    public static void RunVariant2B(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        long memoryBefore = GC.GetTotalMemory(true);
        int[,] numbers = GenerateNumbersB(n);

        Console.WriteLine("Memory used for 2b: " + (GC.GetTotalMemory(true) - memoryBefore) + " bytes");

        Console.WriteLine("Result for 2b:");
        PrintNumbers(numbers);
        Console.ReadKey();
    }

    private static int[,] GenerateNumbersB(int n)
    {
        int[,] numbers = new int[n + 1, n + 1];

        for (int i = 1; i <= n; i++)
        {
            int sum = DigitSum(i);
            if (sum == 0) continue; // Перевірка на 0
            int count = CountMultiples(n, sum);

            for (int j = 1; j <= n; j++)
            {
                if (j % sum == 0)
                {
                    numbers[sum, count++] = j;
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

    private static void PrintNumbers(int[,] numbers)
    {
        int rows = numbers.GetLength(0);
        int cols = numbers.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols && numbers[i, j] != 0; j++)
            {
                Console.Write(numbers[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

