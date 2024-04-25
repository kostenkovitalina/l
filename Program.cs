using System;

partial class ExecuteVariant_Vitalina
{
    static void ExecuteVariant(string[] args)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1.Vitalina");
        Console.WriteLine("2.Kristina");
        Console.Write("Enter your choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ExecuteVariant_Vitalina.ExecuteVariant(args);
                break;
            case 2:
                Kris.Kris(args);
                break;
            default:
                break;
        }
    }
}