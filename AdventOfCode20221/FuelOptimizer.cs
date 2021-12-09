namespace AdventOfCode20221;

internal class FuelOptimizer
{
    private readonly string _initialCrabPositionsString;

    public FuelOptimizer(string initialCrabPositionsString)
    {
        _initialCrabPositionsString = initialCrabPositionsString;

    }

    public HorizontalMovement GetOptimizedAlignedMovement()
    {
        var positions = GetNumbersByInitString();

        // walk from min to max position;
        var minPosition = positions.Min();
        var maxPosition = positions.Max();
        var movementsToAnalyze = new List<HorizontalMovement>();
        //Parallel.For(minPosition, maxPosition + 1, positionToDetermine =>
        //{
        //    int currentFuelCostSum = 0;
        //    foreach (var currentPosition in positions)
        //    {
        //        var currentFuelCost = Math.Abs(positionToDetermine - currentPosition);
        //        currentFuelCostSum += currentFuelCost;
        //    }

        //    var currentMovement = new HorizontalMovement(positionToDetermine, currentFuelCostSum);
        //    movementsToAnalyze.Add(currentMovement);
        //});

        for (int positionToDetermine = minPosition; positionToDetermine < maxPosition + 1; positionToDetermine++)
        {
            int currentFuelCostSum = 0;
            foreach (var currentPosition in positions)
            {
                var currentFuelCost = Math.Abs(positionToDetermine - currentPosition);
                currentFuelCostSum += currentFuelCost;
            }

            var currentMovement = new HorizontalMovement(positionToDetermine, currentFuelCostSum);
            movementsToAnalyze.Add(currentMovement);                
        }
            
        var orderedMovementsByLeastFuelCost  = movementsToAnalyze.OrderBy(m => m.FuelCost).ToArray();
        return orderedMovementsByLeastFuelCost[0];
    }

    private int[] GetNumbersByInitString()
    {
        var numberParts = _initialCrabPositionsString.Split(',');
        var numberOfNumbers = numberParts.Length;
        int[] numbers = new int[numberOfNumbers];

        Parallel.For(0, numberOfNumbers, currentIndex =>
        {
            var currentNumber = int.Parse(numberParts[currentIndex]);
            numbers[currentIndex] = currentNumber;
        });

        return numbers;
    }
}