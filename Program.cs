using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Виконати варіант студента Віталіна");
            Console.WriteLine("2. Виконати варіант студента Крістіна");
            Console.WriteLine("3. Перестворити масив");
            Console.WriteLine("6. Вийти з програми");

            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    ExecuteVariant_Vitalina();
                    break;
                case 2:
                    ExecuteVariant_Kristina();
                    break;
                case 3:
                    RecreateArray();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static int GetChoice()
    {
        Console.Write("Ваш вибір: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.WriteLine("Неправильне значення. Введіть число від 1 до 6.");
            Console.Write("Ваш вибір: ");
        }
        return choice;
    }

}

