using System;

public class Program
{
    public static void Main(string[] args)
    {
        int a = 10;
        int b = 20;

        Console.WriteLine($"Before swap: a = {a}, b = {b}");

        SwapUsingRef(ref a, ref b);

        Console.WriteLine($"After ref swap: a = {a}, b = {b}");

        int x;
        int y;

        SwapUsingOut(a, b, out x, out y);

        Console.WriteLine($"After out swap: a = {x}, b = {y}");
    }

    public static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    public static void SwapUsingOut(
        int a,
        int b,
        out int x,
        out int y)
    {
        x = a + b;
        y = x - b;
        x = x - y;
    }
}