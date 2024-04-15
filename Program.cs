using System;

class Program
{
    {
        while (true)
        {

            int choice = GetChoice();

            switch (choice)
            {
                default:
                    break;
            }
        }
    }

    {
        {
        }
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

