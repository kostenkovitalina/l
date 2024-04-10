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

    static List<List<int>> GenerateSequences(int n)
    {
        List<List<int>> sequences = new List<List<int>>();
        Dictionary<int, List<int>> digitSumMap = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++)
        {
            int digitSum = CalculateDigitSum(i);
            if (!digitSumMap.ContainsKey(digitSum))
            {
                digitSumMap[digitSum] = new List<int>();
            }
            digitSumMap[digitSum].Add(i);
        }

        for (int i = 0; i < n; i++)
        {
            if (!digitSumMap.ContainsKey(i))
            {
                sequences.Add(new List<int>());
            }
            else
            {
                sequences.Add(digitSumMap[i]);
            }
        }

        return sequences;
    }

    static void Main()
    {
        Console.Write("Enter a positive integer n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        long memoryBefore = GC.GetTotalMemory(true);

        List<List<int>> sequences = GenerateSequences(n);

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