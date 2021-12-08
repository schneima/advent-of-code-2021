namespace AdventOfCode20221;

internal class LaternfishSwarm
{
    private readonly List<Laternfish> _laternFishes;

    public LaternfishSwarm(List<Laternfish> laternfishes)
    {
        _laternFishes = laternfishes;
    }

    public void ProcessNextDay()
    {
        var currentListOfFishes = _laternFishes.ToArray();
        foreach (var laternfish in currentListOfFishes)
        {
            laternfish.ProcessNextDay();
            if (laternfish.CanProduceNewFishs && laternfish.CurrentTimerValue == Laternfish.DefaultNewTimerValue)
            {
                var newfish = new Laternfish();
                _laternFishes.Add(newfish);
            }
        }
    }

    public void LogCurrentState()
    {
        foreach (var laternfish in _laternFishes)
        {
            Console.Write($"{laternfish.CurrentTimerValue},");
        }
        Console.WriteLine();
    }

    public int GetCurrentNumberOfFishes()
    {
        return _laternFishes.Count;
    }
}