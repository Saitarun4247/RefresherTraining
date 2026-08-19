using System;

class Program
{
    static T[] Merge<T>(T[] a, T[] b) where T : IComparable<T>
    {
        T[] merged = new T[a.Length + b.Length];

        int i = 0;
        int j = 0;
        int k = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i].CompareTo(b[j]) <= 0)
            {
                merged[k] = a[i];
                i++;
            }
            else
            {
                merged[k] = b[j];
                j++;
            }

            k++;
        }

        // Add remaining elements from a
        while (i < a.Length)
        {
            merged[k] = a[i];
            i++;
            k++;
        }

        // Add remaining elements from b
        while (j < b.Length)
        {
            merged[k] = b[j];
            j++;
            k++;
        }

        return merged;
    }

    static void Main()
    {
        int[] a = { 1, 3, 5, 7 };
        int[] b = { 2, 4, 6, 8 };

        int[] result = Merge(a, b);

        Console.WriteLine(string.Join(" ", result));
    }
}