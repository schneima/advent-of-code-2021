using System.Drawing;

namespace AdventOfCode20221;

internal class OceanFloor
{
    public readonly Dictionary<Point, int> Points;

    public OceanFloor()
    {
        Points = new Dictionary<Point, int>();
    }

    public void IncreaseNumberOfLinesToPoint(int x, int y)
    {
        var pointToCheck = new Point(x, y);
        if (Points.ContainsKey(pointToCheck))
        {
            var currentValueAtPoint = Points[pointToCheck];
            currentValueAtPoint++;
            Points[pointToCheck] = currentValueAtPoint;
        }
        else
        {
            Points.Add(pointToCheck, 1);
        }
    }
}