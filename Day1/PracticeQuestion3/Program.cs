using System;

class Program
{
    static void Main()
    {
        double length;
        double width;
        double height;

        Console.Write("Enter length: ");

        while (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Invalid length. Please enter a positive numeric value.");
            Console.Write("Enter length: ");
        }

        Console.Write("Enter width: ");

        while (!double.TryParse(Console.ReadLine(), out width) || width <= 0)
        {
            Console.WriteLine("Invalid width. Please enter a positive numeric value.");
            Console.Write("Enter width: ");
        }

        Console.Write("Enter height: ");

        while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Invalid height. Please enter a positive numeric value.");
            Console.Write("Enter height: ");
        }

        double volume = length * width * height;

        Console.WriteLine("\n----- PACKAGE VOLUME -----");
        Console.WriteLine($"Volume: {volume:F2}");
    }
}