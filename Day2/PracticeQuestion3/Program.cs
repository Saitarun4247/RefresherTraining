using System;

enum LogLevel
{
    Info,
    Warning,
    Error,
    Unknown
}

class Program
{
    static bool ParseLogLine(
        in string logLine,
        out DateTime timestamp,
        out LogLevel logLevel,
        ref int counter)
    {
        counter++;

        timestamp = default;
        logLevel = LogLevel.Unknown;

        if (string.IsNullOrWhiteSpace(logLine) || logLine.Length < 19)
        {
            return false;
        }

        string timestampText = logLine.Substring(0, 19);

        if (!DateTime.TryParse(timestampText, out timestamp))
        {
            return false;
        }

        string remainingText = logLine.Substring(19).Trim();

        if (remainingText.StartsWith("ERROR", StringComparison.OrdinalIgnoreCase))
        {
            logLevel = LogLevel.Error;
        }
        else if (remainingText.StartsWith("WARNING", StringComparison.OrdinalIgnoreCase))
        {
            logLevel = LogLevel.Warning;
        }
        else if (remainingText.StartsWith("INFO", StringComparison.OrdinalIgnoreCase))
        {
            logLevel = LogLevel.Info;
        }
        else
        {
            logLevel = LogLevel.Unknown;
        }

        return true;
    }

    static void Main()
    {
        string logLine = "2023-10-27 14:30:00 ERROR: Disk full";
        int counter = 0;

        bool success = ParseLogLine(
            in logLine,
            out DateTime timestamp,
            out LogLevel logLevel,
            ref counter
        );

        if (success)
        {
            Console.WriteLine($"Timestamp: {timestamp:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"LogLevel: {logLevel}");
        }
        else
        {
            Console.WriteLine("Invalid log line.");
        }

        Console.WriteLine($"Counter after call: {counter}");
    }
}