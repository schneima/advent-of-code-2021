namespace AdventOfCode20221;

internal static class TestHelper
{
    internal static  string[] GetLinesFromFile(string fileToRead)
    {
        var lines = File.ReadAllLines(fileToRead);
        return lines;
    }
}