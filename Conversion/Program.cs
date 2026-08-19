using System;

class Program
{
    static double FeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;

        return Math.Round(
            centimeters,
            2,
            MidpointRounding.AwayFromZero
        );
    }

    static void Main()
    {
        int feet = int.Parse(Console.ReadLine());

        Console.WriteLine(
            FeetToCentimeters(feet).ToString("F2")
        );
    }
}