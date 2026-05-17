using System;
using System.Collections.Generic;

public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True
    }

    /// <summary>
    /// Determine if there are any duplicate letters in the text provided
    /// </summary>
    private static bool AreUniqueLetters(string text)
    {
        var seen = new HashSet<char>();

        foreach (var ch in text)
        {
            if (!seen.Add(ch))
            {
                // Duplicate found
                return false;
            }
        }

        return true;
    }
}
