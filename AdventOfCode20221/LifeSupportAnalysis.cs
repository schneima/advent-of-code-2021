namespace AdventOfCode20221;

public class LifeSupportAnalysis
{
    public LifeSupportAnalysis(int oxygenGeneratorRating, int cO2ScrubberRating)
    {
        OxygenGeneratorRating = oxygenGeneratorRating;
        CO2ScrubberRating = cO2ScrubberRating;
    }

    public int OxygenGeneratorRating { get; }

    public int CO2ScrubberRating { get; }

    public int LifeSupportRating => OxygenGeneratorRating * CO2ScrubberRating;
}