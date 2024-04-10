using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть гілку для запуску (Vitalina або Kristina):");
        string branchName = Console.ReadLine();

        switch (branchName)
        {
            case "Vitalina":
                RunFileFromBranch("Vitalina", "start-programs.cs");
                break;
            case "Kristina":
                RunFileFromBranch("Kristina", "назва_файлу.cs");
                break;
            default:
                Console.WriteLine("Невідома гілка");
                break;
        }
    }

    static void RunFileFromBranch(string branchName, string fileName)
    {
        string filePath = Path.Combine(branchName, fileName);

        if (File.Exists(filePath))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true,
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
            });
        }
        else
        {
            Console.WriteLine("Файл не знайдено");
        }
    }
}




