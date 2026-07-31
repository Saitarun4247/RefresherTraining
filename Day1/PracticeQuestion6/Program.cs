using System;

interface IElectricityBill
{
    double CalculateBill(double units, double rate, double fixedCharges);
}

class ResidentialCustomer : IElectricityBill
{
    public double CalculateBill(double units, double rate, double fixedCharges)
    {
        return (units * rate) + fixedCharges;
    }
}

class CommercialCustomer : IElectricityBill
{
    public double CalculateBill(double units, double rate, double fixedCharges)
    {
        double energyCharge = units * rate;
        double surcharge = energyCharge * 0.10;

        return energyCharge + surcharge + fixedCharges;
    }
}

class Program
{
    static void Main()
    {
        int customerType;
        double units;
        double rate;
        double fixedCharges;

        Console.WriteLine("----- ELECTRICITY BILL CALCULATOR -----");
        Console.WriteLine("1. Residential");
        Console.WriteLine("2. Commercial");
        Console.Write("Enter customer type: ");

        while (!int.TryParse(Console.ReadLine(), out customerType) ||
               (customerType != 1 && customerType != 2))
        {
            Console.WriteLine("Invalid customer type. Please enter 1 or 2.");
            Console.Write("Enter customer type: ");
        }

        Console.Write("Enter units consumed: ");

        while (!double.TryParse(Console.ReadLine(), out units) || units < 0)
        {
            Console.WriteLine("Invalid units. Please enter a non-negative number.");
            Console.Write("Enter units consumed: ");
        }

        Console.Write("Enter rate per unit: ");

        while (!double.TryParse(Console.ReadLine(), out rate) || rate < 0)
        {
            Console.WriteLine("Invalid rate. Please enter a non-negative number.");
            Console.Write("Enter rate per unit: ");
        }

        Console.Write("Enter fixed charges: ");

        while (!double.TryParse(Console.ReadLine(), out fixedCharges) || fixedCharges < 0)
        {
            Console.WriteLine("Invalid fixed charges. Please enter a non-negative number.");
            Console.Write("Enter fixed charges: ");
        }

        IElectricityBill customer;

        if (customerType == 1)
        {
            customer = new ResidentialCustomer();
        }
        else
        {
            customer = new CommercialCustomer();
        }

        double bill = customer.CalculateBill(units, rate, fixedCharges);

        bill = Math.Round(bill, 2);

        Console.WriteLine("\n----- BILL DETAILS -----");

        if (customerType == 1)
        {
            Console.WriteLine("Customer Type: Residential");
        }
        else
        {
            Console.WriteLine("Customer Type: Commercial");
        }

        Console.WriteLine($"Units Consumed: {units}");
        Console.WriteLine($"Rate Per Unit: {rate:F2}");
        Console.WriteLine($"Fixed Charges: {fixedCharges:F2}");
        Console.WriteLine($"Total Bill: {bill:F2}");
    }
}