using System;

class MainClassVariant15
{
    public static void RunVariant15()
    {
        Console.WriteLine("Enter the dimension of arrays R and S:");
        int size = int.Parse(Console.ReadLine());

        // Задані масиви R і S
        int[] R = new int[size];
        int[] S = new int[size];

        Console.WriteLine("Enter the elements of array R:");
        for (int i = 0; i < size; i++)
        {
            R[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Enter the elements of array S:");
        for (int i = 0; i < size; i++)
        {
            S[i] = int.Parse(Console.ReadLine());
        }

        // Створення квадратної матриці A
        int[,] A = new int[size, size];

        // Заповнення матриці A сумами елементів масивів R та S
        Console.WriteLine("Sum of elements for the matrix A:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                A[i, j] = R[i] + S[j];
                Console.WriteLine($"A[{i},{j}] = R[{i}] + S[{j}] = {R[i]} + {S[j]} = {A[i, j]}");
            }
        }

        // Вивід початкової матриці A
        Console.WriteLine("The original matrix A:");
        PrintMatrix(A);

        // Транспонування матриці A
        Transpose(A);

        // Інвертування порядку елементів у кожному рядку матриці A
        InvertRows(A);

        // Поміняти місцями перший і останній рядок матриці A
        SwapRows(A, 0, size - 1);

        // Вивід оновленої матриці A
        Console.WriteLine("Updated matrix A:");
        PrintMatrix(A);
        Console.ReadKey();
    }

    // Функція для транспонування матриці(перетворення рядків на стовбці)
    static void Transpose(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = temp;
            }
        }
    }

    // Функція для інвертування порядку елементів у кожному рядку(змінення елементів у масиві на протилежний)
    static void InvertRows(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size / 2; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, size - j - 1];
                matrix[i, size - j - 1] = temp;
            }
        }
    }

    // Функція для обміну рядків матриці
    static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int size = matrix.GetLength(1);
        for (int i = 0; i < size; i++)
        {
            int temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
    }

    // Функція для виводу матриці
    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
