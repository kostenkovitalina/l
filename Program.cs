using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Виберіть гілку для виклику:");
        string branchName = Console.ReadLine();

        CheckoutBranch(branchName); // Перехід на вказану гілку

        RunCodeFromBranch(branchName); // Запуск коду з вказаної гілки
    }

    static void CheckoutBranch(string branchName)
    {
        // Використовуйте git checkout для переходу на вказану гілку
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "git";
        psi.Arguments = "checkout " + branchName;
        Process.Start(psi).WaitForExit();
    }

    static void RunCodeFromBranch(string branchName)
    {
        // Перед запуском коду з гілки, переконайтеся, що ви перебуваєте на неї
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c dotnet run",
            WorkingDirectory = $"https://github.com/kostenkovitalina/l/blob/5cc24024675c934a7bf91bb7a59914eec3f1d8c1/start-programs.cs{branchName}" // Замініть шлях на реальний шлях до вашого проекту
        }).WaitForExit();
    }
}





