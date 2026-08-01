using System;

public class Solution
{
    public static void Main()
    {
        Console.Write("Enter Item Type (B/D/J): ");
        char itemType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Days Late: ");
        int daysLate = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter User Type (S/R): ");
        char userType = Convert.ToChar(Console.ReadLine().ToUpper());

        double finePerDay = 0;

        // Determine fine rate
        switch (itemType)
        {
            case 'B':
                finePerDay = 0.50;
                break;

            case 'D':
                finePerDay = 1.00;
                break;

            case 'J':
                finePerDay = 0.25;
                break;

            default:
                Console.WriteLine("Invalid Item Type");
                return;
        }

        double fine = 0;

        // Grace period of 3 days
        if (daysLate > 3)
        {
            fine = (daysLate - 3) * finePerDay;
        }

        // Maximum fine cap
        if (fine > 20)
        {
            fine = 20;
        }

        // Student discount
        if (userType == 'S')
        {
            fine = fine * 0.5;
        }

        Console.WriteLine("Fine Amount: $" + fine);
    }
}