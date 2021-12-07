using System.Drawing;

namespace AdventOfCode20221;

internal class Line
{
    public Point StartOfLine { get; }
    public Point EndOfLine { get; }
    public Orientation LineOrientation { get; private set; }

    public Line(Point startOfLine, Point endOfLine)
    {
        StartOfLine = startOfLine;
        EndOfLine = endOfLine;
        SetOrientation();

    }

    private void SetOrientation()
    {
        if (StartOfLine.X == EndOfLine.X)
        {
            LineOrientation = Orientation.Vertical;
        }
        else if (StartOfLine.Y == EndOfLine.Y)
        {
            LineOrientation = Orientation.Horizontal;
        }
        else
        {
            LineOrientation = Orientation.Other;
        }
    }
}