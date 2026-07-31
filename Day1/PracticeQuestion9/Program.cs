using System;

class Patient
{
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Temperature { get; set; }

    public double CalculateBMI()
    {
        return Weight / (Height * Height);
    }
}

class InputValidator
{
    public int GetValidAge()
    {
        int age;

        Console.Write("Enter patient age: ");

        while (!int.TryParse(Console.ReadLine(), out age) ||
               age <= 0 || age > 120)
        {
            Console.WriteLine("Invalid age. Enter an age between 1 and 120.");
            Console.Write("Enter patient age: ");
        }

        return age;
    }

    public double GetValidWeight()
    {
        double weight;

        Console.Write("Enter weight in kg: ");

        while (!double.TryParse(Console.ReadLine(), out weight) ||
               weight <= 0 || weight > 500)
        {
            Console.WriteLine("Invalid weight. Enter a value between 0 and 500 kg.");
            Console.Write("Enter weight in kg: ");
        }

        return weight;
    }

    public double GetValidHeight()
    {
        double height;

        Console.Write("Enter height in meters: ");

        while (!double.TryParse(Console.ReadLine(), out height) ||
               height <= 0 || height > 3)
        {
            Console.WriteLine("Invalid height. Enter a value between 0 and 3 meters.");
            Console.Write("Enter height in meters: ");
        }

        return height;
    }

    public double GetValidTemperature()
    {
        double temperature;

        Console.Write("Enter body temperature in Celsius: ");

        while (!double.TryParse(Console.ReadLine(), out temperature) ||
               temperature < 25 || temperature > 45)
        {
            Console.WriteLine("Invalid temperature. Enter a value between 25 and 45 Celsius.");
            Console.Write("Enter body temperature in Celsius: ");
        }

        return temperature;
    }
}

class Program
{
    static void Main()
    {
        InputValidator validator = new InputValidator();

        Patient patient = new Patient();

        patient.Age = validator.GetValidAge();
        patient.Weight = validator.GetValidWeight();
        patient.Height = validator.GetValidHeight();
        patient.Temperature = validator.GetValidTemperature();

        double bmi = patient.CalculateBMI();
        bmi = Math.Round(bmi, 2);

        Console.WriteLine("\n----- PATIENT SUMMARY -----");
        Console.WriteLine($"Age: {patient.Age} years");
        Console.WriteLine($"Weight: {patient.Weight:F2} kg");
        Console.WriteLine($"Height: {patient.Height:F2} m");
        Console.WriteLine($"Temperature: {patient.Temperature:F2} °C");
        Console.WriteLine($"BMI: {bmi:F2}");
    }
}