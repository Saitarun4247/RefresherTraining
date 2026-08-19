using System;

class Program
{
    static double? CalculateAverage(double?[] values)
    {
        double sum = 0;
        int count = 0;

        foreach (double? value in values)
        {
            if (value == null)
            {
                continue;
            }

            sum += value.Value;
            count++;
        }

        // No non-null values
        if (count == 0)
        {
            return null;
        }

        double average = sum / count;

        return Math.Round(
            average,
            2,
            MidpointRounding.AwayFromZero
        );
    }

    static void Main()
    {
        double?[] values = { 10.5, null, 20.5, 30.0, null };

        double? result = CalculateAverage(values);

        if (result.HasValue)
        {
            Console.WriteLine(result.Value.ToString("F2"));
        }
        else
        {
            Console.WriteLine("null");
        }
    }
}