using System;

public class Solution
{
    public static void Main()
    {
        Console.Write("Enter Current Temperature: ");
        double currentTemp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Previous Temperature: ");
        double previousTemp = Convert.ToDouble(Console.ReadLine());

        // Temperature Alert
        if (currentTemp < 0)
        {
            Console.WriteLine("Freezing Alert! Risk of ice formation.");
        }
        else if (currentTemp >= 0 && currentTemp <= 10)
        {
            Console.WriteLine("Cold Alert. Wear warm clothing.");
        }
        else if (currentTemp >= 11 && currentTemp <= 25)
        {
            Console.WriteLine("Comfortable temperature. No alerts.");
        }
        else if (currentTemp >= 26 && currentTemp <= 35)
        {
            Console.WriteLine("Heat Alert. Stay hydrated.");
        }
        else
        {
            Console.WriteLine("Extreme Heat Warning! Avoid outdoor activities.");
        }

        // Rapid Temperature Change Alert
        if (Math.Abs(currentTemp - previousTemp) > 10)
        {
            Console.WriteLine("Rapid temperature change detected!");
        }
    }
}