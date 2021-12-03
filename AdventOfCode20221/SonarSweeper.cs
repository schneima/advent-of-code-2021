namespace AdventOfCode20221
{
    public class SonarSweeper
    {
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

            // get gamma reate
            for (int i = 0; i < diagnosticNumbersLength; i++)
            {
                var counter = positionSumDictionary[i];
                var denominator = (decimal)(reportLineNumbers / 2);
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
}