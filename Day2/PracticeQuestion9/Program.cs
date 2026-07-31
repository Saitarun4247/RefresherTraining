using System;
using System.Collections.Generic;

class Transaction
{
    public int Id { get; set; }
    public double RiskValue { get; set; }
    public List<Transaction> Dependencies { get; set; }

    public Transaction(int id, double riskValue)
    {
        Id = id;
        RiskValue = riskValue;
        Dependencies = new List<Transaction>();
    }
}

class Program
{
    static double CalculateRiskScore(
        Transaction transaction,
        ref int depth,
        int maxDepth,
        HashSet<int> visited)
    {
        if (depth >= maxDepth)
        {
            Console.WriteLine("Warning: Maximum recursion depth exceeded.");
            return -1;
        }

        if (visited.Contains(transaction.Id))
        {
            Console.WriteLine(
                $"Warning: Circular reference detected at transaction TX{transaction.Id:D3}."
            );
            return 0;
        }

        visited.Add(transaction.Id);

        double totalRisk = transaction.RiskValue;

        foreach (Transaction dependency in transaction.Dependencies)
        {
            depth++;

            double risk = CalculateRiskScore(
                dependency,
                ref depth,
                maxDepth,
                visited
            );

            depth--;

            if (risk == -1)
            {
                return -1;
            }

            totalRisk += risk;
        }

        visited.Remove(transaction.Id);

        return totalRisk;
    }

    static bool TryParseTransactionId(string input, out int transactionId)
    {
        transactionId = 0;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        if (!input.StartsWith("TX", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        string numberPart = input.Substring(2);

        return int.TryParse(numberPart, out transactionId);
    }

    static void Main()
    {
        Console.Write("Enter Transaction ID: ");
        string input = Console.ReadLine() ?? "";

        if (!TryParseTransactionId(input, out int transactionId))
        {
            Console.WriteLine("Invalid Transaction ID.");
            return;
        }

        Transaction t1 = new Transaction(transactionId, 10);
        Transaction t2 = new Transaction(2, 20);
        Transaction t3 = new Transaction(3, 30);

        t1.Dependencies.Add(t2);
        t2.Dependencies.Add(t3);
        t3.Dependencies.Add(t1);

        int depth = 0;
        int maxDepth = 1000;

        HashSet<int> visited = new HashSet<int>();

        double riskScore = CalculateRiskScore(
            t1,
            ref depth,
            maxDepth,
            visited
        );

        if (riskScore == -1)
        {
            Console.WriteLine("Risk calculation stopped due to maximum depth.");
        }
        else
        {
            Console.WriteLine($"Risk Score: {riskScore}");
        }
    }
}