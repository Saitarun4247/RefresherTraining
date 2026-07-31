using System;

static class MathOperations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Add(params int[] numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Multiply(params int[] numbers)
    {
        int result = 1;

        foreach (int number in numbers)
        {
            result *= number;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(MathOperations.Add(5, 10));
        Console.WriteLine(MathOperations.Add(1, 2, 3, 4, 5));

        Console.WriteLine(MathOperations.Multiply(2, 3));
        Console.WriteLine(MathOperations.Multiply(2, 3, 4, 5));
    }
}