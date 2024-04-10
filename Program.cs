using System;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть гілку для запуску (Vitalina або Kristina):");
        string branchName = Console.ReadLine();

        switch (branchName)
        {
            case "Vitalina":
                OpenAndRunGitHubFile("Vitalina/start-programs.cs");
                break;
            case "Kristina":
                OpenAndRunGitHubFile("Kristina/назва_файлу.cs");
                break;
            default:
                Console.WriteLine("Невідома гілка");
                break;
        }
    }

    static void OpenAndRunGitHubFile(string branchName)
    {
        // Відкриваємо файл та запускаємо його
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c start {branchName}/start-programs.cs & dotnet run",
            UseShellExecute = true,
            WorkingDirectory = @"https://github.com/kostenkovitalina/l.git"
        });
    }
}





