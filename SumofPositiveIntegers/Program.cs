using System;

class Program
{
    static int SumPositive(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
            {
                break;
            }

            if (num < 0)
            {
                continue;
            }

            sum += num;
        }

        return sum;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine(SumPositive(nums));
    }
}