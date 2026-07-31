using System;

interface IInvestmentCalculator
{
    double Calculate(double principal, double annualRate, double years);
}

class SimpleInterestInvestment : IInvestmentCalculator
{
    public double Calculate(double principal, double annualRate, double years)
    {
        double interest = principal * (annualRate / 100) * years;
        return principal + interest;
    }
}

class CompoundInterestInvestment : IInvestmentCalculator
{
    public double Calculate(double principal, double annualRate, double years)
    {
        return principal * Math.Pow(1 + (annualRate / 100), years);
    }
}

class Program
{
    static void Main()
    {
        int investmentType;
        double principal;
        double annualRate;
        double years;

        Console.WriteLine("----- INVESTMENT CALCULATOR -----");
        Console.WriteLine("1. Simple Interest");
        Console.WriteLine("2. Compound Interest");
        Console.Write("Enter investment type: ");

        while (!int.TryParse(Console.ReadLine(), out investmentType) ||
               investmentType < 1 || investmentType > 2)
        {
            Console.WriteLine("Invalid investment type. Enter 1 or 2.");
            Console.Write("Enter investment type: ");
        }

        Console.Write("Enter principal amount: ");

        while (!double.TryParse(Console.ReadLine(), out principal) ||
               principal <= 0 ||
               double.IsInfinity(principal) ||
               double.IsNaN(principal))
        {
            Console.WriteLine("Invalid principal amount. Enter a positive number.");
            Console.Write("Enter principal amount: ");
        }

        Console.Write("Enter annual interest rate (%): ");

        while (!double.TryParse(Console.ReadLine(), out annualRate) ||
               annualRate < 0 || annualRate > 100)
        {
            Console.WriteLine("Invalid rate. Enter a percentage between 0 and 100.");
            Console.Write("Enter annual interest rate (%): ");
        }

        Console.Write("Enter duration in years: ");

        while (!double.TryParse(Console.ReadLine(), out years) ||
               years <= 0 || years > 100)
        {
            Console.WriteLine("Invalid duration. Enter a value between 0 and 100 years.");
            Console.Write("Enter duration in years: ");
        }

        IInvestmentCalculator calculator;

        if (investmentType == 1)
        {
            calculator = new SimpleInterestInvestment();
        }
        else
        {
            calculator = new CompoundInterestInvestment();
        }

        double projectedValue =
            calculator.Calculate(principal, annualRate, years);

        if (double.IsInfinity(projectedValue) ||
            double.IsNaN(projectedValue))
        {
            Console.WriteLine("Unable to calculate the investment value.");
            return;
        }

        projectedValue = Math.Round(projectedValue, 2);

        Console.WriteLine("\n----- INVESTMENT SUMMARY -----");

        if (investmentType == 1)
        {
            Console.WriteLine("Investment Type: Simple Interest");
        }
        else
        {
            Console.WriteLine("Investment Type: Compound Interest");
        }

        Console.WriteLine($"Principal Amount: {principal:F2}");
        Console.WriteLine($"Annual Rate: {annualRate:F2}%");
        Console.WriteLine($"Duration: {years:F2} years");
        Console.WriteLine($"Projected Value: {projectedValue:F2}");
    }
}