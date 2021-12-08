namespace AdventOfCode20221;

internal class Laternfish
{
    public static int InitialNewTimerValue = 8;
    public static int DefaultNewTimerValue = 6;
    private bool _firstCycleFinished;
    private int _currenTimerValue;

    public Laternfish(string timerValue)
    {
        _currenTimerValue = int.Parse(timerValue);
        _firstCycleFinished = false;
    }

    public Laternfish()
    {
        _currenTimerValue = InitialNewTimerValue;
    }

    public void ProcessNextDay()
    {
        if (_currenTimerValue > 0)
        {
            _currenTimerValue--;
        }
        else
        {
            _currenTimerValue = DefaultNewTimerValue;
            if (!_firstCycleFinished)
            {
                _firstCycleFinished = true;
            }

        }
    }

    public bool CanProduceNewFishs
    {
        get { return _firstCycleFinished; }
    }

    public int CurrentTimerValue
    {
        get { return _currenTimerValue; }
    }
}