using System;

namespace Algorithms;

internal static class Levenshtein
{
    public static int GetEditDistance(string first, string second)
    {
        var f_length = first.Length;
        var s_length = second.Length;
        var matrix = GetMatrixInt(f_length, s_length);

        if (f_length == 0 || s_length == 0)
            return Math.Max(f_length, s_length);

        for (int i = 1; i <= f_length; i++) 
        {
            for (int j = 1; j <= s_length; j++)
            {
                var cost = first[i - 1] == second[j - 1] ? 0 : 1;
                
                matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }

        return matrix[f_length - 1, s_length - 1];
    }

    public static float CalculateSimilarity(string first, string second, int levenshteinDist)
    {
        var f_length = first.Length;
        var s_length = second.Length;

        float bigger = Math.Max(f_length, s_length);
        float percent = (bigger - levenshteinDist) / bigger * 100;
        
        return percent;
    }

    public static float CalculateSimilarity(string first, string second, Func<string, string, int> levenshteinDist)
        => CalculateSimilarity(first, second, levenshteinDist(first, second));

    private static int[,] GetMatrixInt(int first_length, int second_length)
    {
        var matrix = new int[first_length + 1, second_length + 1];

        for (int i = 1; i <= first_length; matrix[i, 0] = i++) { }
        for (int j = 1; j <= second_length; matrix[0, j] = j++) { }

        return matrix;
    }
}
