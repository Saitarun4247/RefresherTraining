using System;

public class Solution
{
    public int[] MultiplicationTable(int n, int upto)
    {
        int[] row = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            row[i - 1] = n * i;
        }

        return row;
    }

    public static void Main()
    {
        Solution s = new Solution();

        int[] result = s.MultiplicationTable(3, 5);

        Console.WriteLine(string.Join(", ", result));
    }
}