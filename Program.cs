using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Available branches:");
        Console.WriteLine("1. Switch to Vitalina branch");
        Console.WriteLine("2. Switch to Kristina branch");
        Console.Write("Enter the number of the branch you want to switch to: ");

        int choice = int.Parse(Console.ReadLine());

        // Перемикаємося на гілку згідно вибору користувача
        switch (choice)
        {
            case 1:
                SwitchToBranch("Vitalina");
                break;
            case 2:
                SwitchToBranch("Kristina");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.ReadLine(); // Зберігаємо вікно консолі відкритим
    }

    static void SwitchToBranch(string branchName)
    {
        // Виконуємо git команду для перемикання на іншу гілку
        string gitCommand = $"git checkout {branchName}";
        ExecuteCommand(gitCommand);
        Console.WriteLine($"Switched to branch: {branchName}");

        // Викликаємо потрібний файл
        string filePath = (branchName == "Vitalina") ? "start-programs.cs" : "other-file.cs";
        RunFile(filePath);
    }

    static void RunFile(string filePath)
    {
        string dotnetCommand = $"dotnet run {filePath}";
        ExecuteCommand(dotnetCommand);
    }

    static void ExecuteCommand(string command)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process proc = new Process { StartInfo = psi };
        proc.Start();

        proc.StandardInput.WriteLine(command);
        proc.StandardInput.Flush();
        proc.StandardInput.Close();

        string output = proc.StandardOutput.ReadToEnd();
        string errors = proc.StandardError.ReadToEnd();

        proc.WaitForExit();

        if (!string.IsNullOrEmpty(errors))
        {
            throw new Exception($"Error executing command: {errors}");
        }

        Console.WriteLine(output);
    }
}


