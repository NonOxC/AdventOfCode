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
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)";
        MatchCollection matches = Regex.Matches(input, pattern);
        int total = 0;
        bool isEnabled = true;
        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                isEnabled = true;
            }
            else if (match.Value == "don't()")
            {
                isEnabled = false;
            }
            else if (isEnabled && match.Groups[1].Success && match.Groups[2].Success)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                total += x * y;
            }
        }
        Console.WriteLine($"The total is: {total}");
    }
}