using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int CalculateDigitSum(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static int[][] GenerateSequences(int n)
    {
        int[][] sequences = new int[n][];

        for (int i = 0; i < n; i++)
        {
            int digitSum = CalculateDigitSum(i);
            int[] sequence = new int[digitSum + 1];

            for (int j = 0; j <= digitSum; j++)
            {
                sequence[j] = i;
            }

            sequences[i] = sequence;
        }

        return sequences;
    }

    static void Main()
    {
        Console.Write("Enter a positive integer n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        long memoryBefore = GC.GetTotalMemory(true);

        int[][] sequences = GenerateSequences(n);

        Console.WriteLine("Number sequences:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Numbers divisible by the digit sum of {i}: ");
            Console.WriteLine(string.Join(", ", sequences[i]));
        }

        long memoryAfter = GC.GetTotalMemory(true);
        long memoryUsed = memoryAfter - memoryBefore;

        Console.WriteLine($"Memory used: {memoryUsed} bytes");
        Console.ReadLine();
    }
}