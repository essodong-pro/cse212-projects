using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function makes an array of multiples of a given number.  
    /// Example: MultiplesOf(7, 5) → {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // First, we need an array big enough to hold all the multiples.
        double[] result = new double[length];

        // Then we loop through each position in the array.
        for (int i = 0; i < length; i++)
        {
            // At position i, we put the number times (i+1).
            // Using (i+1) makes sure the first value is the number itself.
            result[i] = number * (i + 1);
        }

        // Finally, we return the filled array.
        return result;
    }

    /// <summary>
    /// Rotates the list to the right by the given amount.  
    /// Example: {1,2,3,4,5,6,7,8,9}, amount=3 → {7,8,9,1,2,3,4,5,6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Rotating means we take the last "amount" of items and move them to the front.
        // If amount equals the size of the list, the list stays the same.
        amount = amount % data.Count;

        // Grab the last "amount" items (the tail).
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Grab the rest of the items (the head).
        List<int> head = data.GetRange(0, data.Count - amount);

        // Clear the original list so we can rebuild it.
        data.Clear();

        // Put the tail first, then the head.
        data.AddRange(tail);
        data.AddRange(head);
    }
}
