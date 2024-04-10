using System;

class Program
{
    static int[] array = null; // Масив, що буде використовуватись в програмі

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1 - Vitalina");
            Console.WriteLine("1 - Kristina");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static int[] CreateRandomArray()
    {
        Console.Write("Введіть розмір масиву: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(100); // Заповнюємо масив випадковими числами від 0 до 99
        }
        Console.WriteLine("Масив, заповнений випадково, створений успішно.");
        return array;
    }

    static int[] CreateArrayFromInput()
    {
        Console.Write("Введіть розмір масиву: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];
        Console.WriteLine("Введіть елементи масиву:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Масив, заповнений з клавіатури, створений успішно.");
        return array;
    }

