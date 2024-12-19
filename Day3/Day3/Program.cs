using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        string input = string.Join("", lines);
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        MatchCollection matches = Regex.Matches(input, pattern);
        int total = 0;

        foreach (Match match in matches)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            total += x * y;
        }

        Console.WriteLine($"The total is: {total}");
    }

}
