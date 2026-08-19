using System;

class Program
{
    static int FindLargest(int a, int b, int c)
    {
        int largest;

        if (a >= b && a >= c)
        {
            largest = a;
        }
        else if (b >= a && b >= c)
        {
            largest = b;
        }
        else
        {
            largest = c;
        }

        return largest;
    }

    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine(FindLargest(a, b, c));
    }
}