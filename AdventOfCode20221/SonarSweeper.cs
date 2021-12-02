namespace AdventOfCode20221
{
    public class SonarSweeper
    {
        public int GetNumberOfIncreases(int[] measurements)
        {
            var numberOfIncreases = 0;
            for (var i = 1; i < measurements.Length; i++)
            {
                if (measurements[i] > measurements[i-1])
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
                var currentSum = measurements[i] + measurements[i-1] + measurements[i-2];
                var latestSum = measurements[i-1] + measurements[i-2] + measurements[i-3];
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
    }
}