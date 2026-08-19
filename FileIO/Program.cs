using System;
using System.IO;

class Program
{
    static void FilterErrorLogs()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        string[] lines = File.ReadAllLines(inputFile);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }

    static void Main()
    {
        FilterErrorLogs();

        Console.WriteLine("ERROR logs saved to error.txt");
    }
}