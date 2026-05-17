using System;
using System.Collections.Generic;

public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        // Expected output (order may vary):
        // 6 4
        // 7 3
        // 8 2
        // 9 1

        Console.WriteLine("------------");
        DisplaySumPairs(new[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });
        // Expected output:
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs(new[] { 5, 11, 2, -4, 6, 8, -1 });
        // Expected output:
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time. We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    private static void DisplaySumPairs(int[] numbers)
    {
        var seen = new HashSet<int>();

        foreach (var num in numbers)
        {
            int complement = 10 - num;

            // If complement already seen, we found a pair
            if (seen.Contains(complement))
            {
                Console.WriteLine($"{num} {complement}");
            }

            // Add current number to set
            seen.Add(num);
        }
    }
}
