using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Available branches:");
        Console.WriteLine("1. Vitalina");
        Console.WriteLine("2. Kristina");
        Console.Write("Enter the number of the branch you want to switch to: ");

        // Get user input
        int choice = int.Parse(Console.ReadLine());

        // Switch based on user choice
        switch (choice)
        {
            case 1:
                SwitchBranch("Vitalina");
                break;
            case 2:
                SwitchBranch("Kristina");
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                break;
        }

        Console.ReadLine(); // Keep console window open
    }

    static void SwitchBranch(string branchName)
    {
        // Stash local changes
        string stashCommand = "git stash";
        string stashOutput = ExecuteCommand(stashCommand);
        Console.WriteLine(stashOutput);

        // Execute git command to switch branch
        string gitCommand = $"git checkout {branchName}";
        string output = ExecuteCommand(gitCommand);
        Console.WriteLine(output);
        Console.WriteLine($"Switched to branch: {branchName}");

        // Apply stashed changes if any
        string applyStashCommand = "git stash pop --quiet";

        string applyStashOutput = ExecuteCommand(applyStashCommand);
        Console.WriteLine(applyStashOutput);
    }
    static string ExecuteCommand(string command)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}", // Додаємо ключ /c для виконання команди і вихід з cmd.exe після завершення
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process proc = new Process { StartInfo = psi })
        {
            proc.Start();
            proc.WaitForExit(); // Чекаємо завершення процесу

            if (proc.ExitCode != 0) // Перевіряємо, чи процес завершився успішно
            {
                string errorMessage = proc.StandardError.ReadToEnd();
                throw new Exception($"Error executing command: {errorMessage}");
            }

            string output = proc.StandardOutput.ReadToEnd();
            return output;
        }
    }

}


