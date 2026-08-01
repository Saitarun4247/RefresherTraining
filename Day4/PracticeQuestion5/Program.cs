using System;

public class Solution
{
    public static void Main()
    {
        Console.Write("Enter Weight (kg): ");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Height (m): ");
        double height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Are you an Athlete? (Y/N): ");
        char isAthlete = Convert.ToChar(Console.ReadLine().ToUpper());

        // Calculate BMI
        double bmi = weight / (height * height);

        Console.WriteLine("\nBMI: " + bmi.ToString("F2"));

        // BMI Classification
        if (bmi < 18.5)
        {
            Console.WriteLine("Health Classification: Underweight");

            double targetWeight = 18.5 * height * height;
            Console.WriteLine("Recommendation: Gain " +
                (targetWeight - weight).ToString("F2") +
                " kg to reach the normal BMI range.");
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            Console.WriteLine("Health Classification: Normal");
            Console.WriteLine("Recommendation: Maintain your current weight.");
        }
        else if (bmi >= 25 && bmi < 30)
        {
            Console.WriteLine("Health Classification: Overweight");

            double targetWeight = 24.9 * height * height;
            Console.WriteLine("Recommendation: Lose " +
                (weight - targetWeight).ToString("F2") +
                " kg to reach the normal BMI range.");
        }
        else
        {
            Console.WriteLine("Health Classification: Obese");

            double targetWeight = 24.9 * height * height;
            Console.WriteLine("Recommendation: Lose " +
                (weight - targetWeight).ToString("F2") +
                " kg to reach the normal BMI range.");
        }

        // Athlete Message
        if (isAthlete == 'Y')
        {
            Console.WriteLine("Note: BMI may not accurately reflect body fat for athletes because higher muscle mass can increase BMI.");
        }
    }
}