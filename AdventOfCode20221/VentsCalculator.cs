using System.Drawing;

namespace AdventOfCode20221;

internal class VentsCalculator
{
    private readonly string[] _rawData;
    private static string LineSeparator = "->";
    private readonly OceanFloor _oceanFloor;
    private bool _supportDiagonalLines;

    /*
    affected lines by deciding if lines is horizontal or vertical (fix row/col index is known)
    walk through all affected points and add +1 to current number of lines value
    calculation lines and affected points (sum up number of lines at point)
    get points with a value > 1
    board of points with properties (number of lines at this point)  
     */

    public VentsCalculator(string[] linesData)
    {
        _oceanFloor = new OceanFloor();
        _rawData = linesData;
    }

    public int GetNumberOfPointsWithOverlappingLines()
    {
        return _oceanFloor.Points.Count(oceanFloorPoint => oceanFloorPoint.Value > 1);
    }

    public void ProcessData(bool supportDiagonalLines = false)
    {
        _supportDiagonalLines = supportDiagonalLines;
        foreach (var line in _rawData)
        {
            ProcessLine(line);
        }

        // var dimension = _oceanFloor.Points.Max(p => p.Key.X);
        //// log current ocean floor
        //for (int rowIndes = 0; rowIndes < dimension +1; rowIndes++)
        //{
        //    PrintLine(rowIndes, dimension);
        //}
    }

    private void PrintLine(int rowIndex, int dimension)
    {
        var pointsLineI = _oceanFloor.Points.Where(p => p.Key.Y == rowIndex);
        for (int columnIndex = 0; columnIndex < dimension + 1; columnIndex++)
        {
            var valueInPoint = pointsLineI.Where(p => p.Key.X == columnIndex);
            if (valueInPoint.Any())
            {
                var formattedValue = $"{valueInPoint.First().Value:0}";
                Console.Write(formattedValue);
            }
            else
            {
                Console.Write($".");
            }
        }

        Console.WriteLine();
    }

    private void ProcessLine(string lineData)
    {
        var line = GetLineByRawData(lineData);

        switch (line.LineOrientation)
        {
            // mark points between start end end of line
            case Orientation.Vertical:
                {
                    for (int i = line.StartOfLine.Y; i < line.EndOfLine.Y + 1; i++)
                    {
                        _oceanFloor.IncreaseNumberOfLinesToPoint(line.StartOfLine.X, i);
                    }

                    break;
                }
            case Orientation.Horizontal:
                {
                    for (int i = line.StartOfLine.X; i < line.EndOfLine.X + 1; i++)
                    {
                        _oceanFloor.IncreaseNumberOfLinesToPoint(i, line.StartOfLine.Y);
                    }

                    break;
                }

            case Orientation.Diagonal:
                {
                    if (_supportDiagonalLines)
                    {  
                        UpdateOceanFloorByDiagonalLine(line);
                    }
                }
                break;
        }
    }

    public void UpdateOceanFloorByDiagonalLine(Line line)
    {
        // at this point we can assume startpoint.x < entpoint.y (see GetLineByRawData)
        // check weather line goes "up" (decrease of y value) or "down" (increase of y value)
        // to decided in which direction for loop must go
        var startYIndex = line.StartOfLine.Y;
        var endYIndex = line.EndOfLine.Y;
        var lineGoesUp = startYIndex > endYIndex;
        if (lineGoesUp)
        {
            var xIndexTomark = line.StartOfLine.X;

            // we have to loop from start y down to end y
            for (int y = startYIndex; y >= endYIndex; y--)
            {
                var yIndexTomark = y;
                _oceanFloor.IncreaseNumberOfLinesToPoint(xIndexTomark, yIndexTomark);

                xIndexTomark++;
            }
        }
        else
        {
            var xIndexTomark = line.StartOfLine.X;

            // we have to loop from start y up to end y
            for (int y = startYIndex; y <= endYIndex; y++)
            {
                var yIndexTomark = y;
                _oceanFloor.IncreaseNumberOfLinesToPoint(xIndexTomark, yIndexTomark);

                xIndexTomark++;
            }

        }
    }

    public static Line GetLineByRawData(string lineData)
    {
        var lineParts = lineData.Split(LineSeparator);

        Point startOfLine;
        Point endOfLine;
        var pointA = GetPointByLinePart(lineParts[0]);
        var pointB = GetPointByLinePart(lineParts[1]);

        // determine start / end of line by higher value

        if (pointA.X == pointB.X)
        {
            if (pointA.Y > pointB.Y)
            {
                startOfLine = pointB;
                endOfLine = pointA;
            }
            else
            {
                startOfLine = pointA;
                endOfLine = pointB;
            }

            return new Line(startOfLine, endOfLine);
        }
        else
        {
            // catches        (pointA.Y == pointB.Y)
            // horizontal lines also rest
            if (pointA.X > pointB.X)
            {
                startOfLine = pointB;
                endOfLine = pointA;
            }
            else
            {
                startOfLine = pointA;
                endOfLine = pointB;
            }

            return new Line(startOfLine, endOfLine);
        }
    }

    public static Point GetPointByLinePart(string linePart)
    {
        var xIndex = 0;
        var yIndex = 1;
        var coordinates = linePart.Split(',');
        var xValue = int.Parse(coordinates[xIndex].Trim());
        var yValue = int.Parse(coordinates[yIndex].Trim());

        var point = new Point(xValue, yValue);
        return point;
    }
}