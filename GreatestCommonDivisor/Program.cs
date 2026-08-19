using System;

class Program
{
    static int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }

        return Gcd(b, a % b);
    }

    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine(Gcd(a, b));
    }
}