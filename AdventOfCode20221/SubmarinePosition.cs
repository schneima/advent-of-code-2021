namespace AdventOfCode20221;

public class SubmarinePosition
{
    public SubmarinePosition(int horPosition, int depth, int aim)
    {
        HorizontalPosition = horPosition;
        Depth = depth;
        Aim = aim;
    }

    public int HorizontalPosition { get; }
    public int Depth { get; }
    public int Aim { get; }
    public int MultipliedValue => Depth * HorizontalPosition;
}