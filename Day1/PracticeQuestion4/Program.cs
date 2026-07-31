using System;

class Program
{
    static void Main()
    {
        double openingBalance;
        double deposits;
        double withdrawals;

        Console.Write("Enter opening balance: ");

        while (!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 0)
        {
            Console.WriteLine("Invalid opening balance. Please enter a valid non-negative amount.");
            Console.Write("Enter opening balance: ");
        }

        Console.Write("Enter total deposits: ");

        while (!double.TryParse(Console.ReadLine(), out deposits) || deposits < 0)
        {
            Console.WriteLine("Invalid deposit amount. Please enter a valid non-negative amount.");
            Console.Write("Enter total deposits: ");
        }

        double availableBalance = openingBalance + deposits;

        Console.Write("Enter total withdrawals: ");

        while (!double.TryParse(Console.ReadLine(), out withdrawals) || withdrawals < 0)
        {
            Console.WriteLine("Invalid withdrawal amount. Please enter a valid non-negative amount.");
            Console.Write("Enter total withdrawals: ");
        }

        if (withdrawals > availableBalance)
        {
            Console.WriteLine("Error: Withdrawal exceeds available balance.");
        }
        else
        {
            double finalBalance = availableBalance - withdrawals;

            Console.WriteLine("\n----- ACCOUNT SUMMARY -----");
            Console.WriteLine($"Opening Balance: {openingBalance:F2}");
            Console.WriteLine($"Total Deposits: {deposits:F2}");
            Console.WriteLine($"Total Withdrawals: {withdrawals:F2}");
            Console.WriteLine($"Final Balance: {finalBalance:F2}");
        }
    }
}