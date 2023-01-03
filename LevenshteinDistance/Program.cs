using System;

namespace Algorithms;

public class Program
{
    const string first = "Levenshtein Distance";
    const string second = "Edit Distance";

    private static void Main()
    {
        var percent = Levenshtein.CalculateSimilarity(first, second, Levenshtein.GetEditDistance);
        
        Console.WriteLine("String #1 - {0}\nString #2 - {1} \nSimilarity: {2}%",
            first, second, percent);
    }
}
