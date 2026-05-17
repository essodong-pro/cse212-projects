using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // -------------------------------
    // Problem 1: Find Pairs with Sets
    // -------------------------------
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>(words);
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;

            var reversed = new string(new[] { word[1], word[0] });
            if (seen.Contains(reversed))
            {
                results.Add($"{word} & {reversed}");
                seen.Remove(word);
                seen.Remove(reversed);
            }
        }

        return results.ToArray();
    }

    // -------------------------------
    // Problem 2: Degree Summary
    // -------------------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3)
            {
                var degree = fields[3].Trim();

                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }

        return degrees;
    }

    // -------------------------------
    // Problem 3: Anagrams (Optimized for 60M Chars)
    // -------------------------------
    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();
        int length1 = 0;
        int length2 = 0;

        // Count character frequencies for word1, skipping spaces on-the-fly
        for (int i = 0; i < word1.Length; i++)
        {
            char c = word1[i];
            if (c == ' ') continue;

            c = char.ToLowerInvariant(c);
            length1++;

            if (counts.ContainsKey(c)) counts[c]++;
            else counts[c] = 1;
        }

        // Subtract character frequencies for word2, skipping spaces on-the-fly
        for (int i = 0; i < word2.Length; i++)
        {
            char c = word2[i];
            if (c == ' ') continue;

            c = char.ToLowerInvariant(c);
            length2++;

            if (!counts.ContainsKey(c)) return false;

            counts[c]--;
            if (counts[c] < 0) return false;
        }

        // Check if length matches and all character entries were zeroed out
        return length1 == length2;
    }

    // -------------------------------
    // Problem 5: Earthquake JSON Data
    // -------------------------------
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null)
                {
                    double magnitude = feature.Properties.Mag ?? 0.0;
                    results.Add($"{feature.Properties.Place} - Mag {magnitude}");
                }
            }
        }

        return results.ToArray();
    }
}

/// <summary>
/// Classes for Earthquake JSON mapping
/// </summary>
