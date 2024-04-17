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
        // Create ProcessStartInfo
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Start the process
        Process proc = new Process { StartInfo = psi };
        proc.Start();

        // Execute the command
        proc.StandardInput.WriteLine(command);
        proc.StandardInput.Flush();
        proc.StandardInput.Close();

        // Get output and errors
        string output = proc.StandardOutput.ReadToEnd();
        string errors = proc.StandardError.ReadToEnd();

        proc.WaitForExit();

        // Check for errors
        if (!string.IsNullOrEmpty(errors))
        {
            throw new Exception($"Error executing command: {errors}");
        }

        return output;
    }
}


