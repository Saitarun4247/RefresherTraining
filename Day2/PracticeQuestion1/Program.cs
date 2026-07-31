using System;

static class FinancialCalculator
{
    public static double CalculateCompoundInterest(
        double principal,
        double rate,
        double time)
    {
        return CalculateCompoundInterest(principal, rate, time, 1);
    }

    public static double CalculateCompoundInterest(
        double principal,
        double rate,
        double time,
        int compoundingFrequency = 1)
    {
        return principal * Math.Pow(
            1 + rate / compoundingFrequency,
            compoundingFrequency * time
        );
    }
}

class Program
{
    static void Main()
    {
        double futureValue1 =
            FinancialCalculator.CalculateCompoundInterest(10000, 0.05, 10);

        double futureValue2 =
            FinancialCalculator.CalculateCompoundInterest(
                principal: 10000,
                rate: 0.05,
                time: 10,
                compoundingFrequency: 12
            );

        Console.WriteLine($"Future value = ${futureValue1:N2}");
        Console.WriteLine($"Future value = ${futureValue2:N2}");
    }
}