using System;

class MainClassVariant9
{
    public static void RunVariant9(string[] args)
    {
        Console.WriteLine("Enter the array elements separated by a space:");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(' ');
        int[] array = Array.ConvertAll(inputArray, int.Parse);

        Console.WriteLine("Input array:");
        PrintArray(array);

        ExecuteTransformation(ref array);

        Console.WriteLine("Result:");
        PrintArray(array);
        Console.ReadKey();
    }

    static void PrintArray(int[] arr)
    {
        foreach (int element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void FindMinMaxIndices(int[] arr, out int maxIndex, out int minIndex)
    {
        maxIndex = 0;
        minIndex = 0;
        int max = arr[0];
        int min = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
            else if (arr[i] < min)
            {
                min = arr[i];
                minIndex = i;
            }
        }
    }

    static void ExecuteTransformation(ref int[] arr)
    {
        int maxIndex, minIndex;
        FindMinMaxIndices(arr, out maxIndex, out minIndex);

        int startIndex = Math.Min(maxIndex, minIndex);
        int endIndex = Math.Max(maxIndex, minIndex);

        // Перевіряємо, чи є елементи для видалення
        if (startIndex >= endIndex)
        {
            Console.WriteLine("Результат: Пустий рядок, тому що недостатньо елементів між першим мінімальним і максимальним значеннями.");
            return;
        }

        int elementsToRemove = endIndex - startIndex + 1;

        // Видалення елементів з масиву
        Array.Copy(arr, endIndex + 1, arr, startIndex, arr.Length - endIndex - 1);
        Array.Resize(ref arr, arr.Length - elementsToRemove);
    }
}
