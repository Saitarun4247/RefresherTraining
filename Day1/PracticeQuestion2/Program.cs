using System;

class Program
{
    static void Main()
    {
        double weight;
        double height;

        Console.Write("Enter weight in kg: ");

        while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
        {
            Console.WriteLine("Invalid weight. Please enter a positive numeric value.");
            Console.Write("Enter weight in kg: ");
        }

        Console.Write("Enter height in meters: ");

        while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Invalid height. Please enter a positive numeric value.");
            Console.Write("Enter height in meters: ");
        }

        double bmi = weight / (height * height);

        bmi = Math.Round(bmi, 2);

        string category;

        if (bmi < 18.5)
        {
            category = "Underweight";
        }
        else if (bmi < 25)
        {
            category = "Normal weight";
        }
        else if (bmi < 30)
        {
            category = "Overweight";
        }
        else
        {
            category = "Obese";
        }

        Console.WriteLine("\n----- BMI RESULT -----");
        Console.WriteLine($"BMI: {bmi:F2}");
        Console.WriteLine($"Category: {category}");
    }
}