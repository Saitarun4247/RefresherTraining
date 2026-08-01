using System;

public class Solution
{
    public static void Main()
    {
        Console.Write("Enter Customer Type (R/P/V): ");
        char customerType = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Purchase Amount: ");
        double purchaseAmount = Convert.ToDouble(Console.ReadLine());

        double discount = 0;

        switch (customerType)
        {
            case 'R':
                if (purchaseAmount > 100)
                {
                    discount = purchaseAmount * 0.05;
                }
                break;

            case 'P':
                discount = purchaseAmount * 0.10;
                break;

            case 'V':
                discount = purchaseAmount * 0.15;

                if (purchaseAmount > 200)
                {
                    discount += purchaseAmount * 0.05;
                }
                break;

            default:
                Console.WriteLine("Invalid Customer Type");
                return;
        }

        double finalPrice = purchaseAmount - discount;

        Console.WriteLine("\nOriginal Price : $" + purchaseAmount);
        Console.WriteLine("Discount Amount: $" + discount);
        Console.WriteLine("Final Price    : $" + finalPrice);
    }
}