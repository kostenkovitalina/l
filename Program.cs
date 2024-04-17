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

        // Перевіряємо, чи вивід існує, перш ніж його читати
        if (!proc.StandardOutput.EndOfStream)
        {
            string output = proc.StandardOutput.ReadToEnd();
            return output;
        }

        return string.Empty; // Повертаємо порожній рядок, якщо вивід відсутній
    }
}


