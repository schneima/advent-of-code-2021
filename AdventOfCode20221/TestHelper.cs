namespace AdventOfCode20221;

internal static class TestHelper
{
    internal static  string[] GetLinesFromFile(string fileToRead)
    {
        var lines = File.ReadAllLines(fileToRead);
        return lines;
    }

    internal static string GetStringFromFile(string fileToRead)
    {
        var content = File.ReadAllText(fileToRead);
        return content;
    }
}