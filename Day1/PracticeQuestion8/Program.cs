using System;

interface IShippingCalculator
{
    double CalculateShippingCost(double weight, double distance);
}

class StandardPackage : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return weight * distance * 0.05;
    }
}

class ExpressPackage : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return weight * distance * 0.08;
    }
}

class PremiumPackage : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return weight * distance * 0.12;
    }
}

class Program
{
    static void Main()
    {
        int packageType;
        double weight;
        double distance;

        Console.WriteLine("----- SHIPPING COST CALCULATOR -----");
        Console.WriteLine("1. Standard Package");
        Console.WriteLine("2. Express Package");
        Console.WriteLine("3. Premium Package");
        Console.Write("Enter package type: ");

        while (!int.TryParse(Console.ReadLine(), out packageType) ||
               packageType < 1 || packageType > 3)
        {
            Console.WriteLine("Invalid package type. Please enter 1, 2, or 3.");
            Console.Write("Enter package type: ");
        }

        Console.Write("Enter package weight in kg: ");

        while (!double.TryParse(Console.ReadLine(), out weight) ||
               weight <= 0 || weight > 10000)
        {
            Console.WriteLine("Invalid weight. Enter a value between 0 and 10000 kg.");
            Console.Write("Enter package weight in kg: ");
        }

        Console.Write("Enter shipping distance in km: ");

        while (!double.TryParse(Console.ReadLine(), out distance) ||
               distance <= 0 || distance > 100000)
        {
            Console.WriteLine("Invalid distance. Enter a value between 0 and 100000 km.");
            Console.Write("Enter shipping distance in km: ");
        }

        IShippingCalculator calculator;

        if (packageType == 1)
        {
            calculator = new StandardPackage();
        }
        else if (packageType == 2)
        {
            calculator = new ExpressPackage();
        }
        else
        {
            calculator = new PremiumPackage();
        }

        double shippingCost = calculator.CalculateShippingCost(weight, distance);

        if (double.IsInfinity(shippingCost) || double.IsNaN(shippingCost))
        {
            Console.WriteLine("Unable to calculate shipping cost.");
            return;
        }

        shippingCost = Math.Round(shippingCost, 2);

        Console.WriteLine("\n----- SHIPPING DETAILS -----");

        if (packageType == 1)
        {
            Console.WriteLine("Package Type: Standard");
        }
        else if (packageType == 2)
        {
            Console.WriteLine("Package Type: Express");
        }
        else
        {
            Console.WriteLine("Package Type: Premium");
        }

        Console.WriteLine($"Weight: {weight:F2} kg");
        Console.WriteLine($"Distance: {distance:F2} km");
        Console.WriteLine($"Shipping Cost: {shippingCost:F2}");
    }
}