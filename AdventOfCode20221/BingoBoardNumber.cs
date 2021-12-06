namespace AdventOfCode20221;

internal class BingoBoardNumber
{
    private NumberState _numberState;
    public int Row { get; }
    public int Column { get; }
    public int NumberValue { get; }
    public NumberState State => _numberState;

    public BingoBoardNumber(int row, int column, int numberValue)
    {
        Row = row;
        Column = column;
        NumberValue = numberValue;
        _numberState = NumberState.Unmarked;
    }

    public void SetNumberMarked()
    {
        _numberState = NumberState.Marked;
    }
}