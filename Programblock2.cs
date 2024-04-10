using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a natural number n:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Results using jagged array:");
            var jaggedArrayResult = GenerateJaggedArray(n);
            PrintResults(jaggedArrayResult);

            Console.WriteLine("Results using dictionary:");
            var dictionaryResult = GenerateDictionaryResult(n);
            PrintResults(dictionaryResult);
        }

        static List<int>[] GenerateJaggedArray(int n)
        {
            var result = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                int sumOfDigits = CalculateSumOfDigits(i);
                result[i] = new List<int>();
                for (int j = 1; j <= n; j++)
                {
                    if (j % sumOfDigits == 0)
                    {
                        result[i].Add(j);
                    }
                }
            }
            return result;
        }

        static Dictionary<int, List<int>> GenerateDictionaryResult(int n)
        {
            var result = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                int sumOfDigits = CalculateSumOfDigits(i);
                if (!result.ContainsKey(sumOfDigits))
                {
                    result[sumOfDigits] = new List<int>();
                    for (int j = 1; j <= n; j++)
                    {
                        if (j % sumOfDigits == 0)
                        {
                            result[sumOfDigits].Add(j);
                        }
                    }
                }
            }
            return result;
        }

        static int CalculateSumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static void PrintResults(List<int>[] results)
        {
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"Numbers for {i}: {string.Join(", ", results[i])}");
            }
        }

        static void PrintResults(Dictionary<int, List<int>> results)
        {
            foreach (var kvp in results)
            {
                Console.WriteLine($"Numbers for sum of digits {kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
