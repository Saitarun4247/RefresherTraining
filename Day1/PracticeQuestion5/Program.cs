using System;

class Program
{
    static void Main()
    {
        double mark1;
        double mark2;
        double mark3;
        double mark4;
        double mark5;

        Console.Write("Enter mark for Subject 1: ");
        while (!double.TryParse(Console.ReadLine(), out mark1) || mark1 < 0 || mark1 > 100)
        {
            Console.WriteLine("Invalid mark. Please enter a value between 0 and 100.");
            Console.Write("Enter mark for Subject 1: ");
        }

        Console.Write("Enter mark for Subject 2: ");
        while (!double.TryParse(Console.ReadLine(), out mark2) || mark2 < 0 || mark2 > 100)
        {
            Console.WriteLine("Invalid mark. Please enter a value between 0 and 100.");
            Console.Write("Enter mark for Subject 2: ");
        }

        Console.Write("Enter mark for Subject 3: ");
        while (!double.TryParse(Console.ReadLine(), out mark3) || mark3 < 0 || mark3 > 100)
        {
            Console.WriteLine("Invalid mark. Please enter a value between 0 and 100.");
            Console.Write("Enter mark for Subject 3: ");
        }

        Console.Write("Enter mark for Subject 4: ");
        while (!double.TryParse(Console.ReadLine(), out mark4) || mark4 < 0 || mark4 > 100)
        {
            Console.WriteLine("Invalid mark. Please enter a value between 0 and 100.");
            Console.Write("Enter mark for Subject 4: ");
        }

        Console.Write("Enter mark for Subject 5: ");
        while (!double.TryParse(Console.ReadLine(), out mark5) || mark5 < 0 || mark5 > 100)
        {
            Console.WriteLine("Invalid mark. Please enter a value between 0 and 100.");
            Console.Write("Enter mark for Subject 5: ");
        }

        double total = mark1 + mark2 + mark3 + mark4 + mark5;
        double average = total / 5;
        double percentage = (total / 500) * 100;

        percentage = Math.Round(percentage, 2);

        Console.WriteLine("\n----- STUDENT RESULT -----");
        Console.WriteLine($"Total: {total:F2}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Percentage: {percentage:F2}%");
    }
}