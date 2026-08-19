using System;

class Program
{
    static int FinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int transaction in transactions)
        {
            if (transaction >= 0)
            {
                // Deposit
                balance += transaction;
            }
            else
            {
                // Withdrawal
                int withdrawal = -transaction;

                if (withdrawal <= balance)
                {
                    balance -= withdrawal;
                }
                // Otherwise, ignore the transaction
            }
        }

        return balance;
    }

    static void Main()
    {
        int initialBalance = int.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());
        int[] transactions = new int[n];

        for (int i = 0; i < n; i++)
        {
            transactions[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(
            FinalBalance(initialBalance, transactions)
        );
    }
}