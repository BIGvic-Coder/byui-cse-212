using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: Find symmetric word pairs using a HashSet
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1]) continue;

            // Avoid stackalloc — safe and efficient
            string reversed = new string(new[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    // Problem 2: Summarize degrees from CSV file
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();
                if (!string.IsNullOrEmpty(degree))
                {
                    if (degrees.ContainsKey(degree))
                        degrees[degree]++;
                    else
                        degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    // Problem 3: Anagram check using character frequency dictionary
    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string word) => new string(word.ToLower().Where(c => c != ' ').ToArray());

        var w1 = Normalize(word1);
        var w2 = Normalize(word2);

        if (w1.Length != w2.Length) return false;

        var freq1 = new Dictionary<char, int>();
        var freq2 = new Dictionary<char, int>();

        foreach (var c in w1)
            freq1[c] = freq1.GetValueOrDefault(c, 0) + 1;

        foreach (var c in w2)
            freq2[c] = freq2.GetValueOrDefault(c, 0) + 1;

        return freq1.Count == freq2.Count && !freq1.Except(freq2).Any();
    }

    // Problem 5: Earthquake daily summary from USGS JSON feed
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        if (featureCollection?.Features == null) return [];

        var summaries = featureCollection.Features
            .Where(f => f?.Properties != null && f.Properties.Mag.HasValue && !string.IsNullOrWhiteSpace(f.Properties.Place))
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag.Value}")
            .ToArray();

        return summaries;
    }
}
