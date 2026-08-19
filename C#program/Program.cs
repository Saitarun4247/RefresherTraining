using System;

class Program
{
    static string ProcessWord(string first, string second)
    {
        string result = "";

        // Task 1: Remove common consonants
        foreach (char ch in first)
        {
            char lower = char.ToLower(ch);

            // Check if character is a consonant
            bool isConsonant = lower >= 'a' && lower <= 'z' &&
                               lower != 'a' &&
                               lower != 'e' &&
                               lower != 'i' &&
                               lower != 'o' &&
                               lower != 'u';

            bool existsInSecond = false;

            foreach (char ch2 in second)
            {
                if (char.ToLower(ch2) == lower)
                {
                    existsInSecond = true;
                    break;
                }
            }

            // Keep character if it is not a common consonant
            if (!(isConsonant && existsInSecond))
            {
                result += ch;
            }
        }

        // Task 2: Remove consecutive duplicate characters
        string finalResult = "";

        foreach (char ch in result)
        {
            if (finalResult.Length == 0 ||
                finalResult[finalResult.Length - 1] != ch)
            {
                finalResult += ch;
            }
        }

        return finalResult;
    }

    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        Console.WriteLine(ProcessWord(first, second));
    }
}