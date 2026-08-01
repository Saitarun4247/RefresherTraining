using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public record Student(string Name, int Score);

public class Program
{
    public static string GetStudentsJson(string[] items, int minScore)
    {
        var students = new List<Student>();

        foreach (var item in items)
        {
            string[] parts = item.Split(':');
            students.Add(new Student(parts[0], int.Parse(parts[1])));
        }

        var result = students
            .Where(s => s.Score >= minScore)
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .ToList();

        return JsonSerializer.Serialize(result);
    }

    public static void Main()
    {
        string[] items =
        {
            "Alice:90",
            "Bob:85",
            "Charlie:90",
            "David:70"
        };

        int minScore = 80;

        string json = GetStudentsJson(items, minScore);
        Console.WriteLine(json);
    }
}