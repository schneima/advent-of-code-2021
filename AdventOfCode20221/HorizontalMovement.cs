namespace AdventOfCode20221;

internal class HorizontalMovement
{
    public HorizontalMovement(int horizontalPosition, int fuelCost)
    {
        HorizontalPosition = horizontalPosition;
        FuelCost = fuelCost;
    }

    public int HorizontalPosition { get; }
    public int FuelCost { get; }
}