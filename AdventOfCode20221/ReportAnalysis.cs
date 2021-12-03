namespace AdventOfCode20221;

public class ReportAnalysis
{
    public ReportAnalysis(int gammaRate, int epsilonRate)
    {
        GammaRate = gammaRate;
        EpsilonRate = epsilonRate;
    }
    public int GammaRate { get; }
    public int EpsilonRate { get; }
    public int PowerConsumption => GammaRate * EpsilonRate;
}