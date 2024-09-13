using System;
using System.Collections.Generic;


Console.Write("Write a string: ");
string input = Console.ReadLine();
Console.WriteLine();


List<(int start, int end)> matches = SubstringMatch(input);
ulong sum = 0;

foreach (var match in matches)
{
    string substring = input.Substring(match.start, match.end - match.start + 1);

    Console.Write(input.Substring(0, match.start));
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(substring);
    Console.ResetColor();
    Console.WriteLine(input.Substring(match.end + 1));

    if (ulong.TryParse(substring, out ulong seqLength))
    {
        sum += seqLength;
    }
}

Console.WriteLine($"\nThe sum of the highlited numbers is: {sum}");
 

static List<(int start, int end)> SubstringMatch(string input)
{
    List<(int start, int end)> matches = new List<(int start, int end)>();

    for (int i = 0; i < input.Length - 2; i++)
    {
        if (char.IsDigit(input[i]))
        {
            for (int j = i + 2; j < input.Length; j++)
            {
                if (input[i] == input[j] && NumberCheck(input, i, j))
                {
                    matches.Add((i, j));
                }
            }
        }
    }

    return matches;
}

static bool NumberCheck(string input, int start, int end)
{
    for (int i = start + 1; i < end; i++)
    {
        if (!char.IsDigit(input[i]) || input[i] == input[start])
        {
            return false;
        }
    }
    return end - start > 1;
}
