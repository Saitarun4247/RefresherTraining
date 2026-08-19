using System;
using System.Globalization;

class Program
{
    static string CleanInventoryName(string input)
    {
        // Trim extra spaces
        input = input.Trim();

        // Remove consecutive duplicate characters
        string result = "";

        foreach (char ch in input)
        {
            if (result.Length == 0 || result[result.Length - 1] != ch)
            {
                result += ch;
            }
        }

        // Convert to TitleCase
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        result = textInfo.ToTitleCase(result.ToLower());

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(CleanInventoryName(input));
    }
}