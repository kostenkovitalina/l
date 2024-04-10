using System;

class MainClassVariant15
{
    public static void RunVariant15()
    {
        Console.WriteLine("Enter the number of rows in arrays R and S:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns in arrays R and S:");
        int columns = int.Parse(Console.ReadLine());

        // Задані масиви R і S
        int[,] R = new int[rows, columns];
        int[,] S = new int[rows, columns];

        Console.WriteLine("Enter the elements of array R:");
        InputMatrix(R);

        Console.WriteLine("Enter the elements of array S:");
        InputMatrix(S);

        // Створення матриці A
        int[,] A = new int[rows, columns];

        // Заповнення матриці A сумами елементів масивів R та S
        Console.WriteLine("Sum of elements for matrix A:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                A[i, j] = R[i, j] + S[i, j];
                Console.WriteLine($"A[{i},{j}] = R[{i},{j}] + S[{i},{j}] = {R[i, j]} + {S[i, j]} = {A[i, j]}");
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
        SwapRows(A, 0, rows - 1);

        // Вивід оновленої матриці A
        Console.WriteLine("Updated matrix A:");
        PrintMatrix(A);
        Console.ReadKey();
    }

    // Функція для транспонування матриці
    static void Transpose(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[,] transposed = new int[columns, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }
        Array.Copy(transposed, matrix, transposed.Length);
    }

    // Функція для інвертування порядку елементів у кожному рядку
    static void InvertRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns / 2; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, columns - j - 1];
                matrix[i, columns - j - 1] = temp;
            }
        }
    }

    // Функція для обміну рядків матриці
    static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int columns = matrix.GetLength(1);
        for (int i = 0; i < columns; i++)
        {
            int temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
    }

    // Функція для виводу матриці
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Функція для вводу елементів у матрицю
    static void InputMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Enter elements for row {i + 1}:");
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
}


