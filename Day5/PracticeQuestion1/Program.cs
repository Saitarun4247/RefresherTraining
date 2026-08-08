using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList studentNames = new ArrayList();

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "stop")
            {
                break;
            }

            if (!IsValidName(input))
            {
                continue;
            }

            if (IsNameInCollection(studentNames, input))
            {
                Console.WriteLine($"{input} is already in the collection.");
            }
            else
            {
                studentNames.Add(input);
                Console.WriteLine($"{input} added to the collection.");
            }
        }

        DisplayStudentNames(studentNames);
    }

    private static bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    private static bool IsNameInCollection(
        ArrayList studentNames,
        string name)
    {
        foreach (string existingName in studentNames)
        {
            if (existingName.Equals(
                name,
                StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static void DisplayStudentNames(ArrayList studentNames)
    {
        Console.WriteLine("Unique student names entered:");

        foreach (string name in studentNames)
        {
            Console.WriteLine(name);
        }
    }
}