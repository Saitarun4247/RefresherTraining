using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList numbers = new ArrayList();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "add")
            {
                AddNumber(numbers);
            }
            else if (command == "remove")
            {
                RemoveNumber(numbers);
            }
            else if (command == "display")
            {
                DisplayNumbers(numbers);
            }
            else if (command == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid command.");
                break;
            }
        }
    }

    private static void AddNumber(ArrayList numbers)
    {
        try
        {
            int num = int.Parse(Console.ReadLine());

            numbers.Add(num);

            Console.WriteLine($"{num} added to the number list.");
        }
        catch
        {
            Console.WriteLine(
                "Invalid input. Please enter a valid number.");
        }
    }

    private static void RemoveNumber(ArrayList numbers)
    {
        try
        {
            int num = int.Parse(Console.ReadLine());

            if (numbers.Contains(num))
            {
                numbers.Remove(num);

                Console.WriteLine(
                    $"{num} removed from the number list.");
            }
            else
            {
                Console.WriteLine(
                    $"{num} not found in the number list.");
            }
        }
        catch
        {
            Console.WriteLine(
                "Invalid input. Please enter a valid number.");
        }
    }

    private static void DisplayNumbers(ArrayList numbers)
    {
        Console.WriteLine("Current numbers in the list:");

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}