using System;

class Program
{
    static void Main()
    {
        double price;
        int quantity;
        double discountPercentage;

        Console.Write("Enter item price: ");

        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.WriteLine("Invalid price. Please enter a valid non-negative number.");
            Console.Write("Enter item price: ");
        }

        Console.Write("Enter quantity: ");

        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Please enter a valid non-negative integer.");
            Console.Write("Enter quantity: ");
        }

        Console.Write("Enter discount percentage: ");

        while (!double.TryParse(Console.ReadLine(), out discountPercentage) ||
               discountPercentage < 0 || discountPercentage > 100)
        {
            Console.WriteLine("Invalid discount. Please enter a value between 0 and 100.");
            Console.Write("Enter discount percentage: ");
        }

        double subtotal = price * quantity;
        double discountAmount = subtotal * discountPercentage / 100;
        double finalAmount = subtotal - discountAmount;

        subtotal = Math.Round(subtotal, 2);
        discountAmount = Math.Round(discountAmount, 2);
        finalAmount = Math.Round(finalAmount, 2);

        Console.WriteLine("\n----- BILL -----");
        Console.WriteLine($"Subtotal: {subtotal:F2}");
        Console.WriteLine($"Discount Amount: {discountAmount:F2}");
        Console.WriteLine($"Final Payable Amount: {finalAmount:F2}");
    }
}