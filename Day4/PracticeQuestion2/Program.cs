using System;

public class Solution
{
    public static void Main()
    {
        Console.Write("Enter Vehicle Type (C/M/T): ");
        char vehicleType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Parking Hours: ");
        double hours = Convert.ToDouble(Console.ReadLine());

        double rate = 0;
        double maxFee = 0;

        switch (vehicleType)
        {
            case 'C':
                rate = 3;
                maxFee = 25;
                break;

            case 'M':
                rate = 2;
                maxFee = 15;
                break;

            case 'T':
                rate = 5;
                maxFee = 40;
                break;

            default:
                Console.WriteLine("Invalid Vehicle Type");
                return;
        }

        double fee = 0;

        // First 30 minutes are free
        if (hours > 0.5)
        {
            fee = (hours - 0.5) * rate;
        }

        // Maximum daily fee
        if (fee > maxFee)
        {
            fee = maxFee;
        }

        // 10% discount for parking over 8 hours
        if (hours > 8)
        {
            fee = fee - (fee * 0.10);
        }

        Console.WriteLine("Total Parking Fee: $" + fee);
    }
}