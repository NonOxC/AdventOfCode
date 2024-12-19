using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Read input from file (replace "input.txt" with your actual input file)
        string[] lines = File.ReadAllLines("input.txt");

        int safeCount = 0;

        foreach (string line in lines)
        {
            // Parse the report into a list of integers
            List<int> report = line.Split(' ').Select(int.Parse).ToList();

            if (IsSafe(report) || IsSafeWithDampener(report))
            {
                safeCount++;
            }
        }

        Console.WriteLine($"Number of safe reports: {safeCount}");
    }

    static bool IsSafe(List<int> report)
    {
        // Calculate differences between adjacent levels
        List<int> differences = new List<int>();
        for (int i = 0; i < report.Count - 1; i++)
        {
            differences.Add(report[i + 1] - report[i]);
        }

        // Check if all differences are within the valid range and the sequence is monotonic
        bool increasing = differences.All(diff => diff >= 1 && diff <= 3);
        bool decreasing = differences.All(diff => diff >= -3 && diff <= -1);

        return increasing || decreasing;
    }

    static bool IsSafeWithDampener(List<int> report)
    {
        // Check if removing a single level makes the report safe
        for (int i = 0; i < report.Count; i++)
        {
            // Create a new report without the i-th level
            List<int> modifiedReport = new List<int>(report);
            modifiedReport.RemoveAt(i);

            // Check if the modified report is safe
            if (IsSafe(modifiedReport))
            {
                return true;
            }
        }

        return false;
    }
}