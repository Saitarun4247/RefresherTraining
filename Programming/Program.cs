using System;

class Program
{
    static int SumOfDigits(long n)
    {
        int sum = 0;

        while (n > 0)
        {
            sum += (int)(n % 10);
            n /= 10;
        }

        return sum;
    }

    static bool IsPrime(long n)
    {
        if (n < 2)
            return false;

        for (long i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    static bool IsLuckyNumber(int x)
    {
        // Must be a positive non-prime integer
        if (x <= 0 || IsPrime(x))
            return false;

        int sum = SumOfDigits(x);

        long square = (long)x * x;

        int squareDigitSum = SumOfDigits(square);

        return squareDigitSum == sum * sum;
    }

    static void Main()
    {
        int x = int.Parse(Console.ReadLine());

        Console.WriteLine(IsLuckyNumber(x));
    }
}