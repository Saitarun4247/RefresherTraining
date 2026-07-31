using System;
using System.Collections.Generic;

class Program
{
    static bool TryParseISBN(string isbn, out string cleanedISBN)
    {
        cleanedISBN = isbn.Replace("-", "").Replace(" ", "");

        if (cleanedISBN.Length == 13 && long.TryParse(cleanedISBN, out _))
        {
            return true;
        }

        cleanedISBN = "";
        return false;
    }

    static bool TryProcessOrder(out List<string> validISBNs, params string[] orders)
    {
        validISBNs = new List<string>();

        foreach (string order in orders)
        {
            string[] isbns = order.Split(',');

            foreach (string isbn in isbns)
            {
                if (TryParseISBN(isbn.Trim(), out string cleanedISBN))
                {
                    validISBNs.Add(cleanedISBN);
                }
            }
        }

        return validISBNs.Count > 0;
    }

    static void Main()
    {
        string order =
            "978-3-16-148410-0, 1234567890123, invalid-isbn, 978-1-4028-9462-6";

        bool result = TryProcessOrder(out List<string> validISBNs, order);

        Console.WriteLine($"Returns: {result}");
        Console.WriteLine("Valid ISBNs:");

        foreach (string isbn in validISBNs)
        {
            Console.WriteLine(isbn);
        }
    }
}