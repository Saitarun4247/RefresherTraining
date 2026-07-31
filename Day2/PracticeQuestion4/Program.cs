using System;

class Program
{
    static double CalculateArea(double radius, int decimals = 2)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, decimals);
    }

    static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    static double CalculateArea(double baseValue, double height, bool isTriangle)
    {
        return 0.5 * baseValue * height;
    }

    static void Main()
    {
        double circleArea = CalculateArea(5);

        double rectangleArea = CalculateArea(4.0, 6.0);

        double triangleArea = CalculateArea(3, 7, true);

        double circleAreaWithPrecision = CalculateArea(
            radius: 5,
            decimals: 4
        );

        Console.WriteLine($"Circle area = {circleArea:F2}");
        Console.WriteLine($"Rectangle area = {rectangleArea}");
        Console.WriteLine($"Triangle area = {triangleArea}");
        Console.WriteLine($"Circle area = {circleAreaWithPrecision:F4}");
    }
}