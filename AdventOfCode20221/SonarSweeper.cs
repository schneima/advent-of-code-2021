namespace AdventOfCode20221
{
    public class SonarSweeper
    {
        private const string EqualNumberIndicator = "-1";

        public int GetNumberOfIncreases(int[] measurements)
        {
            var numberOfIncreases = 0;
            for (var i = 1; i < measurements.Length; i++)
            {
                if (measurements[i] > measurements[i - 1])
                {
                    numberOfIncreases++;
                }
            }

            return numberOfIncreases;
        }

        public int GetNumberOfSumOfIncreases(int[] measurements)
        {
            var numberOfSumOfIncreases = 0;
            for (var i = 3; i < measurements.Length; i++)
            {
                var currentSum = measurements[i] + measurements[i - 1] + measurements[i - 2];
                var latestSum = measurements[i - 1] + measurements[i - 2] + measurements[i - 3];
                if (currentSum > latestSum)
                {
                    numberOfSumOfIncreases++;
                }
            }

            return numberOfSumOfIncreases;
        }

        public SubmarinePosition GetPositionResultBy(string[] commands)
        {
            var horPosition = 0;
            var depth = 0;
            var aim = 0;
            foreach (var command in commands)
            {
                var commandType = command.Split(' ')[0];
                var value = int.Parse(command.Split(' ')[1]);
                switch (commandType)
                {
                    case "forward":
                        horPosition += value;
                        depth += aim * value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                }
            }

            return new SubmarinePosition(horPosition, depth, aim);
        }

        internal LifeSupportAnalysis getLifeSupportRatingAnalyzisBy(string[] diagnosticReport)
        {
            // first get bit masks (gamma rate / epsilon rate)
            var reportAnalysis = GetReportAnalysisBy(diagnosticReport);
            var oxigenGeneratorRatingBitMask = Convert.ToString(reportAnalysis.GammaRate, 2);
            var co2ScrubberRatingBitMask = Convert.ToString(reportAnalysis.EpsilonRate, 2);

            int oxygenGeneratorRating = SortNumbersByBitCriteria(diagnosticReport, BitCriteria.Oxygen);
            int co2ScrubberRating = SortNumbersByBitCriteria(diagnosticReport, BitCriteria.Co2Scrubber);

            var analyses = new LifeSupportAnalysis(oxygenGeneratorRating, co2ScrubberRating);
            return analyses;
        }

        private int GetCo2ScrubberRating(string co2ScrubberRatingBitMask, string[] diagnosticReport)
        {
            var numbersToCheck = new List<string>();
            var oldNumbersToCheck = diagnosticReport;

            // loop number position of bit mask
            for (int currentNumberPosition = 0; currentNumberPosition < co2ScrubberRatingBitMask.Length; currentNumberPosition++)
            {
                var currentBitMaskNumber = co2ScrubberRatingBitMask[currentNumberPosition];

                if (oldNumbersToCheck.Length == 2)
                {
                    // get last bits of numbers
                    var numberAIndex = 0;
                    var numberBIndex = 1;
                    if (oldNumbersToCheck[numberAIndex].EndsWith('0'))
                    {
                        numbersToCheck.Add(oldNumbersToCheck[numberAIndex]);
                    }
                    else
                    {
                        numbersToCheck.Add(oldNumbersToCheck[numberBIndex]);
                    }
                }
                else // if more than two numbers left
                if (oldNumbersToCheck.Length > 2)
                {
                    // of each number left to check
                    foreach (var reportLine in oldNumbersToCheck)
                    {
                        var currentNumberToCheck = reportLine[currentNumberPosition];
                        if (currentNumberToCheck.Equals(currentBitMaskNumber))
                        {
                            numbersToCheck.Add(reportLine);
                        }
                    }
                }
                else if (oldNumbersToCheck.Length == 1)
                {
                    numbersToCheck.Add(oldNumbersToCheck[0]);
                }

                oldNumbersToCheck = numbersToCheck.ToArray();
                numbersToCheck = new List<string>();
            }

            var lastBitNumber = oldNumbersToCheck[0];
            var value = Convert.ToInt32(lastBitNumber, 2);

            return value;
        }

        private int SortNumbersByBitCriteria(string[] diagnosticReport, BitCriteria bitCriteria)
        {
            var remainingNumbersToCheck = diagnosticReport;
            var numbersToCheck = new List<string>();

            int currentPosition = 0;
            while (remainingNumbersToCheck.Length > 1)
            {
                var mostCommonBitAtCurrentPosition = GetMostCommonBitAtPosition(remainingNumbersToCheck, currentPosition, bitCriteria);

                // check currentNumbers
                var remainingNumbers = getNumbersThatRemainAfterCurrentBitMask(remainingNumbersToCheck, mostCommonBitAtCurrentPosition, currentPosition);

                remainingNumbersToCheck = remainingNumbers.ToArray();
                currentPosition++;
            }

            var lastBitNumber = remainingNumbersToCheck[0];
            var value =  Convert.ToInt32(lastBitNumber, 2);

            return value;
        }

        private List<string> getNumbersThatRemainAfterCurrentBitMask(string[] numbersToCheck, string mostCommonBitAtCurrentPosition, int position)
        {
            var remainingNumbers = new List<string>();
            foreach (var currentNumberToCheck in numbersToCheck)
            {
                var currentBitOfNumberToCheck = currentNumberToCheck[position].ToString();
                if (currentBitOfNumberToCheck.Equals(mostCommonBitAtCurrentPosition))
                {
                    remainingNumbers.Add(currentNumberToCheck);
                }
            }

            return remainingNumbers;
        }

        // returns most common bit a specific position accoring to bitCriteria
        private string GetMostCommonBitAtPosition(string[] diagnosticReport, int position, BitCriteria bitCriteria)
        {
            var mostCommonBitAtCurrentPosition = string.Empty;
            var sum = 0;
            foreach (var line in diagnosticReport)
            {
                var currentBitAtPosition = Convert.ToInt32(line[position].ToString());
                sum += currentBitAtPosition;
            }

            decimal average = (decimal)(sum /(decimal)diagnosticReport.Length);

            if (average.Equals((decimal)0.5))
            {
                mostCommonBitAtCurrentPosition = EqualNumberIndicator;
            }

            if (average > (decimal)0.5) {
                switch (bitCriteria)
                {
                    case BitCriteria.Co2Scrubber:
                        mostCommonBitAtCurrentPosition = "0";
                        break;
                    case BitCriteria.Oxygen:
                        mostCommonBitAtCurrentPosition = "1";
                        break;
                }
            }

            if (average < (decimal)0.5)
            {
                switch (bitCriteria)
                {

                    case BitCriteria.Co2Scrubber:
                        mostCommonBitAtCurrentPosition = "1";
                        break;
                    case BitCriteria.Oxygen:
                        mostCommonBitAtCurrentPosition = "0";
                        break;
                }
            }

            if (mostCommonBitAtCurrentPosition.Equals(EqualNumberIndicator))
            {
                switch (bitCriteria)
                {
                    case BitCriteria.Oxygen:
                        mostCommonBitAtCurrentPosition = "1";
                        break;
                    case BitCriteria.Co2Scrubber:
                        mostCommonBitAtCurrentPosition = "0";
                        break;
                }
            }

            return mostCommonBitAtCurrentPosition;
        }

        public ReportAnalysis GetReportAnalysisBy(string[] diagnosticReport)
        {
            var diagnosticNumbersLength = diagnosticReport[0].Length;
            var reportLineNumbers = diagnosticReport.Length;
            var gammaRateBitArray = new string[diagnosticNumbersLength];

            // for gamma rate: idea is to sum up bits at specific position, divided by half of report Length
            // => if >1 1 is most common bit
            // => if <1 0 is most common bit
            // => if == 1 same count of 0/1 bits => error exception, undefined case!
            var positionSumDictionary = new Dictionary<int, int>();

            // for epsilon rate we just invert gamma rate bit number

            for (int i = 0; i < reportLineNumbers; i++)
            {
                var currentLine = diagnosticReport[i];
                for (int currentNumberPosition = 0; currentNumberPosition < diagnosticNumbersLength; currentNumberPosition++)
                {
                    var currentBitCharacter = currentLine[currentNumberPosition].ToString();
                    var value = int.Parse(currentBitCharacter);

                    // add value to position if exists in dict already
                    if (positionSumDictionary.ContainsKey(currentNumberPosition))
                    {
                        positionSumDictionary[currentNumberPosition] += value;
                    }
                    else
                    {
                        // else create new key + value
                        positionSumDictionary.Add(currentNumberPosition, value);
                    }
                }
            }

            var denominator = (decimal)(reportLineNumbers / 2);

            // get gamma reate
            for (int i = 0; i < diagnosticNumbersLength; i++)
            {
                var counter = positionSumDictionary[i];
                decimal averageBitValue = counter / denominator;

                switch (averageBitValue)
                {
                    case < 1:
                        gammaRateBitArray[i] = "0";
                        break;

                    case > 1:
                        gammaRateBitArray[i] = "1";
                        break;
                }

                // first try
                //gammaRateBitArray[i] = averageBitValue switch
                //{
                //    > 1 => "1",
                //    < 1 => "0",
                //    0 => throw new Exception("Undefined UseCase!"),
                //    _ => gammaRateBitArray[i]
                //};
            }

            var gammaBitNumber = string.Join("", gammaRateBitArray);
            var gammaRate = GetGammaRateByBitValue(gammaBitNumber);
            var epslionRate = GetEpsilonRateByGammaRate(gammaBitNumber);
            return new ReportAnalysis(gammaRate, epslionRate);
        }

        private int GetEpsilonRateByGammaRate(string gammaBitNumber)
        {
            string invertedGamaBitValue = gammaBitNumber.Replace('0', '*').Replace('1', '0').Replace('*', '1');
            var epsilonRate = Convert.ToInt32(invertedGamaBitValue, 2);
            return epsilonRate;
        }

        private int GetGammaRateByBitValue(string gammaBitNumber)
        {
            var gammaRate = Convert.ToInt32(gammaBitNumber, 2);
            return gammaRate;
        }
    }

    public enum BitCriteria
    {
        Oxygen,
        Co2Scrubber
    }
}